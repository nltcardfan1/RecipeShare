namespace RecipeShare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addstuff1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Recipes", "CreatedByUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Recipes", new[] { "CreatedByUserId" });
            //DropColumn("dbo.Recipes", "CreatedByUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recipes", "CreatedByUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Recipes", "CreatedByUserId");
            AddForeignKey("dbo.Recipes", "CreatedByUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
