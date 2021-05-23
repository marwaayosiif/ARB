namespace ARB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Patients", "ClinicalInfoId");
            CreateIndex("dbo.Patients", "GeneralInfoId");
            CreateIndex("dbo.Patients", "FinalAssessmentId");
            AddForeignKey("dbo.Patients", "ClinicalInfoId", "dbo.ClinicalInfoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Patients", "FinalAssessmentId", "dbo.FinalAssessments", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Patients", "GeneralInfoId", "dbo.GeneralInfoes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "GeneralInfoId", "dbo.GeneralInfoes");
            DropForeignKey("dbo.Patients", "FinalAssessmentId", "dbo.FinalAssessments");
            DropForeignKey("dbo.Patients", "ClinicalInfoId", "dbo.ClinicalInfoes");
            DropIndex("dbo.Patients", new[] { "FinalAssessmentId" });
            DropIndex("dbo.Patients", new[] { "GeneralInfoId" });
            DropIndex("dbo.Patients", new[] { "ClinicalInfoId" });
        }
    }
}
