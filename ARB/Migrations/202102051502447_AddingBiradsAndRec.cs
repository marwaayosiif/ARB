namespace ARB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingBiradsAndRec : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO BiRads (Name) VALUES ('0')");
            Sql("INSERT INTO BiRads (Name) VALUES ('1')");
            Sql("INSERT INTO BiRads (Name) VALUES ('2')");
            Sql("INSERT INTO BiRads (Name) VALUES ('3')");
            Sql("INSERT INTO BiRads (Name) VALUES ('4')");
            Sql("INSERT INTO BiRads (Name) VALUES ('4a')");
            Sql("INSERT INTO BiRads (Name) VALUES ('4b')");
            Sql("INSERT INTO BiRads (Name) VALUES ('4c')");
            Sql("INSERT INTO BiRads (Name) VALUES ('5')");
            Sql("INSERT INTO BiRads (Name) VALUES ('6')");

         
            Sql("INSERT INTO Recommendations (Name) VALUES ('Ultrasound')");
            Sql("INSERT INTO Recommendations (Name) VALUES ('MRI')");
            Sql("INSERT INTO Recommendations (Name) VALUES ('Histology')");
            Sql("INSERT INTO Recommendations (Name) VALUES ('Stereotactic Biopsy')");
            Sql("INSERT INTO Recommendations (Name) VALUES ('Repeat imaging over 6 Months')");
            Sql("INSERT INTO Recommendations (Name) VALUES ('No further investigation necessary')");
            Sql("INSERT INTO Recommendations (Name) VALUES ('No further research necessary, return Screening')");
        }
        
        public override void Down()
        {
        }
    }
}
