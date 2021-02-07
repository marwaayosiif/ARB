namespace ARB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ComboBoxTest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.testComboes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.tests", "TestComboId", c => c.Int(nullable: false));
            CreateIndex("dbo.tests", "TestComboId");
            AddForeignKey("dbo.tests", "TestComboId", "dbo.testComboes", "Id", cascadeDelete: true);
            DropColumn("dbo.tests", "Combo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tests", "Combo", c => c.String());
            DropForeignKey("dbo.tests", "TestComboId", "dbo.testComboes");
            DropIndex("dbo.tests", new[] { "TestComboId" });
            DropColumn("dbo.tests", "TestComboId");
            DropTable("dbo.testComboes");
        }
    }
}
