using System.Collections;
using System.Collections.Generic;
using RecipeShare.App_Code;

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


        }
    }
}
