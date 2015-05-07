namespace RecipeShare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LotsOStuff : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FoodGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FoodGroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FoodGroups", t => t.FoodGroupId, cascadeDelete: true)
                .Index(t => t.FoodGroupId);
            
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RecipeId = c.Int(nullable: false),
                        Amount = c.String(),
                        FoodGroup_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FoodGroups", t => t.FoodGroup_Id)
                .Index(t => t.FoodGroup_Id);
            
            CreateTable(
                "dbo.Instructions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RecipeId = c.Int(nullable: false),
                        InstructionNumber = c.Int(nullable: false),
                        Narrative = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipes", t => t.RecipeId, cascadeDelete: true)
                .Index(t => t.RecipeId);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Serves = c.Int(),
                        PrepTimeMinutes = c.Int(),
                        CookTimeMinutes = c.Int(),
                        RecipeCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RecipeCategories", t => t.RecipeCategory_Id)
                .Index(t => t.RecipeCategory_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recipes", "RecipeCategory_Id", "dbo.RecipeCategories");
            DropForeignKey("dbo.Instructions", "RecipeId", "dbo.Recipes");
            DropForeignKey("dbo.Ingredients", "FoodGroup_Id", "dbo.FoodGroups");
            DropForeignKey("dbo.Foods", "FoodGroupId", "dbo.FoodGroups");
            DropIndex("dbo.Recipes", new[] { "RecipeCategory_Id" });
            DropIndex("dbo.Instructions", new[] { "RecipeId" });
            DropIndex("dbo.Ingredients", new[] { "FoodGroup_Id" });
            DropIndex("dbo.Foods", new[] { "FoodGroupId" });
            DropTable("dbo.Recipes");
            DropTable("dbo.Instructions");
            DropTable("dbo.Ingredients");
            DropTable("dbo.Foods");
            DropTable("dbo.FoodGroups");
        }
    }
}
