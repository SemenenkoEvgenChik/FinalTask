namespace Hospital.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDoctorIdToTheTableMedication : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Medications", "DoctorId", c => c.Int(nullable: false));
            DropColumn("dbo.Medications", "DocotorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Medications", "DocotorId", c => c.Int(nullable: false));
            DropColumn("dbo.Medications", "DoctorId");
        }
    }
}
