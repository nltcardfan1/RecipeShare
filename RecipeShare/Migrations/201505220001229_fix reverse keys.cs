namespace RecipeShare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixreversekeys : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.RecipeGroupUsers", name: "AspNetUserId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.RecipeGroupUsers", name: "RecipeGroupId", newName: "AspNetUserId");
            RenameColumn(table: "dbo.RecipeGroupUsers", name: "__mig_tmp__0", newName: "RecipeGroupId");
            RenameIndex(table: "dbo.RecipeGroupUsers", name: "IX_AspNetUserId", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.RecipeGroupUsers", name: "IX_RecipeGroupId", newName: "IX_AspNetUserId");
            RenameIndex(table: "dbo.RecipeGroupUsers", name: "__mig_tmp__0", newName: "IX_RecipeGroupId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.RecipeGroupUsers", name: "IX_RecipeGroupId", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.RecipeGroupUsers", name: "IX_AspNetUserId", newName: "IX_RecipeGroupId");
            RenameIndex(table: "dbo.RecipeGroupUsers", name: "__mig_tmp__0", newName: "IX_AspNetUserId");
            RenameColumn(table: "dbo.RecipeGroupUsers", name: "RecipeGroupId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.RecipeGroupUsers", name: "AspNetUserId", newName: "RecipeGroupId");
            RenameColumn(table: "dbo.RecipeGroupUsers", name: "__mig_tmp__0", newName: "AspNetUserId");
        }
    }
}
