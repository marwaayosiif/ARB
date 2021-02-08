namespace ARB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditPatientModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Patients", "ClinicalInfoId", "dbo.ClinicalInfoes");
            DropForeignKey("dbo.Patients", "FinalAssessmentId", "dbo.FinalAssessments");
            DropForeignKey("dbo.Patients", "GeneralInfoId", "dbo.GeneralInfoes");
            DropIndex("dbo.Patients", new[] { "ClinicalInfoId" });
            DropIndex("dbo.Patients", new[] { "GeneralInfoId" });
            DropIndex("dbo.Patients", new[] { "FinalAssessmentId" });
            AlterColumn("dbo.Patients", "ClinicalInfoId", c => c.Int());
            AlterColumn("dbo.Patients", "GeneralInfoId", c => c.Int());
            AlterColumn("dbo.Patients", "FinalAssessmentId", c => c.Int());
            CreateIndex("dbo.Patients", "ClinicalInfoId");
            CreateIndex("dbo.Patients", "GeneralInfoId");
            CreateIndex("dbo.Patients", "FinalAssessmentId");
            AddForeignKey("dbo.Patients", "ClinicalInfoId", "dbo.ClinicalInfoes", "Id");
            AddForeignKey("dbo.Patients", "FinalAssessmentId", "dbo.FinalAssessments", "Id");
            AddForeignKey("dbo.Patients", "GeneralInfoId", "dbo.GeneralInfoes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "GeneralInfoId", "dbo.GeneralInfoes");
            DropForeignKey("dbo.Patients", "FinalAssessmentId", "dbo.FinalAssessments");
            DropForeignKey("dbo.Patients", "ClinicalInfoId", "dbo.ClinicalInfoes");
            DropIndex("dbo.Patients", new[] { "FinalAssessmentId" });
            DropIndex("dbo.Patients", new[] { "GeneralInfoId" });
            DropIndex("dbo.Patients", new[] { "ClinicalInfoId" });
            AlterColumn("dbo.Patients", "FinalAssessmentId", c => c.Int(nullable: false));
            AlterColumn("dbo.Patients", "GeneralInfoId", c => c.Int(nullable: false));
            AlterColumn("dbo.Patients", "ClinicalInfoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Patients", "FinalAssessmentId");
            CreateIndex("dbo.Patients", "GeneralInfoId");
            CreateIndex("dbo.Patients", "ClinicalInfoId");
            AddForeignKey("dbo.Patients", "GeneralInfoId", "dbo.GeneralInfoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Patients", "FinalAssessmentId", "dbo.FinalAssessments", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Patients", "ClinicalInfoId", "dbo.ClinicalInfoes", "Id", cascadeDelete: true);
        }
    }
}
