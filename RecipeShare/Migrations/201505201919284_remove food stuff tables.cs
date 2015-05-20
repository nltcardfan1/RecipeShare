namespace RecipeShare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removefoodstufftables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Foods", "FoodGroupId", "dbo.FoodGroups");
            DropIndex("dbo.Foods", new[] { "FoodGroupId" });
            DropTable("dbo.FoodGroups");
            DropTable("dbo.Foods");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FoodGroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FoodGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Foods", "FoodGroupId");
            AddForeignKey("dbo.Foods", "FoodGroupId", "dbo.FoodGroups", "Id", cascadeDelete: true);
        }
    }
}
