namespace ARB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditReport3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reports", "TileImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reports", "TileImage");
        }
    }
}
