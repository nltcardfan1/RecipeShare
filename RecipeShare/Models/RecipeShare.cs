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

		public DbSet<RecipeModel.RecipeCategory> RecipeCategories { get; set; }

		public DbSet<RecipeModel.Instruction> Instructions { get; set; }

		public DbSet<RecipeModel.Recipe> Recipes  { get; set; }

		public DbSet<RecipeModel.Ingredient> Ingredients { get; set; }

		//public DbSet<FoodModel.Food> Foods { get; set; }

		//public DbSet<FoodModel.FoodGroup> FoodGroups { get; set; }

		public DbSet<GroupModel.RecipeGroup> RecipeGroups  { get; set; }

		public DbSet<LogTypeLookup> LogTypeLookup { get; set; }

		public DbSet<Log> Logs { get; set; }

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

			modelBuilder.Entity<GroupModel.RecipeGroup>()
				.HasMany(x => x.AspNetUsers)
				.WithMany(x=> x.RecipeGroups)
				.Map(t => t.ToTable("RecipeGroupUsers")
					.MapLeftKey("RecipeGroupId")
					.MapRightKey("AspNetUserId"));

			modelBuilder.Entity<GroupModel.RecipeGroup>()
				.HasMany(x => x.Recipes)
				.WithMany(x => x.RecipeGroups)
				.Map(t => t.ToTable("RecipeGroupRecipes")
					.MapLeftKey("RecipeGroupId")
					.MapRightKey("RecipeId"));

			//modelBuilder.Entity<RecipeModel.Recipe>()
			//	.HasRequired(x => x.CreatedByUserId)
			//	.WithMany(x => x.Recipes)
			//	.HasForeignKey(x => x.CreatedByUserId);

		}
	}
}