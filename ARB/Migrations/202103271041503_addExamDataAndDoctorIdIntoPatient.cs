namespace ARB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addExamDataAndDoctorIdIntoPatient : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Patients", "Doctor_Id", "dbo.Doctors");
            DropIndex("dbo.Patients", new[] { "Doctor_Id" });
            RenameColumn(table: "dbo.Patients", name: "Doctor_Id", newName: "DoctorId");
            AddColumn("dbo.Patients", "ExamDataId", c => c.Int(nullable: false));
            AlterColumn("dbo.Patients", "DoctorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Patients", "ExamDataId");
            CreateIndex("dbo.Patients", "DoctorId");
            AddForeignKey("dbo.Patients", "ExamDataId", "dbo.ExamDatas", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Patients", "DoctorId", "dbo.Doctors", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Patients", "ExamDataId", "dbo.ExamDatas");
            DropIndex("dbo.Patients", new[] { "DoctorId" });
            DropIndex("dbo.Patients", new[] { "ExamDataId" });
            AlterColumn("dbo.Patients", "DoctorId", c => c.Int());
            DropColumn("dbo.Patients", "ExamDataId");
            RenameColumn(table: "dbo.Patients", name: "DoctorId", newName: "Doctor_Id");
            CreateIndex("dbo.Patients", "Doctor_Id");
            AddForeignKey("dbo.Patients", "Doctor_Id", "dbo.Doctors", "Id");
        }
    }
}
