namespace RecipeShare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tfdsafd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
			DropTable("dbo.AspNetRoles");
			DropTable("dbo.AspNetUserRoles");
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
			//CreateTable(
			//	"dbo.__MigrationHistory",
			//	c => new
			//		{
			//			MigrationId = c.String(nullable: false, maxLength: 150),
			//			ContextKey = c.String(nullable: false, maxLength: 300),
			//			Model = c.Binary(nullable: false),
			//			ProductVersion = c.String(nullable: false, maxLength: 32),
			//		})
			//	.PrimaryKey(t => new { t.MigrationId, t.ContextKey });
            
            CreateTable(
                "dbo.TestModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        fdsafdsa = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true);
            
            AlterColumn("dbo.AspNetUsers", "FirstName", c => c.String(maxLength: 50));
            AlterColumn("dbo.AspNetUsers", "LastName", c => c.String(maxLength: 50));

        }
        
        public override void Down()
        {
			DropForeignKey("dbo.AspNetUserRoles","UserId","dbo.AspNetUsers");
			DropForeignKey("dbo.AspNetUserRoles","RoleId","dbo.AspNetRoles");
			AlterColumn("dbo.AspNetUsers","LastName",c => c.String());
			AlterColumn("dbo.AspNetUsers","FirstName",c => c.String());
			DropTable("dbo.AspNetUserRoles");
			DropTable("dbo.TestModels");
			DropTable("dbo.__MigrationHistory");
			DropTable("dbo.AspNetRoles");
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId });
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            

            CreateIndex("dbo.AspNetUsers", "UserName", unique: true, name: "UserNameIndex");
            CreateIndex("dbo.AspNetRoles", "Name", unique: true, name: "RoleNameIndex");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
        }
    }
}
