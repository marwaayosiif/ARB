namespace ARB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editImageData2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Images", "PatientId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Images", "PatientId", c => c.Int());
        }
    }
}
