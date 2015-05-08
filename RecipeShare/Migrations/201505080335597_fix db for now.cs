namespace RecipeShare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixdbfornow : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "RecipeGroup_Id", "dbo.RecipeGroups");
            DropForeignKey("dbo.Recipes", "RecipeGroup_Id", "dbo.RecipeGroups");
            DropIndex("dbo.AspNetUsers", new[] { "RecipeGroup_Id" });
            DropIndex("dbo.Recipes", new[] { "RecipeGroup_Id" });
            DropColumn("dbo.AspNetUsers", "RecipeGroup_Id");
            DropColumn("dbo.Recipes", "RecipeGroup_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recipes", "RecipeGroup_Id", c => c.Int());
            AddColumn("dbo.AspNetUsers", "RecipeGroup_Id", c => c.Int());
            CreateIndex("dbo.Recipes", "RecipeGroup_Id");
            CreateIndex("dbo.AspNetUsers", "RecipeGroup_Id");
            AddForeignKey("dbo.Recipes", "RecipeGroup_Id", "dbo.RecipeGroups", "Id");
            AddForeignKey("dbo.AspNetUsers", "RecipeGroup_Id", "dbo.RecipeGroups", "Id");
        }
    }
}
