namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerandMovieNameMaxlength255 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "SignUpFee", c => c.Short(nullable: false));
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.MembershipTypes", "SighUpFee");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MembershipTypes", "SighUpFee", c => c.Short(nullable: false));
            AlterColumn("dbo.Movies", "Name", c => c.String());
            AlterColumn("dbo.Customers", "Name", c => c.String());
            DropColumn("dbo.MembershipTypes", "SignUpFee");
        }
    }
}
