namespace ARB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDataIntoClinicalInfo : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Asymmetries (Name) VALUES ('Asymmetry')");
            Sql("INSERT INTO Asymmetries (Name) VALUES ('Global asymmetry')");
            Sql("INSERT INTO Asymmetries (Name) VALUES ('Focal asymmetry')");
            Sql("INSERT INTO Asymmetries (Name) VALUES ('Developing asymmetry')");
            
            Sql("INSERT INTO MassMargins (Name) VALUES ('Circumscribed')");
            Sql("INSERT INTO MassMargins (Name) VALUES ('Microlobulated')");
            Sql("INSERT INTO MassMargins (Name) VALUES ('Indistinct')");
            Sql("INSERT INTO MassMargins (Name) VALUES ('Spiculated')");

            



            Sql("INSERT INTO MassDensities (Name) VALUES ('High density')");
            Sql("INSERT INTO MassDensities (Name) VALUES ('Equal density')");
            Sql("INSERT INTO MassDensities (Name) VALUES ('Low density')");
            Sql("INSERT INTO MassDensities (Name) VALUES ('Fat-containing')");


            Sql("INSERT INTO Quadrants (Name) VALUES ('Upper inner')");
            Sql("INSERT INTO Quadrants (Name) VALUES ('Lower inner')");
            Sql("INSERT INTO Quadrants (Name) VALUES ('Central')");
            Sql("INSERT INTO Quadrants (Name) VALUES ('Upper outer')");
            Sql("INSERT INTO Quadrants (Name) VALUES ('Lower outer')");




            Sql("INSERT INTO ClockFaces (Name) VALUES (1)");
            Sql("INSERT INTO ClockFaces (Name) VALUES (2)");
            Sql("INSERT INTO ClockFaces (Name) VALUES (3)");
            Sql("INSERT INTO ClockFaces (Name) VALUES (4)");
            Sql("INSERT INTO ClockFaces (Name) VALUES (5)");
            Sql("INSERT INTO ClockFaces (Name) VALUES (6)");
            Sql("INSERT INTO ClockFaces (Name) VALUES (7)");
            Sql("INSERT INTO ClockFaces (Name) VALUES (8)");
            Sql("INSERT INTO ClockFaces (Name) VALUES (9)");
            Sql("INSERT INTO ClockFaces (Name) VALUES (10)");
            Sql("INSERT INTO ClockFaces (Name) VALUES (11)");
            Sql("INSERT INTO ClockFaces (Name) VALUES (12)");
            
            Sql("INSERT INTO ClacificationTypicallyBenigns (Name) VALUES ('Skin')");
            Sql("INSERT INTO ClacificationTypicallyBenigns (Name) VALUES ('Coarse or “popcorn-like”')");
            Sql("INSERT INTO ClacificationTypicallyBenigns (Name) VALUES ('Large')");
            Sql("INSERT INTO ClacificationTypicallyBenigns (Name) VALUES ('rod-like')");
            Sql("INSERT INTO ClacificationTypicallyBenigns (Name) VALUES ('Round')");
            Sql("INSERT INTO ClacificationTypicallyBenigns (Name) VALUES ('Rim')");
            Sql("INSERT INTO ClacificationTypicallyBenigns (Name) VALUES ('Dystrophic')");
            Sql("INSERT INTO ClacificationTypicallyBenigns (Name) VALUES ('Milk of calcium Suture')");


        
            Sql("INSERT INTO ClacificationSuspiciousMorphologies (Name) VALUES ('Amorphous')");
            Sql("INSERT INTO ClacificationSuspiciousMorphologies (Name) VALUES ('Coarse heterogeneous')");
            Sql("INSERT INTO ClacificationSuspiciousMorphologies (Name) VALUES ('Fine pleomorphic')");
            Sql("INSERT INTO ClacificationSuspiciousMorphologies (Name) VALUES ('Fine linear or fine-linear branching')");
            
            Sql("INSERT INTO ClacificationDistributions (Name) VALUES ('Diffuse')");
            Sql("INSERT INTO ClacificationDistributions (Name) VALUES ('Regional')");
            Sql("INSERT INTO ClacificationDistributions (Name) VALUES ('Grouped')");
            Sql("INSERT INTO ClacificationDistributions (Name) VALUES ('Linear')");
            Sql("INSERT INTO ClacificationDistributions (Name) VALUES ('Segmental')");
            










        }

        public override void Down()
        {
        }
    }
}
