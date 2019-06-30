namespace Hospital.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllowDatesToBeNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HistoryIllnesses", "ReceiptDate", c => c.DateTime());
            AlterColumn("dbo.HistoryIllnesses", "DishargeDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HistoryIllnesses", "DishargeDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.HistoryIllnesses", "ReceiptDate", c => c.DateTime(nullable: false));
        }
    }
}
