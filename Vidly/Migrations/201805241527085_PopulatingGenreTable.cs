using System.Web.UI.WebControls;

namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatingGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Genres Values('Action')");
            Sql("Insert into Genres Values('Comedy')");
            Sql("Insert into Genres Values('Family')");
            Sql("Insert into Genres Values('Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
