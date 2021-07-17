namespace ARB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditReport2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reports", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reports", "Name", c => c.Int(nullable: false));
        }
    }
}
