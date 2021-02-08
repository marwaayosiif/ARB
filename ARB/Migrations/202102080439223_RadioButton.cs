namespace ARB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RadioButton : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tests", "Radio", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tests", "Radio");
        }
    }
}
