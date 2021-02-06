namespace ARB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editDoctorDatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Doctors", "Patient_Id", "dbo.Patients");
            DropIndex("dbo.Doctors", new[] { "Patient_Id" });
            AddColumn("dbo.Patients", "Doctor_Id", c => c.Int());
            CreateIndex("dbo.Patients", "Doctor_Id");
            AddForeignKey("dbo.Patients", "Doctor_Id", "dbo.Doctors", "Id");
            DropColumn("dbo.Doctors", "Patient_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Doctors", "Patient_Id", c => c.Int());
            DropForeignKey("dbo.Patients", "Doctor_Id", "dbo.Doctors");
            DropIndex("dbo.Patients", new[] { "Doctor_Id" });
            DropColumn("dbo.Patients", "Doctor_Id");
            CreateIndex("dbo.Doctors", "Patient_Id");
            AddForeignKey("dbo.Doctors", "Patient_Id", "dbo.Patients", "Id");
        }
    }
}
