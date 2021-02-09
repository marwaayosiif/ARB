namespace ARB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changePatientData : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Patients", "ExamDataId", "dbo.ExamDatas");
            DropIndex("dbo.Patients", new[] { "ExamDataId" });
            DropColumn("dbo.Patients", "ExamDataId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patients", "ExamDataId", c => c.Int(nullable: false));
            CreateIndex("dbo.Patients", "ExamDataId");
            AddForeignKey("dbo.Patients", "ExamDataId", "dbo.ExamDatas", "Id", cascadeDelete: true);
        }
    }
}
