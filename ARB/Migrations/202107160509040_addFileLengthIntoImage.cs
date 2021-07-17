namespace ARB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFileLengthIntoImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "FileLength", c => c.Int());
            DropColumn("dbo.Images", "FILEPATHNAME");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Images", "FILEPATHNAME", c => c.String());
            DropColumn("dbo.Images", "FileLength");
        }
    }
}
