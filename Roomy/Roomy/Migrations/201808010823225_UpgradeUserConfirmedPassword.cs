namespace Roomy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpgradeUserConfirmedPassword : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "IsMail");
            DropColumn("dbo.Users", "ConfirmedPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "ConfirmedPassword", c => c.String());
            AddColumn("dbo.Users", "IsMail", c => c.Boolean(nullable: false));
        }
    }
}
