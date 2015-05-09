namespace RecipeShare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class loggingupdatenameindb : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.LoggerModels", newName: "Logs");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Logs", newName: "LoggerModels");
        }
    }
}
