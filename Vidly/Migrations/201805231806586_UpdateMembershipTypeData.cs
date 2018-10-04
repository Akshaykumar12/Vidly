namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipTypeData : DbMigration
    {
        public override void Up()
        {
            Sql("Update MembershipTypes set Name='Pay as you Go' Where Id=1");
            Sql("Update MembershipTypes set Name='Silver' Where Id=2");
            Sql("Update MembershipTypes set Name='Gold' Where Id=3");
            Sql("Update MembershipTypes set Name='Platinum' Where Id=4");
        }
        
        public override void Down()
        {
        }
    }
}
