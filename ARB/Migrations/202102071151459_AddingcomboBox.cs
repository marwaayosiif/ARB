namespace ARB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingcomboBox : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.comboes", newName: "ComboBoxes");
            RenameColumn(table: "dbo.tests", name: "ComboId", newName: "ComboBoxId");
            RenameIndex(table: "dbo.tests", name: "IX_ComboId", newName: "IX_ComboBoxId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.tests", name: "IX_ComboBoxId", newName: "IX_ComboId");
            RenameColumn(table: "dbo.tests", name: "ComboBoxId", newName: "ComboId");
            RenameTable(name: "dbo.ComboBoxes", newName: "comboes");
        }
    }
}
