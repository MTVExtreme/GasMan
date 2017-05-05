namespace GasMan.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedYear : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RetailPrice", "Year", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RetailPrice", "Year");
        }
    }
}
