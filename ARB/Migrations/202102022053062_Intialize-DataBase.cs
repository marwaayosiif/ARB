namespace ARB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntializeDataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Asymmetries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BiRads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClacificationDistributions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClacificationSuspiciousMorphologies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClacificationTypicallyBenigns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClinicalInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BreastCompostion = c.String(),
                        NumOfMass = c.Int(nullable: false),
                        AsyId = c.Int(nullable: false),
                        FeatureId = c.Int(nullable: false),
                        MassShape = c.String(),
                        MassMarginId = c.Int(nullable: false),
                        MassDensityId = c.Int(nullable: false),
                        TypicallyBenignId = c.Int(nullable: false),
                        SuspiciousMorphologyId = c.Int(nullable: false),
                        DistributionId = c.Int(nullable: false),
                        Laterality = c.String(),
                        QuadrantId = c.Int(nullable: false),
                        ClockFaceId = c.Int(nullable: false),
                        Depth = c.String(),
                        DistanceFromTheNipple = c.String(),
                        Asymmetries_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Asymmetries", t => t.Asymmetries_Id)
                .ForeignKey("dbo.ClockFaces", t => t.ClockFaceId, cascadeDelete: true)
                .ForeignKey("dbo.ClacificationDistributions", t => t.DistributionId, cascadeDelete: true)
                .ForeignKey("dbo.Features", t => t.FeatureId, cascadeDelete: true)
                .ForeignKey("dbo.MassDensities", t => t.MassDensityId, cascadeDelete: true)
                .ForeignKey("dbo.MassMargins", t => t.MassMarginId, cascadeDelete: true)
                .ForeignKey("dbo.Quadrants", t => t.QuadrantId, cascadeDelete: true)
                .ForeignKey("dbo.ClacificationSuspiciousMorphologies", t => t.SuspiciousMorphologyId, cascadeDelete: true)
                .ForeignKey("dbo.ClacificationTypicallyBenigns", t => t.TypicallyBenignId, cascadeDelete: true)
                .Index(t => t.FeatureId)
                .Index(t => t.MassMarginId)
                .Index(t => t.MassDensityId)
                .Index(t => t.TypicallyBenignId)
                .Index(t => t.SuspiciousMorphologyId)
                .Index(t => t.DistributionId)
                .Index(t => t.QuadrantId)
                .Index(t => t.ClockFaceId)
                .Index(t => t.Asymmetries_Id);
            
            CreateTable(
                "dbo.ClockFaces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Features",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SkinRetraction = c.Boolean(nullable: false),
                        NippleRetraction = c.Boolean(nullable: false),
                        SkinThickening = c.Boolean(nullable: false),
                        ArchitecturalDistortion = c.Boolean(nullable: false),
                        IntramammaryLymphNode = c.Boolean(nullable: false),
                        SkinLesion = c.Boolean(nullable: false),
                        SolitaryDilatedDuct = c.Boolean(nullable: false),
                        TrabecularThickening = c.Boolean(nullable: false),
                        AxillaryAdenopathy = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MassDensities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MassMargins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Quadrants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Patient_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.Patient_Id)
                .Index(t => t.Patient_Id);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Modality = c.String(),
                        Status = c.String(),
                        ClinicalInfoId = c.Int(nullable: false),
                        GeneralInfoId = c.Int(nullable: false),
                        FinalAssessmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClinicalInfoes", t => t.ClinicalInfoId, cascadeDelete: true)
                .ForeignKey("dbo.FinalAssessments", t => t.FinalAssessmentId, cascadeDelete: true)
                .ForeignKey("dbo.GeneralInfoes", t => t.GeneralInfoId, cascadeDelete: true)
                .Index(t => t.ClinicalInfoId)
                .Index(t => t.GeneralInfoId)
                .Index(t => t.FinalAssessmentId);
            
            CreateTable(
                "dbo.FinalAssessments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BiradsId = c.Int(nullable: false),
                        RecommendationId = c.Int(nullable: false),
                        RecommendationText = c.String(),
                        Conc = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BiRads", t => t.BiradsId, cascadeDelete: true)
                .ForeignKey("dbo.Recommendations", t => t.RecommendationId, cascadeDelete: true)
                .Index(t => t.BiradsId)
                .Index(t => t.RecommendationId);
            
            CreateTable(
                "dbo.Recommendations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GeneralInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExamDate = c.DateTime(),
                        ExamReason = c.String(),
                        Complain = c.String(),
                        HadAMammogram = c.Boolean(nullable: false),
                        WhenHadAMammogram = c.String(),
                        WhereHadAMammogram = c.String(),
                        HistoryOfMammogram = c.String(),
                        PersonalHistoryOfBreastCancer = c.Boolean(nullable: false),
                        Mother = c.Boolean(nullable: false),
                        MotherAge = c.Int(nullable: false),
                        Sister = c.Boolean(nullable: false),
                        SisterAge = c.Int(nullable: false),
                        Daughter = c.Boolean(nullable: false),
                        DaughterAge = c.Int(nullable: false),
                        Grandmother = c.Boolean(nullable: false),
                        GrandmotherAge = c.Int(nullable: false),
                        Aunt = c.Boolean(nullable: false),
                        AuntAge = c.Int(nullable: false),
                        Cousin = c.Boolean(nullable: false),
                        CousinAge = c.Int(nullable: false),
                        TakingHormones = c.Boolean(nullable: false),
                        HowlongTakingHormones = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Doctors", "Patient_Id", "dbo.Patients");
            DropForeignKey("dbo.Patients", "GeneralInfoId", "dbo.GeneralInfoes");
            DropForeignKey("dbo.Patients", "FinalAssessmentId", "dbo.FinalAssessments");
            DropForeignKey("dbo.FinalAssessments", "RecommendationId", "dbo.Recommendations");
            DropForeignKey("dbo.FinalAssessments", "BiradsId", "dbo.BiRads");
            DropForeignKey("dbo.Patients", "ClinicalInfoId", "dbo.ClinicalInfoes");
            DropForeignKey("dbo.ClinicalInfoes", "TypicallyBenignId", "dbo.ClacificationTypicallyBenigns");
            DropForeignKey("dbo.ClinicalInfoes", "SuspiciousMorphologyId", "dbo.ClacificationSuspiciousMorphologies");
            DropForeignKey("dbo.ClinicalInfoes", "QuadrantId", "dbo.Quadrants");
            DropForeignKey("dbo.ClinicalInfoes", "MassMarginId", "dbo.MassMargins");
            DropForeignKey("dbo.ClinicalInfoes", "MassDensityId", "dbo.MassDensities");
            DropForeignKey("dbo.ClinicalInfoes", "FeatureId", "dbo.Features");
            DropForeignKey("dbo.ClinicalInfoes", "DistributionId", "dbo.ClacificationDistributions");
            DropForeignKey("dbo.ClinicalInfoes", "ClockFaceId", "dbo.ClockFaces");
            DropForeignKey("dbo.ClinicalInfoes", "Asymmetries_Id", "dbo.Asymmetries");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.FinalAssessments", new[] { "RecommendationId" });
            DropIndex("dbo.FinalAssessments", new[] { "BiradsId" });
            DropIndex("dbo.Patients", new[] { "FinalAssessmentId" });
            DropIndex("dbo.Patients", new[] { "GeneralInfoId" });
            DropIndex("dbo.Patients", new[] { "ClinicalInfoId" });
            DropIndex("dbo.Doctors", new[] { "Patient_Id" });
            DropIndex("dbo.ClinicalInfoes", new[] { "Asymmetries_Id" });
            DropIndex("dbo.ClinicalInfoes", new[] { "ClockFaceId" });
            DropIndex("dbo.ClinicalInfoes", new[] { "QuadrantId" });
            DropIndex("dbo.ClinicalInfoes", new[] { "DistributionId" });
            DropIndex("dbo.ClinicalInfoes", new[] { "SuspiciousMorphologyId" });
            DropIndex("dbo.ClinicalInfoes", new[] { "TypicallyBenignId" });
            DropIndex("dbo.ClinicalInfoes", new[] { "MassDensityId" });
            DropIndex("dbo.ClinicalInfoes", new[] { "MassMarginId" });
            DropIndex("dbo.ClinicalInfoes", new[] { "FeatureId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.GeneralInfoes");
            DropTable("dbo.Recommendations");
            DropTable("dbo.FinalAssessments");
            DropTable("dbo.Patients");
            DropTable("dbo.Doctors");
            DropTable("dbo.Quadrants");
            DropTable("dbo.MassMargins");
            DropTable("dbo.MassDensities");
            DropTable("dbo.Features");
            DropTable("dbo.ClockFaces");
            DropTable("dbo.ClinicalInfoes");
            DropTable("dbo.ClacificationTypicallyBenigns");
            DropTable("dbo.ClacificationSuspiciousMorphologies");
            DropTable("dbo.ClacificationDistributions");
            DropTable("dbo.BiRads");
            DropTable("dbo.Asymmetries");
        }
    }
}
