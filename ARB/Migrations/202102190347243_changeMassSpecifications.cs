namespace ARB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeMassSpecifications : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MassSpecifications", "ClockFaceId", "dbo.ClockFaces");
            DropForeignKey("dbo.MassSpecifications", "MassDensityId", "dbo.MassDensities");
            DropForeignKey("dbo.MassSpecifications", "MassMarginId", "dbo.MassMargins");
            DropForeignKey("dbo.MassSpecifications", "QuadrantId", "dbo.Quadrants");
            DropForeignKey("dbo.MassSpecifications", "ClinicalInfo_Id", "dbo.ClinicalInfoes");
            DropIndex("dbo.MassSpecifications", new[] { "MassMarginId" });
            DropIndex("dbo.MassSpecifications", new[] { "MassDensityId" });
            DropIndex("dbo.MassSpecifications", new[] { "QuadrantId" });
            DropIndex("dbo.MassSpecifications", new[] { "ClockFaceId" });
            DropIndex("dbo.MassSpecifications", new[] { "ClinicalInfo_Id" });
            DropTable("dbo.MassSpecifications");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.MassSpecifications", "ClinicalInfo_Id");
            CreateIndex("dbo.MassSpecifications", "ClockFaceId");
            CreateIndex("dbo.MassSpecifications", "QuadrantId");
            CreateIndex("dbo.MassSpecifications", "MassDensityId");
            CreateIndex("dbo.MassSpecifications", "MassMarginId");
            AddForeignKey("dbo.MassSpecifications", "ClinicalInfo_Id", "dbo.ClinicalInfoes", "Id");
            AddForeignKey("dbo.MassSpecifications", "QuadrantId", "dbo.Quadrants", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MassSpecifications", "MassMarginId", "dbo.MassMargins", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MassSpecifications", "MassDensityId", "dbo.MassDensities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MassSpecifications", "ClockFaceId", "dbo.ClockFaces", "Id", cascadeDelete: true);
        }
    }
}
