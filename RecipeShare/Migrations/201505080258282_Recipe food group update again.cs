namespace RecipeShare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Recipefoodgroupupdateagain : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ingredients", "FoodGroup_Id", "dbo.FoodGroups");
            DropIndex("dbo.Ingredients", new[] { "FoodGroup_Id" });
            CreateIndex("dbo.Ingredients", "FoodId");
            AddForeignKey("dbo.Ingredients", "FoodId", "dbo.Foods", "Id", cascadeDelete: true);
            DropColumn("dbo.Ingredients", "FoodGroup_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ingredients", "FoodGroup_Id", c => c.Int());
            DropForeignKey("dbo.Ingredients", "FoodId", "dbo.Foods");
            DropIndex("dbo.Ingredients", new[] { "FoodId" });
            CreateIndex("dbo.Ingredients", "FoodGroup_Id");
            AddForeignKey("dbo.Ingredients", "FoodGroup_Id", "dbo.FoodGroups", "Id");
        }
    }
}
