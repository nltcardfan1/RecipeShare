namespace RecipeShare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addrecipegrouprelationship : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RecipeGroupUsers",
                c => new
                    {
                        AspNetUserId = c.Int(nullable: false),
                        RecipeGroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AspNetUserId, t.RecipeGroupId })
                .ForeignKey("dbo.RecipeGroups", t => t.AspNetUserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.RecipeGroupId, cascadeDelete: true)
                .Index(t => t.AspNetUserId)
                .Index(t => t.RecipeGroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecipeGroupUsers", "RecipeGroupId", "dbo.AspNetUsers");
            DropForeignKey("dbo.RecipeGroupUsers", "AspNetUserId", "dbo.RecipeGroups");
            DropIndex("dbo.RecipeGroupUsers", new[] { "RecipeGroupId" });
            DropIndex("dbo.RecipeGroupUsers", new[] { "AspNetUserId" });
            DropTable("dbo.RecipeGroupUsers");
        }
    }
}
