namespace RecipeShare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removefoodstuff : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ingredients", "FoodId", "dbo.Foods");
            DropIndex("dbo.Ingredients", new[] { "FoodId" });
            AddColumn("dbo.Ingredients", "Food", c => c.String());
            DropColumn("dbo.Ingredients", "FoodId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ingredients", "FoodId", c => c.Int(nullable: false));
            DropColumn("dbo.Ingredients", "Food");
            CreateIndex("dbo.Ingredients", "FoodId");
            AddForeignKey("dbo.Ingredients", "FoodId", "dbo.Foods", "Id", cascadeDelete: true);
        }
    }
}
