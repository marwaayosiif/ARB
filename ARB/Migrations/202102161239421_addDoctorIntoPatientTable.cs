namespace ARB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDoctorIntoPatientTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Patients", "Doctor_Id", "dbo.Doctors");
            DropIndex("dbo.Patients", new[] { "Doctor_Id" });
            RenameColumn(table: "dbo.Patients", name: "Doctor_Id", newName: "DoctorId");
            AlterColumn("dbo.Patients", "DoctorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Patients", "DoctorId");
            AddForeignKey("dbo.Patients", "DoctorId", "dbo.Doctors", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.Patients", new[] { "DoctorId" });
            AlterColumn("dbo.Patients", "DoctorId", c => c.Int());
            RenameColumn(table: "dbo.Patients", name: "DoctorId", newName: "Doctor_Id");
            CreateIndex("dbo.Patients", "Doctor_Id");
            AddForeignKey("dbo.Patients", "Doctor_Id", "dbo.Doctors", "Id");
        }
    }
}
