namespace ARB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Deleting : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.tests");
        }
        
        public override void Down()
        {
            //CreateTable(
            //    "dbo.tests",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //            Number = c.Int(nullable: false),
            //            Checkbox = c.Boolean(nullable: false),
            //            Radio = c.String(),
            //            Combo = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
        }
    }
}
