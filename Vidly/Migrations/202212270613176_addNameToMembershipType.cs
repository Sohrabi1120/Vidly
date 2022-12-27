﻿namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNameToMembershipType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "Name", c => c.String());
            Sql("update membershiptypes set Name=N'Pay as You Go' where Id = 1");
            Sql("update membershiptypes set Name=N'Monthly' where Id = 2");
            Sql("update membershiptypes set Name=N'Quarterly' where Id = 3");
            Sql("update membershiptypes set Name=N'Anualy' where Id = 4");
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "Name");
        }
    }
}
