namespace ARB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "data", c => c.Binary());
            AlterColumn("dbo.Images", "PatientId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Images", "PatientId", c => c.Int(nullable: false));
            DropColumn("dbo.Images", "data");
        }
    }
}
