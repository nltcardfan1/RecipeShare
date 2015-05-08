namespace RecipeShare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class workmaybe : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RecipeGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AdminId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "RecipeGroup_Id", c => c.Int());
            AddColumn("dbo.Recipes", "RecipeGroup_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "RecipeGroup_Id");
            CreateIndex("dbo.Recipes", "RecipeGroup_Id");
            AddForeignKey("dbo.AspNetUsers", "RecipeGroup_Id", "dbo.RecipeGroups", "Id");
            AddForeignKey("dbo.Recipes", "RecipeGroup_Id", "dbo.RecipeGroups", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recipes", "RecipeGroup_Id", "dbo.RecipeGroups");
            DropForeignKey("dbo.AspNetUsers", "RecipeGroup_Id", "dbo.RecipeGroups");
            DropIndex("dbo.Recipes", new[] { "RecipeGroup_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "RecipeGroup_Id" });
            DropColumn("dbo.Recipes", "RecipeGroup_Id");
            DropColumn("dbo.AspNetUsers", "RecipeGroup_Id");
            DropTable("dbo.RecipeGroups");
        }
    }
}
