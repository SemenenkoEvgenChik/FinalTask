namespace Hospital.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTableMedication : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Medications", "Operations", c => c.String());
            AddColumn("dbo.Medications", "Procedures", c => c.String());
            AddColumn("dbo.Medications", "ProceduresDescription", c => c.String());
            DropColumn("dbo.Medications", "Appointment");
            DropColumn("dbo.Medications", "DestinationDescription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Medications", "DestinationDescription", c => c.String());
            AddColumn("dbo.Medications", "Appointment", c => c.String());
            DropColumn("dbo.Medications", "ProceduresDescription");
            DropColumn("dbo.Medications", "Procedures");
            DropColumn("dbo.Medications", "Operations");
        }
    }
}
