namespace Exam1.Migrations.AttendMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendance",
                c => new
                    {
                        AttendanceID = c.Int(nullable: false, identity: true),
                        AttendanceDate = c.DateTime(nullable: false),
                        SubjectID = c.Int(nullable: false),
                        StudentID = c.String(maxLength: 128),
                        Present = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AttendanceID)
                .ForeignKey("dbo.Students", t => t.StudentID)
                .ForeignKey("dbo.Subject", t => t.SubjectID, cascadeDelete: true)
                .Index(t => t.SubjectID)
                .Index(t => t.StudentID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.StudentID);
            
            CreateTable(
                "dbo.Student Subject",
                c => new
                    {
                        StudentID = c.String(nullable: false, maxLength: 128),
                        SubjectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentID);
            
            CreateTable(
                "dbo.Subject",
                c => new
                    {
                        SubjectID = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(),
                    })
                .PrimaryKey(t => t.SubjectID);
            
            CreateTable(
                "dbo.Lectuer Subject",
                c => new
                    {
                        SubjectID = c.Int(nullable: false, identity: true),
                        LectuerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubjectID);
            
            CreateTable(
                "dbo.Lecturer",
                c => new
                    {
                        LecturerID = c.Int(nullable: false, identity: true),
                        LecturerName = c.String(),
                    })
                .PrimaryKey(t => t.LecturerID);
            
            CreateTable(
                "dbo.StudentSubjectStudents",
                c => new
                    {
                        StudentSubject_StudentID = c.String(nullable: false, maxLength: 128),
                        Student_StudentID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.StudentSubject_StudentID, t.Student_StudentID })
                .ForeignKey("dbo.Student Subject", t => t.StudentSubject_StudentID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Student_StudentID, cascadeDelete: true)
                .Index(t => t.StudentSubject_StudentID)
                .Index(t => t.Student_StudentID);
            
            CreateTable(
                "dbo.LecturerSubjectLecturers",
                c => new
                    {
                        LecturerSubject_SubjectID = c.Int(nullable: false),
                        Lecturer_LecturerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LecturerSubject_SubjectID, t.Lecturer_LecturerID })
                .ForeignKey("dbo.Lectuer Subject", t => t.LecturerSubject_SubjectID, cascadeDelete: true)
                .ForeignKey("dbo.Lecturer", t => t.Lecturer_LecturerID, cascadeDelete: true)
                .Index(t => t.LecturerSubject_SubjectID)
                .Index(t => t.Lecturer_LecturerID);
            
            CreateTable(
                "dbo.LecturerSubjectSubjects",
                c => new
                    {
                        LecturerSubject_SubjectID = c.Int(nullable: false),
                        Subject_SubjectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LecturerSubject_SubjectID, t.Subject_SubjectID })
                .ForeignKey("dbo.Lectuer Subject", t => t.LecturerSubject_SubjectID, cascadeDelete: true)
                .ForeignKey("dbo.Subject", t => t.Subject_SubjectID, cascadeDelete: true)
                .Index(t => t.LecturerSubject_SubjectID)
                .Index(t => t.Subject_SubjectID);
            
            CreateTable(
                "dbo.StudentSubjectSubjects",
                c => new
                    {
                        StudentSubject_StudentID = c.String(nullable: false, maxLength: 128),
                        Subject_SubjectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentSubject_StudentID, t.Subject_SubjectID })
                .ForeignKey("dbo.Student Subject", t => t.StudentSubject_StudentID, cascadeDelete: true)
                .ForeignKey("dbo.Subject", t => t.Subject_SubjectID, cascadeDelete: true)
                .Index(t => t.StudentSubject_StudentID)
                .Index(t => t.Subject_SubjectID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendance", "SubjectID", "dbo.Subject");
            DropForeignKey("dbo.Attendance", "StudentID", "dbo.Students");
            DropForeignKey("dbo.StudentSubjectSubjects", "Subject_SubjectID", "dbo.Subject");
            DropForeignKey("dbo.StudentSubjectSubjects", "StudentSubject_StudentID", "dbo.Student Subject");
            DropForeignKey("dbo.LecturerSubjectSubjects", "Subject_SubjectID", "dbo.Subject");
            DropForeignKey("dbo.LecturerSubjectSubjects", "LecturerSubject_SubjectID", "dbo.Lectuer Subject");
            DropForeignKey("dbo.LecturerSubjectLecturers", "Lecturer_LecturerID", "dbo.Lecturer");
            DropForeignKey("dbo.LecturerSubjectLecturers", "LecturerSubject_SubjectID", "dbo.Lectuer Subject");
            DropForeignKey("dbo.StudentSubjectStudents", "Student_StudentID", "dbo.Students");
            DropForeignKey("dbo.StudentSubjectStudents", "StudentSubject_StudentID", "dbo.Student Subject");
            DropIndex("dbo.StudentSubjectSubjects", new[] { "Subject_SubjectID" });
            DropIndex("dbo.StudentSubjectSubjects", new[] { "StudentSubject_StudentID" });
            DropIndex("dbo.LecturerSubjectSubjects", new[] { "Subject_SubjectID" });
            DropIndex("dbo.LecturerSubjectSubjects", new[] { "LecturerSubject_SubjectID" });
            DropIndex("dbo.LecturerSubjectLecturers", new[] { "Lecturer_LecturerID" });
            DropIndex("dbo.LecturerSubjectLecturers", new[] { "LecturerSubject_SubjectID" });
            DropIndex("dbo.StudentSubjectStudents", new[] { "Student_StudentID" });
            DropIndex("dbo.StudentSubjectStudents", new[] { "StudentSubject_StudentID" });
            DropIndex("dbo.Attendance", new[] { "StudentID" });
            DropIndex("dbo.Attendance", new[] { "SubjectID" });
            DropTable("dbo.StudentSubjectSubjects");
            DropTable("dbo.LecturerSubjectSubjects");
            DropTable("dbo.LecturerSubjectLecturers");
            DropTable("dbo.StudentSubjectStudents");
            DropTable("dbo.Lecturer");
            DropTable("dbo.Lectuer Subject");
            DropTable("dbo.Subject");
            DropTable("dbo.Student Subject");
            DropTable("dbo.Students");
            DropTable("dbo.Attendance");
        }
    }
}
