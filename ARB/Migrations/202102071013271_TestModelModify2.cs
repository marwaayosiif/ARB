namespace ARB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestModelModify2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tests", "Radio", c => c.String());
            AddColumn("dbo.tests", "Combo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tests", "Combo");
            DropColumn("dbo.tests", "Radio");
        }
    }
}
