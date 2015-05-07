namespace RecipeShare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LotsOStuff2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ingredients", "FoodGroup_Id", "dbo.FoodGroups");
            DropIndex("dbo.Ingredients", new[] { "FoodGroup_Id" });
            AddColumn("dbo.Ingredients", "Foods_Id", c => c.Int());
            CreateIndex("dbo.Ingredients", "Foods_Id");
            AddForeignKey("dbo.Ingredients", "Foods_Id", "dbo.Foods", "Id");
            DropColumn("dbo.Ingredients", "FoodGroup_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ingredients", "FoodGroup_Id", c => c.Int());
            DropForeignKey("dbo.Ingredients", "Foods_Id", "dbo.Foods");
            DropIndex("dbo.Ingredients", new[] { "Foods_Id" });
            DropColumn("dbo.Ingredients", "Foods_Id");
            CreateIndex("dbo.Ingredients", "FoodGroup_Id");
            AddForeignKey("dbo.Ingredients", "FoodGroup_Id", "dbo.FoodGroups", "Id");
        }
    }
}
