namespace ARB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PergnancyHistoryBoolean : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GeneralInfoes", "PergnancyHistory", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GeneralInfoes", "PergnancyHistory");
        }
    }
}
