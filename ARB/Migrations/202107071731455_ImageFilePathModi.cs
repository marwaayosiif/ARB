namespace ARB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageFilePathModi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "FILEPATHNAME", c => c.String());
            DropColumn("dbo.Images", "filepath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Images", "filepath", c => c.String());
            DropColumn("dbo.Images", "FILEPATHNAME");
        }
    }
}
