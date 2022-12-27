namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerAndMembershiptypeRelationshipsImplemented : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            AlterColumn("dbo.MembershipTypes", "Name", c => c.String(nullable: false, maxLength: 255));
            AddForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            AlterColumn("dbo.MembershipTypes", "Name", c => c.String());
            AddForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
    }
}
