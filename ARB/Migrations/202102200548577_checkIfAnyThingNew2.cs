namespace ARB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class checkIfAnyThingNew2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ClinicalInfoes", "Asymmetries_Id", "dbo.Asymmetries");
            DropIndex("dbo.ClinicalInfoes", new[] { "Asymmetries_Id" });
            RenameColumn(table: "dbo.ClinicalInfoes", name: "Asymmetries_Id", newName: "AsymmetriesId");
            AlterColumn("dbo.ClinicalInfoes", "AsymmetriesId", c => c.Int(nullable: false));
            CreateIndex("dbo.ClinicalInfoes", "AsymmetriesId");
            AddForeignKey("dbo.ClinicalInfoes", "AsymmetriesId", "dbo.Asymmetries", "Id", cascadeDelete: true);
            DropColumn("dbo.ClinicalInfoes", "AsyId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ClinicalInfoes", "AsyId", c => c.Int(nullable: false));
            DropForeignKey("dbo.ClinicalInfoes", "AsymmetriesId", "dbo.Asymmetries");
            DropIndex("dbo.ClinicalInfoes", new[] { "AsymmetriesId" });
            AlterColumn("dbo.ClinicalInfoes", "AsymmetriesId", c => c.Int());
            RenameColumn(table: "dbo.ClinicalInfoes", name: "AsymmetriesId", newName: "Asymmetries_Id");
            CreateIndex("dbo.ClinicalInfoes", "Asymmetries_Id");
            AddForeignKey("dbo.ClinicalInfoes", "Asymmetries_Id", "dbo.Asymmetries", "Id");
        }
    }
}
