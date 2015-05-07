namespace RecipeShare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletetest : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.TestModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TestModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        fdsafdsa = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
