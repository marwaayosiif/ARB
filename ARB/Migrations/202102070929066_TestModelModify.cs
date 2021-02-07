namespace ARB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestModelModify : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tests", "Number", c => c.Int(nullable: false));
            AddColumn("dbo.tests", "Checkbox", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tests", "Checkbox");
            DropColumn("dbo.tests", "Number");
        }
    }
}
