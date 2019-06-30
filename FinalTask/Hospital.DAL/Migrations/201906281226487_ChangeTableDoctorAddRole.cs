namespace Hospital.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTableDoctorAddRole : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "Role", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doctors", "Role");
        }
    }
}
