namespace Hospital.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNavigationProrertyToTheMedicationTable : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Medications", "DoctorId");
            AddForeignKey("dbo.Medications", "DoctorId", "dbo.Doctors", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Medications", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.Medications", new[] { "DoctorId" });
        }
    }
}
