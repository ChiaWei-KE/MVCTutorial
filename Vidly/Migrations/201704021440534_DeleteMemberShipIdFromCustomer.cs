namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteMemberShipIdFromCustomer : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "MembershipId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "MembershipId", c => c.Byte(nullable: false));
        }
    }
}
