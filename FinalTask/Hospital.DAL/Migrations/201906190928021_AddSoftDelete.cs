namespace Hospital.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSoftDelete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Doctors", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Doctors", new[] { "ApplicationUserId" });
            DropColumn("dbo.Doctors", "ApplicationUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Doctors", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Doctors", "ApplicationUserId");
            AddForeignKey("dbo.Doctors", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
    }
}
