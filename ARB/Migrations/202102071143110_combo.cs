namespace ARB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class combo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.comboes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.tests", "ComboId", c => c.Int(nullable: false));
            CreateIndex("dbo.tests", "ComboId");
            AddForeignKey("dbo.tests", "ComboId", "dbo.comboes", "Id", cascadeDelete: true);
            DropColumn("dbo.tests", "Combo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tests", "Combo", c => c.String());
            DropForeignKey("dbo.tests", "ComboId", "dbo.comboes");
            DropIndex("dbo.tests", new[] { "ComboId" });
            DropColumn("dbo.tests", "ComboId");
            DropTable("dbo.comboes");
        }
    }
}
