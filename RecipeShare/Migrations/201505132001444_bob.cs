namespace RecipeShare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bob : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FoodGroups", "Bob", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FoodGroups", "Bob");
        }
    }
}
