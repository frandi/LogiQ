namespace LogiQ.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameUsersTable : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.webpages_UsersInRoles", "UserId", "dbo.Users");
            //DropForeignKey("dbo.webpages_UsersInRoles", "RoleId", "dbo.webpages_Roles");
            DropIndex("dbo.webpages_UsersInRoles", new[] { "UserId" });
            DropIndex("dbo.webpages_UsersInRoles", new[] { "RoleId" });
            DropTable("dbo.webpages_UsersInRoles");

            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.webpages_UsersInRoles",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.UserProfile", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.webpages_Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            DropTable("dbo.Users");
            
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.webpages_UsersInRoles",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId });
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            DropIndex("dbo.webpages_UsersInRoles", new[] { "RoleId" });
            DropIndex("dbo.webpages_UsersInRoles", new[] { "UserId" });
            DropForeignKey("dbo.webpages_UsersInRoles", "RoleId", "dbo.webpages_Roles");
            DropForeignKey("dbo.webpages_UsersInRoles", "UserId", "dbo.UserProfile");
            DropTable("dbo.webpages_UsersInRoles");
            DropTable("dbo.UserProfile");
            CreateIndex("dbo.webpages_UsersInRoles", "RoleId");
            CreateIndex("dbo.webpages_UsersInRoles", "UserId");
            AddForeignKey("dbo.webpages_UsersInRoles", "RoleId", "dbo.webpages_Roles", "RoleId", cascadeDelete: true);
            AddForeignKey("dbo.webpages_UsersInRoles", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
    }
}
