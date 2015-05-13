namespace RecipeShare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foodgroupsee : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FoodGroups", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FoodGroups", "Name", c => c.Int(nullable: false));
        }
    }
}
