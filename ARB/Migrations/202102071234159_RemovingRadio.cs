namespace ARB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovingRadio : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tests", "Radio");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tests", "Radio", c => c.String());
        }
    }
}
