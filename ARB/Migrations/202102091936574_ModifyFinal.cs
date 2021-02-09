namespace ARB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyFinal : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.FinalAssessments", new[] { "BiradsId" });
            CreateIndex("dbo.FinalAssessments", "BiRadsId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.FinalAssessments", new[] { "BiRadsId" });
            CreateIndex("dbo.FinalAssessments", "BiradsId");
        }
    }
}
