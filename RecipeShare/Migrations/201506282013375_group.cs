namespace RecipeShare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class group : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropPrimaryKey("dbo.AspNetRoles");
            DropPrimaryKey("dbo.AspNetUserRoles");
            AlterColumn("dbo.AspNetRoles", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.AspNetUserRoles", "RoleId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.AspNetRoles", "Id");
            AddPrimaryKey("dbo.AspNetUserRoles", new[] { "RoleId", "UserId" });
            CreateIndex("dbo.AspNetUserRoles", "RoleId");
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropPrimaryKey("dbo.AspNetUserRoles");
            DropPrimaryKey("dbo.AspNetRoles");
            AlterColumn("dbo.AspNetUserRoles", "RoleId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AspNetRoles", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.AspNetUserRoles", new[] { "RoleId", "UserId" });
            AddPrimaryKey("dbo.AspNetRoles", "Id");
            CreateIndex("dbo.AspNetUserRoles", "RoleId");
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
        }
    }
}
