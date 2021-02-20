namespace ARB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editClinical : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MassSpecifications", "ClinicalInfo_Id", c => c.Int());
            CreateIndex("dbo.MassSpecifications", "ClinicalInfo_Id");
            AddForeignKey("dbo.MassSpecifications", "ClinicalInfo_Id", "dbo.ClinicalInfoes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MassSpecifications", "ClinicalInfo_Id", "dbo.ClinicalInfoes");
            DropIndex("dbo.MassSpecifications", new[] { "ClinicalInfo_Id" });
            DropColumn("dbo.MassSpecifications", "ClinicalInfo_Id");
        }
    }
}
