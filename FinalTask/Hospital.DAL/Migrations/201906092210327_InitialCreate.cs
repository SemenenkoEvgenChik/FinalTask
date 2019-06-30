namespace Hospital.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Expirience = c.Int(nullable: false),
                        Specialty = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HistoryIllnesses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InitialDiagnosis = c.String(),
                        ReceiptDate = c.DateTime(nullable: false),
                        FinalDiagnosis = c.String(),
                        DishargeDate = c.DateTime(nullable: false),
                        PatientId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        MedicationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.Medications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Appointment = c.String(),
                        DestinationDescription = c.String(),
                        DescriptionDate = c.DateTime(nullable: false),
                        HistoryIllnessId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HistoryIllnesses", t => t.HistoryIllnessId, cascadeDelete: true)
                .Index(t => t.HistoryIllnessId);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HistoryIllnesses", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Medications", "HistoryIllnessId", "dbo.HistoryIllnesses");
            DropForeignKey("dbo.HistoryIllnesses", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.Medications", new[] { "HistoryIllnessId" });
            DropIndex("dbo.HistoryIllnesses", new[] { "DoctorId" });
            DropIndex("dbo.HistoryIllnesses", new[] { "PatientId" });
            DropTable("dbo.Patients");
            DropTable("dbo.Medications");
            DropTable("dbo.HistoryIllnesses");
            DropTable("dbo.Doctors");
        }
    }
}
