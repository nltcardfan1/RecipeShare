using System.Collections;
using System.Collections.Generic;
using RecipeShare.Models;

namespace RecipeShare.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

	internal sealed class Configuration:DbMigrationsConfiguration<RecipeShare.Models.RecipeShareDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

		protected override void Seed(RecipeShare.Models.RecipeShareDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

			context.LogTypeLookup.AddOrUpdate(
				x => x.Type,
				new LogTypeLookup {Id = 1, Type = "Error"},
				new LogTypeLookup {Id = 2, Type = "Information"});

			context.FoodGroups.AddOrUpdate(
				x => x.Id,
				new FoodModel.FoodGroup {Id = 1, Name = "Dairy"},
				new FoodModel.FoodGroup {Id = 2, Name = "Fruits"},
				new FoodModel.FoodGroup {Id = 3, Name = "Vegetables"},
				new FoodModel.FoodGroup {Id = 4, Name = "Grains, Beans, Legumes"},
				new FoodModel.FoodGroup {Id = 5, Name = "Protein"},
				new FoodModel.FoodGroup {Id = 6, Name = "Spices"},
				new FoodModel.FoodGroup {Id = 7, Name = "Confections"},
				new FoodModel.FoodGroup {Id = 8, Name = "Other"});

			context.Foods.AddOrUpdate(
				x => x.Id,
				new FoodModel.Food {Id = 1, FoodGroupId = 1, Name = "Milk"},
				new FoodModel.Food {Id = 2, FoodGroupId = 2, Name = "Cantelope"},
				new FoodModel.Food {Id = 3, FoodGroupId = 3, Name = "Broccoli"},
				new FoodModel.Food {Id = 4, FoodGroupId = 4, Name = "White Bread"},
				new FoodModel.Food {Id = 5, FoodGroupId = 5, Name = "Tenderloin"},
				new FoodModel.Food {Id = 6, FoodGroupId = 6, Name = "Red Pepper"},
				new FoodModel.Food {Id = 7, FoodGroupId = 7, Name = "Sugar"}
				);
			context.RecipeCategories.AddOrUpdate(
				x => x.Id,
				new RecipeModel.RecipeCategory {Id = 1, Category = "American"}
				);
        }
    }
}
