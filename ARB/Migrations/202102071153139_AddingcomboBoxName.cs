namespace ARB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingcomboBoxName : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO ComboBoxes (Name) VALUES ('Marwa')");
            Sql("INSERT INTO ComboBoxes (Name) VALUES ('Salma')");
            Sql("INSERT INTO ComboBoxes (Name) VALUES ('Muhamed')");
            Sql("INSERT INTO ComboBoxes (Name) VALUES ('Sarah')");
        }
        
        public override void Down()
        {
        }
    }
}
