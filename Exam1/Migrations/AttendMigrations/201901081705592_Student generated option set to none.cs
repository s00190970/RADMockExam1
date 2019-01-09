namespace Exam1.Migrations.AttendMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Studentgeneratedoptionsettonone : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentSubjectStudents", "Student_StudentID", "dbo.Students");
            DropForeignKey("dbo.Attendance", "StudentID", "dbo.Students");
            DropPrimaryKey("dbo.Students");
            AlterColumn("dbo.Students", "StudentID", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Students", "StudentID");
            AddForeignKey("dbo.StudentSubjectStudents", "Student_StudentID", "dbo.Students", "StudentID", cascadeDelete: true);
            AddForeignKey("dbo.Attendance", "StudentID", "dbo.Students", "StudentID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendance", "StudentID", "dbo.Students");
            DropForeignKey("dbo.StudentSubjectStudents", "Student_StudentID", "dbo.Students");
            DropPrimaryKey("dbo.Students");
            AlterColumn("dbo.Students", "StudentID", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Students", "StudentID");
            AddForeignKey("dbo.Attendance", "StudentID", "dbo.Students", "StudentID");
            AddForeignKey("dbo.StudentSubjectStudents", "Student_StudentID", "dbo.Students", "StudentID", cascadeDelete: true);
        }
    }
}
