namespace ARB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFeildsToDoctorTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "MobilePhone", c => c.Int());
            AddColumn("dbo.Doctors", "Specialization", c => c.String());
            AddColumn("dbo.Doctors", "Location", c => c.String());
            AddColumn("dbo.Doctors", "City", c => c.String());
            AddColumn("dbo.Doctors", "Country", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doctors", "Country");
            DropColumn("dbo.Doctors", "City");
            DropColumn("dbo.Doctors", "Location");
            DropColumn("dbo.Doctors", "Specialization");
            DropColumn("dbo.Doctors", "MobilePhone");
        }
    }
}
