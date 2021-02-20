namespace ARB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMassSpecification : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ClinicalInfoes", "ClockFaceId", "dbo.ClockFaces");
            DropForeignKey("dbo.ClinicalInfoes", "MassDensityId", "dbo.MassDensities");
            DropForeignKey("dbo.ClinicalInfoes", "MassMarginId", "dbo.MassMargins");
            DropForeignKey("dbo.ClinicalInfoes", "QuadrantId", "dbo.Quadrants");
            DropIndex("dbo.ClinicalInfoes", new[] { "MassMarginId" });
            DropIndex("dbo.ClinicalInfoes", new[] { "MassDensityId" });
            DropIndex("dbo.ClinicalInfoes", new[] { "QuadrantId" });
            DropIndex("dbo.ClinicalInfoes", new[] { "ClockFaceId" });
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
            
            DropColumn("dbo.ClinicalInfoes", "MassShape");
            DropColumn("dbo.ClinicalInfoes", "MassMarginId");
            DropColumn("dbo.ClinicalInfoes", "MassDensityId");
            DropColumn("dbo.ClinicalInfoes", "Laterality");
            DropColumn("dbo.ClinicalInfoes", "QuadrantId");
            DropColumn("dbo.ClinicalInfoes", "ClockFaceId");
            DropColumn("dbo.ClinicalInfoes", "Depth");
            DropColumn("dbo.ClinicalInfoes", "DistanceFromTheNipple");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ClinicalInfoes", "DistanceFromTheNipple", c => c.String());
            AddColumn("dbo.ClinicalInfoes", "Depth", c => c.String());
            AddColumn("dbo.ClinicalInfoes", "ClockFaceId", c => c.Int(nullable: false));
            AddColumn("dbo.ClinicalInfoes", "QuadrantId", c => c.Int(nullable: false));
            AddColumn("dbo.ClinicalInfoes", "Laterality", c => c.String());
            AddColumn("dbo.ClinicalInfoes", "MassDensityId", c => c.Int(nullable: false));
            AddColumn("dbo.ClinicalInfoes", "MassMarginId", c => c.Int(nullable: false));
            AddColumn("dbo.ClinicalInfoes", "MassShape", c => c.String());
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
            CreateIndex("dbo.ClinicalInfoes", "ClockFaceId");
            CreateIndex("dbo.ClinicalInfoes", "QuadrantId");
            CreateIndex("dbo.ClinicalInfoes", "MassDensityId");
            CreateIndex("dbo.ClinicalInfoes", "MassMarginId");
            AddForeignKey("dbo.ClinicalInfoes", "QuadrantId", "dbo.Quadrants", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ClinicalInfoes", "MassMarginId", "dbo.MassMargins", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ClinicalInfoes", "MassDensityId", "dbo.MassDensities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ClinicalInfoes", "ClockFaceId", "dbo.ClockFaces", "Id", cascadeDelete: true);
        }
    }
}
