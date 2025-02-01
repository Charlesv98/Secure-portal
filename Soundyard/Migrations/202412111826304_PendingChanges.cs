namespace Soundyard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PendingChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetRoles", "Agreement", c => c.String());
            AddColumn("dbo.AspNetRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.AspNetUsers", "Agreement");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Agreement", c => c.String());
            DropColumn("dbo.AspNetRoles", "Discriminator");
            DropColumn("dbo.AspNetRoles", "Agreement");
        }
    }
}
