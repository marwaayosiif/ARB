namespace ARB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editPatient : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Patients", "ClinicalInfoId", "dbo.ClinicalInfoes");
            DropForeignKey("dbo.Patients", "FinalAssessmentId", "dbo.FinalAssessments");
            DropForeignKey("dbo.Patients", "GeneralInfoId", "dbo.GeneralInfoes");
            DropIndex("dbo.Patients", new[] { "ClinicalInfoId" });
            DropIndex("dbo.Patients", new[] { "GeneralInfoId" });
            DropIndex("dbo.Patients", new[] { "FinalAssessmentId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Patients", "FinalAssessmentId");
            CreateIndex("dbo.Patients", "GeneralInfoId");
            CreateIndex("dbo.Patients", "ClinicalInfoId");
            AddForeignKey("dbo.Patients", "GeneralInfoId", "dbo.GeneralInfoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Patients", "FinalAssessmentId", "dbo.FinalAssessments", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Patients", "ClinicalInfoId", "dbo.ClinicalInfoes", "Id", cascadeDelete: true);
        }
    }
}
