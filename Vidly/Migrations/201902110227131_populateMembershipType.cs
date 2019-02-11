namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee,DurationInMonths, DiscountRate) VALUES (1,0,0,0)");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee,DurationInMonths, DiscountRate) VALUES (2,30,01,10)");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee,DurationInMonths, DiscountRate) VALUES (3,90,03,15)");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee,DurationInMonths, DiscountRate) VALUES (4,300,04,20)");
        }
        
        public override void Down()
        {

        }
    }
}
