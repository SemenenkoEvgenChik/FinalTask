namespace Hospital.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDoctorIdToTheTableMedication : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Medications", "DocotorId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Medications", "DocotorId");
        }
    }
}
