namespace ARB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rmvExamData : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Patients", "ExamDataId", "dbo.ExamDatas");
            DropIndex("dbo.Patients", new[] { "ExamDataId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Patients", "ExamDataId");
            AddForeignKey("dbo.Patients", "ExamDataId", "dbo.ExamDatas", "Id", cascadeDelete: true);
        }
    }
}
