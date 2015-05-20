namespace RecipeShare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateservestobenotint : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Recipes", "Serves", c => c.String());
            CreateIndex("dbo.Ingredients", "RecipeId");
            AddForeignKey("dbo.Ingredients", "RecipeId", "dbo.Recipes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ingredients", "RecipeId", "dbo.Recipes");
            DropIndex("dbo.Ingredients", new[] { "RecipeId" });
            AlterColumn("dbo.Recipes", "Serves", c => c.Int());
        }
    }
}
