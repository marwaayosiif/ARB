namespace ARB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class improveMass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MassSpecifications", "orderId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MassSpecifications", "orderId");
        }
    }
}
