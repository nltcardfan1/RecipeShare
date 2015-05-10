namespace RecipeShare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stuff4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "AspNetUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Recipes", "AspNetUserId");
            AddForeignKey("dbo.Recipes", "AspNetUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recipes", "AspNetUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Recipes", new[] { "AspNetUserId" });
            DropColumn("dbo.Recipes", "AspNetUserId");
        }
    }
}
