namespace Exam1.Migrations.AttendMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Relationshipchanged : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentSubjectStudents", "StudentSubject_StudentID", "dbo.Student Subject");
            DropForeignKey("dbo.StudentSubjectStudents", "Student_StudentID", "dbo.Students");
            DropForeignKey("dbo.LecturerSubjectLecturers", "LecturerSubject_SubjectID", "dbo.Lectuer Subject");
            DropForeignKey("dbo.LecturerSubjectLecturers", "Lecturer_LecturerID", "dbo.Lecturer");
            DropForeignKey("dbo.LecturerSubjectSubjects", "LecturerSubject_SubjectID", "dbo.Lectuer Subject");
            DropForeignKey("dbo.LecturerSubjectSubjects", "Subject_SubjectID", "dbo.Subject");
            DropForeignKey("dbo.StudentSubjectSubjects", "StudentSubject_StudentID", "dbo.Student Subject");
            DropForeignKey("dbo.StudentSubjectSubjects", "Subject_SubjectID", "dbo.Subject");
            DropIndex("dbo.StudentSubjectStudents", new[] { "StudentSubject_StudentID" });
            DropIndex("dbo.StudentSubjectStudents", new[] { "Student_StudentID" });
            DropIndex("dbo.LecturerSubjectLecturers", new[] { "LecturerSubject_SubjectID" });
            DropIndex("dbo.LecturerSubjectLecturers", new[] { "Lecturer_LecturerID" });
            DropIndex("dbo.LecturerSubjectSubjects", new[] { "LecturerSubject_SubjectID" });
            DropIndex("dbo.LecturerSubjectSubjects", new[] { "Subject_SubjectID" });
            DropIndex("dbo.StudentSubjectSubjects", new[] { "StudentSubject_StudentID" });
            DropIndex("dbo.StudentSubjectSubjects", new[] { "Subject_SubjectID" });
            CreateTable(
                "dbo.LecturerSubjects",
                c => new
                    {
                        Lecturer_LecturerID = c.Int(nullable: false),
                        Subject_SubjectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Lecturer_LecturerID, t.Subject_SubjectID })
                .ForeignKey("dbo.Lecturer", t => t.Lecturer_LecturerID, cascadeDelete: true)
                .ForeignKey("dbo.Subject", t => t.Subject_SubjectID, cascadeDelete: true)
                .Index(t => t.Lecturer_LecturerID)
                .Index(t => t.Subject_SubjectID);
            
            CreateTable(
                "dbo.SubjectStudents",
                c => new
                    {
                        Subject_SubjectID = c.Int(nullable: false),
                        Student_StudentID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Subject_SubjectID, t.Student_StudentID })
                .ForeignKey("dbo.Subject", t => t.Subject_SubjectID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Student_StudentID, cascadeDelete: true)
                .Index(t => t.Subject_SubjectID)
                .Index(t => t.Student_StudentID);
            
            DropTable("dbo.Student Subject");
            DropTable("dbo.Lectuer Subject");
            DropTable("dbo.StudentSubjectStudents");
            DropTable("dbo.LecturerSubjectLecturers");
            DropTable("dbo.LecturerSubjectSubjects");
            DropTable("dbo.StudentSubjectSubjects");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.StudentSubjectSubjects",
                c => new
                    {
                        StudentSubject_StudentID = c.String(nullable: false, maxLength: 128),
                        Subject_SubjectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentSubject_StudentID, t.Subject_SubjectID });
            
            CreateTable(
                "dbo.LecturerSubjectSubjects",
                c => new
                    {
                        LecturerSubject_SubjectID = c.Int(nullable: false),
                        Subject_SubjectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LecturerSubject_SubjectID, t.Subject_SubjectID });
            
            CreateTable(
                "dbo.LecturerSubjectLecturers",
                c => new
                    {
                        LecturerSubject_SubjectID = c.Int(nullable: false),
                        Lecturer_LecturerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LecturerSubject_SubjectID, t.Lecturer_LecturerID });
            
            CreateTable(
                "dbo.StudentSubjectStudents",
                c => new
                    {
                        StudentSubject_StudentID = c.String(nullable: false, maxLength: 128),
                        Student_StudentID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.StudentSubject_StudentID, t.Student_StudentID });
            
            CreateTable(
                "dbo.Lectuer Subject",
                c => new
                    {
                        SubjectID = c.Int(nullable: false, identity: true),
                        LectuerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubjectID);
            
            CreateTable(
                "dbo.Student Subject",
                c => new
                    {
                        StudentID = c.String(nullable: false, maxLength: 128),
                        SubjectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentID);
            
            DropForeignKey("dbo.SubjectStudents", "Student_StudentID", "dbo.Students");
            DropForeignKey("dbo.SubjectStudents", "Subject_SubjectID", "dbo.Subject");
            DropForeignKey("dbo.LecturerSubjects", "Subject_SubjectID", "dbo.Subject");
            DropForeignKey("dbo.LecturerSubjects", "Lecturer_LecturerID", "dbo.Lecturer");
            DropIndex("dbo.SubjectStudents", new[] { "Student_StudentID" });
            DropIndex("dbo.SubjectStudents", new[] { "Subject_SubjectID" });
            DropIndex("dbo.LecturerSubjects", new[] { "Subject_SubjectID" });
            DropIndex("dbo.LecturerSubjects", new[] { "Lecturer_LecturerID" });
            DropTable("dbo.SubjectStudents");
            DropTable("dbo.LecturerSubjects");
            CreateIndex("dbo.StudentSubjectSubjects", "Subject_SubjectID");
            CreateIndex("dbo.StudentSubjectSubjects", "StudentSubject_StudentID");
            CreateIndex("dbo.LecturerSubjectSubjects", "Subject_SubjectID");
            CreateIndex("dbo.LecturerSubjectSubjects", "LecturerSubject_SubjectID");
            CreateIndex("dbo.LecturerSubjectLecturers", "Lecturer_LecturerID");
            CreateIndex("dbo.LecturerSubjectLecturers", "LecturerSubject_SubjectID");
            CreateIndex("dbo.StudentSubjectStudents", "Student_StudentID");
            CreateIndex("dbo.StudentSubjectStudents", "StudentSubject_StudentID");
            AddForeignKey("dbo.StudentSubjectSubjects", "Subject_SubjectID", "dbo.Subject", "SubjectID", cascadeDelete: true);
            AddForeignKey("dbo.StudentSubjectSubjects", "StudentSubject_StudentID", "dbo.Student Subject", "StudentID", cascadeDelete: true);
            AddForeignKey("dbo.LecturerSubjectSubjects", "Subject_SubjectID", "dbo.Subject", "SubjectID", cascadeDelete: true);
            AddForeignKey("dbo.LecturerSubjectSubjects", "LecturerSubject_SubjectID", "dbo.Lectuer Subject", "SubjectID", cascadeDelete: true);
            AddForeignKey("dbo.LecturerSubjectLecturers", "Lecturer_LecturerID", "dbo.Lecturer", "LecturerID", cascadeDelete: true);
            AddForeignKey("dbo.LecturerSubjectLecturers", "LecturerSubject_SubjectID", "dbo.Lectuer Subject", "SubjectID", cascadeDelete: true);
            AddForeignKey("dbo.StudentSubjectStudents", "Student_StudentID", "dbo.Students", "StudentID", cascadeDelete: true);
            AddForeignKey("dbo.StudentSubjectStudents", "StudentSubject_StudentID", "dbo.Student Subject", "StudentID", cascadeDelete: true);
        }
    }
}
