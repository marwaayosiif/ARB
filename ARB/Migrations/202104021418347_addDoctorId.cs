namespace ARB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDoctorId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExamDatas", "DoctorId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ExamDatas", "DoctorId");
        }
    }
}
