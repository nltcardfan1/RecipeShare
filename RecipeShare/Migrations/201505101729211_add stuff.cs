namespace RecipeShare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addstuff : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "AspNetUser_Id", c => c.Int());
            CreateIndex("dbo.Recipes", "AspNetUser_Id");
            AddForeignKey("dbo.Recipes", "AspNetUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recipes", "AspNetUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Recipes", new[] { "AspNetUser_Id" });
            DropColumn("dbo.Recipes", "AspNetUser_Id");
        }
    }
}
