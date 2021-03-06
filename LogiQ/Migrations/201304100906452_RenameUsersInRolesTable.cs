namespace LogiQ.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameUsersInRolesTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UsersInRoles", newName: "webpages_UsersInRoles");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.webpages_UsersInRoles", newName: "UsersInRoles");
        }
    }
}
