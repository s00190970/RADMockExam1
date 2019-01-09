namespace Exam1.Migrations.ApplicationDbMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoleIDadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "RoleID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "RoleID");
        }
    }
}
