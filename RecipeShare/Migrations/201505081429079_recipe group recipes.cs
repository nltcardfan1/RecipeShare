namespace RecipeShare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class recipegrouprecipes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RecipeGroupRecipes",
                c => new
                    {
                        RecipeGroupId = c.Int(nullable: false),
                        RecipeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RecipeGroupId, t.RecipeId })
                .ForeignKey("dbo.RecipeGroups", t => t.RecipeGroupId, cascadeDelete: true)
                .ForeignKey("dbo.Recipes", t => t.RecipeId, cascadeDelete: true)
                .Index(t => t.RecipeGroupId)
                .Index(t => t.RecipeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecipeGroupRecipes", "RecipeId", "dbo.Recipes");
            DropForeignKey("dbo.RecipeGroupRecipes", "RecipeGroupId", "dbo.RecipeGroups");
            DropIndex("dbo.RecipeGroupRecipes", new[] { "RecipeId" });
            DropIndex("dbo.RecipeGroupRecipes", new[] { "RecipeGroupId" });
            DropTable("dbo.RecipeGroupRecipes");
        }
    }
}
