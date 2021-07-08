namespace ARB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class patientIdAddToImages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "PatientId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Images", "PatientId");
        }
    }
}
