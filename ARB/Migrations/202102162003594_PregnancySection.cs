namespace ARB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PregnancySection : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GeneralInfoes", "ModalityType", c => c.String());
            AddColumn("dbo.GeneralInfoes", "Menopause", c => c.Boolean(nullable: false));
            AddColumn("dbo.GeneralInfoes", "Pregnant", c => c.Boolean(nullable: false));
            AddColumn("dbo.GeneralInfoes", "Gravida", c => c.Int(nullable: false));
            AddColumn("dbo.GeneralInfoes", "Para", c => c.Int(nullable: false));
            AddColumn("dbo.GeneralInfoes", "LMP", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.GeneralInfoes", "LMP");
            DropColumn("dbo.GeneralInfoes", "Para");
            DropColumn("dbo.GeneralInfoes", "Gravida");
            DropColumn("dbo.GeneralInfoes", "Pregnant");
            DropColumn("dbo.GeneralInfoes", "Menopause");
            DropColumn("dbo.GeneralInfoes", "ModalityType");
        }
    }
}
