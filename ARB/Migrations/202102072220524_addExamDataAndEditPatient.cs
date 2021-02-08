namespace ARB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addExamDataAndEditPatient : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Patients", "ClinicalInfoId", "dbo.ClinicalInfoes");
            DropForeignKey("dbo.Patients", "FinalAssessmentId", "dbo.FinalAssessments");
            DropForeignKey("dbo.Patients", "GeneralInfoId", "dbo.GeneralInfoes");
            DropIndex("dbo.Patients", new[] { "ClinicalInfoId" });
            DropIndex("dbo.Patients", new[] { "GeneralInfoId" });
            DropIndex("dbo.Patients", new[] { "FinalAssessmentId" });
            CreateTable(
                "dbo.ExamDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        EmailAddress = c.String(),
                        MobileNumber = c.String(),
                        PatientID = c.String(),
                        Address = c.String(),
                        Modailty = c.String(),
                        ReferringDoctor = c.String(),
                        StudyDate = c.DateTime(nullable: false),
                        LastOperation = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Patients", "ExamDataId", c => c.Int(nullable: false));
            AlterColumn("dbo.Patients", "ClinicalInfoId", c => c.Int(nullable: false));
            AlterColumn("dbo.Patients", "GeneralInfoId", c => c.Int(nullable: false));
            AlterColumn("dbo.Patients", "FinalAssessmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Patients", "ExamDataId");
            CreateIndex("dbo.Patients", "ClinicalInfoId");
            CreateIndex("dbo.Patients", "GeneralInfoId");
            CreateIndex("dbo.Patients", "FinalAssessmentId");
            AddForeignKey("dbo.Patients", "ExamDataId", "dbo.ExamDatas", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Patients", "ClinicalInfoId", "dbo.ClinicalInfoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Patients", "FinalAssessmentId", "dbo.FinalAssessments", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Patients", "GeneralInfoId", "dbo.GeneralInfoes", "Id", cascadeDelete: true);
            DropColumn("dbo.Patients", "Name");
            DropColumn("dbo.Patients", "BirthDate");
            DropColumn("dbo.Patients", "Modality");
            DropColumn("dbo.Patients", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patients", "Status", c => c.String());
            AddColumn("dbo.Patients", "Modality", c => c.String());
            AddColumn("dbo.Patients", "BirthDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Patients", "Name", c => c.String());
            DropForeignKey("dbo.Patients", "GeneralInfoId", "dbo.GeneralInfoes");
            DropForeignKey("dbo.Patients", "FinalAssessmentId", "dbo.FinalAssessments");
            DropForeignKey("dbo.Patients", "ClinicalInfoId", "dbo.ClinicalInfoes");
            DropForeignKey("dbo.Patients", "ExamDataId", "dbo.ExamDatas");
            DropIndex("dbo.Patients", new[] { "FinalAssessmentId" });
            DropIndex("dbo.Patients", new[] { "GeneralInfoId" });
            DropIndex("dbo.Patients", new[] { "ClinicalInfoId" });
            DropIndex("dbo.Patients", new[] { "ExamDataId" });
            AlterColumn("dbo.Patients", "FinalAssessmentId", c => c.Int());
            AlterColumn("dbo.Patients", "GeneralInfoId", c => c.Int());
            AlterColumn("dbo.Patients", "ClinicalInfoId", c => c.Int());
            DropColumn("dbo.Patients", "ExamDataId");
            DropTable("dbo.ExamDatas");
            CreateIndex("dbo.Patients", "FinalAssessmentId");
            CreateIndex("dbo.Patients", "GeneralInfoId");
            CreateIndex("dbo.Patients", "ClinicalInfoId");
            AddForeignKey("dbo.Patients", "GeneralInfoId", "dbo.GeneralInfoes", "Id");
            AddForeignKey("dbo.Patients", "FinalAssessmentId", "dbo.FinalAssessments", "Id");
            AddForeignKey("dbo.Patients", "ClinicalInfoId", "dbo.ClinicalInfoes", "Id");
        }
    }
}
