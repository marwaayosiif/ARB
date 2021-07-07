namespace ARB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageFilePath : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "filepath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Images", "filepath");
        }
    }
}
