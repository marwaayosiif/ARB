namespace ARB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upgradeSomethngInMassSpec : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MassSpecifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MassShape = c.String(),
                        MassMarginId = c.Int(nullable: false),
                        MassDensityId = c.Int(nullable: false),
                        Laterality = c.String(),
                        QuadrantId = c.Int(nullable: false),
                        ClockFaceId = c.Int(nullable: false),
                        Depth = c.String(),
                        DistanceFromTheNipple = c.String(),
                        ClinicalInfo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClockFaces", t => t.ClockFaceId, cascadeDelete: true)
                .ForeignKey("dbo.MassDensities", t => t.MassDensityId, cascadeDelete: true)
                .ForeignKey("dbo.MassMargins", t => t.MassMarginId, cascadeDelete: true)
                .ForeignKey("dbo.Quadrants", t => t.QuadrantId, cascadeDelete: true)
                .ForeignKey("dbo.ClinicalInfoes", t => t.ClinicalInfo_Id)
                .Index(t => t.MassMarginId)
                .Index(t => t.MassDensityId)
                .Index(t => t.QuadrantId)
                .Index(t => t.ClockFaceId)
                .Index(t => t.ClinicalInfo_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MassSpecifications", "ClinicalInfo_Id", "dbo.ClinicalInfoes");
            DropForeignKey("dbo.MassSpecifications", "QuadrantId", "dbo.Quadrants");
            DropForeignKey("dbo.MassSpecifications", "MassMarginId", "dbo.MassMargins");
            DropForeignKey("dbo.MassSpecifications", "MassDensityId", "dbo.MassDensities");
            DropForeignKey("dbo.MassSpecifications", "ClockFaceId", "dbo.ClockFaces");
            DropIndex("dbo.MassSpecifications", new[] { "ClinicalInfo_Id" });
            DropIndex("dbo.MassSpecifications", new[] { "ClockFaceId" });
            DropIndex("dbo.MassSpecifications", new[] { "QuadrantId" });
            DropIndex("dbo.MassSpecifications", new[] { "MassDensityId" });
            DropIndex("dbo.MassSpecifications", new[] { "MassMarginId" });
            DropTable("dbo.MassSpecifications");
        }
    }
}
