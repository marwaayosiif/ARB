namespace ARB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class patientRmvDoc : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Patients", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.Patients", new[] { "DoctorId" });
            RenameColumn(table: "dbo.Patients", name: "DoctorId", newName: "Doctor_Id");
            AlterColumn("dbo.Patients", "Doctor_Id", c => c.Int());
            CreateIndex("dbo.Patients", "Doctor_Id");
            AddForeignKey("dbo.Patients", "Doctor_Id", "dbo.Doctors", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "Doctor_Id", "dbo.Doctors");
            DropIndex("dbo.Patients", new[] { "Doctor_Id" });
            AlterColumn("dbo.Patients", "Doctor_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Patients", name: "Doctor_Id", newName: "DoctorId");
            CreateIndex("dbo.Patients", "DoctorId");
            AddForeignKey("dbo.Patients", "DoctorId", "dbo.Doctors", "Id", cascadeDelete: true);
        }
    }
}
