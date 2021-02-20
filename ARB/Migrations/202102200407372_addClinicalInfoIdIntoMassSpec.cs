namespace ARB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addClinicalInfoIdIntoMassSpec : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MassSpecifications", "ClinicalInfo_Id", "dbo.ClinicalInfoes");
            DropIndex("dbo.MassSpecifications", new[] { "ClinicalInfo_Id" });
            RenameColumn(table: "dbo.MassSpecifications", name: "ClinicalInfo_Id", newName: "ClinicalInfoId");
            AlterColumn("dbo.MassSpecifications", "ClinicalInfoId", c => c.Int(nullable: false));
            CreateIndex("dbo.MassSpecifications", "ClinicalInfoId");
            AddForeignKey("dbo.MassSpecifications", "ClinicalInfoId", "dbo.ClinicalInfoes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MassSpecifications", "ClinicalInfoId", "dbo.ClinicalInfoes");
            DropIndex("dbo.MassSpecifications", new[] { "ClinicalInfoId" });
            AlterColumn("dbo.MassSpecifications", "ClinicalInfoId", c => c.Int());
            RenameColumn(table: "dbo.MassSpecifications", name: "ClinicalInfoId", newName: "ClinicalInfo_Id");
            CreateIndex("dbo.MassSpecifications", "ClinicalInfo_Id");
            AddForeignKey("dbo.MassSpecifications", "ClinicalInfo_Id", "dbo.ClinicalInfoes", "Id");
        }
    }
}
