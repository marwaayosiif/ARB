namespace ARB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditReport : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Reports", "ContentType");
            DropColumn("dbo.Reports", "Data");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reports", "Data", c => c.Int(nullable: false));
            AddColumn("dbo.Reports", "ContentType", c => c.Int(nullable: false));
        }
    }
}
