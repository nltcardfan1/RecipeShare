using System.Data.Entity;

namespace RecipeShare.Models
{
	public class RecipeShareDbContext : DbContext
	{
		public RecipeShareDbContext()
			: base("name=RecipeShare")
		{
		}

		public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }

		public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

		public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

		public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

		public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

		public virtual DbSet<RecipeModel.RecipeCategory> RecipeCategories { get; set; }

		public virtual DbSet<RecipeModel.Instruction> Instructions { get; set; }

		public virtual DbSet<RecipeModel.Recipe> Recipes  { get; set; }

		public virtual DbSet<RecipeModel.Ingredient> Ingredients { get; set; }

		public virtual DbSet<FoodModel.Food> Foods { get; set; }

		public virtual DbSet<FoodModel.FoodGroup> FoodGroups { get; set; }

		public virtual DbSet<GroupModel.RecipeGroup> RecipeGroups  { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<AspNetRole>()
				.HasMany(e => e.AspNetUsers)
				.WithMany(e => e.AspNetRoles)
				.Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

			modelBuilder.Entity<AspNetUser>()
				.HasMany(e => e.AspNetUserClaims)
				.WithRequired(e => e.AspNetUser)
				.HasForeignKey(e => e.UserId);

			modelBuilder.Entity<AspNetUser>()
				.HasMany(e => e.AspNetUserLogins)
				.WithRequired(e => e.AspNetUser)
				.HasForeignKey(e => e.UserId);

		}
	}
}