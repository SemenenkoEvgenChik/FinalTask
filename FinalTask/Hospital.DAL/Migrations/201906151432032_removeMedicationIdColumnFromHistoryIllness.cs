namespace Hospital.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeMedicationIdColumnFromHistoryIllness : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.HistoryIllnesses", "MedicationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HistoryIllnesses", "MedicationId", c => c.Int(nullable: false));
        }
    }
}
