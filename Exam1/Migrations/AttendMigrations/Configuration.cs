using Exam1.Models;

namespace Exam1.Migrations.AttendMigrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Exam1.Models.AttendDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\AttendMigrations";
        }

        protected override void Seed(Exam1.Models.AttendDbContext context)
        {
            context.Students.AddOrUpdate(new Student[]
            {
                new Student
                {
                    StudentID = "S00190970", LastName = "Beckert", FirstName = "Cristian", 
                    Subjects = new List<Subject>()
                    {
                        new Subject
                        {
                            SubjectName = "Database",
                            Lecturers = new List<Lecturer>()
                            {
                                new Lecturer
                                {
                                    LecturerName = "Padraig"
                                }
                            }
                        },
                        new Subject
                        {
                            SubjectName = "RAD",
                            Lecturers = new List<Lecturer>()
                            {
                                new Lecturer
                                {
                                    LecturerName = "Paul"
                                }
                            }
                        }
                    }
                },
                new Student
                {
                    StudentID = "S00184567", LastName = "Mihaila", FirstName = "Crissy",
                    Subjects = new List<Subject>()
                    {
                        new Subject
                        {
                            SubjectName = "Web Dev",
                            Lecturers = new List<Lecturer>()
                            {
                                new Lecturer
                                {
                                    LecturerName = "Shane"
                                }
                            }
                        },
                        new Subject
                        {
                            SubjectName = "Soft Proj Mgmt",
                            Lecturers = new List<Lecturer>()
                            {
                                new Lecturer
                                {
                                    LecturerName = "Vivion"
                                }
                            }
                        }
                    }
                }
            });

            context.SaveChanges();

            Student Cristina = new Student();
            Cristina = context.Students.Where(s => s.FirstName == "Crissy").FirstOrDefault();

            context.Attendances.AddOrUpdate(new Attendance[]
            {
                new Attendance
                {
                    StudentID = "S00190970", SubjectID = 1, AttendanceDate = DateTime.Today, Present = true
                }, 
                new Attendance
                {
                    StudentID = "S00190970", SubjectID = 2, AttendanceDate = DateTime.Today, Present = true
                },
                new Attendance
                {
                    StudentID = Cristina.StudentID, SubjectID = 3, AttendanceDate = DateTime.Today, Present = true
                },
                new Attendance
                {
                    StudentID = Cristina.StudentID, SubjectID = 4, AttendanceDate = DateTime.Today, Present = true
                }
            });
        }
    }
}
