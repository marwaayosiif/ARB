namespace ARB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Delete_report : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Reports");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TileImage = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
