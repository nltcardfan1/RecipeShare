namespace RecipeShare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecipeCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RecipeCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RecipeCategories");
        }
    }
}
