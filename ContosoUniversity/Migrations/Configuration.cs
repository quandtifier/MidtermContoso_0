namespace ContosoUniversity.Migrations
{
    using ContosoUniversity.Models;
    using ContosoUniversity.DAL;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SchoolContext context)
        {
            var addresses = new List<Address>
            {
                new Address {Email="acarson@cu.edu"},
                new Address {Email="malonso@cu.edu"},
                new Address {Email="aanand@cu.edu"},
                new Address {Email="gbarzdukas@cu.edu"},
                new Address {Email="yli@cu.edu"},
                new Address {Email="pjustice@cu.edu"},
                new Address {Email="lnorman@cu.edu"},
                new Address {Email="nolivetto@cu.edu"},
                new Address {Email="kabercrombi@cu.edu"},
                new Address {Email="ffakori@cu.edu"},
                new Address {Email="rhururi@cu.edu"},
                new Address {Email="ckapoor@cu.edu"},
                new Address {Email="rzheng@cu.edu"}
            };
            var students = new List<Student>
            {
                new Student { FirstMidName = "Carson",   LastName = "Alexander", Gpa=0.7, CreditsEarned=10,
                    EnrollmentDate = DateTime.Parse("2010-09-01"), Address = addresses.SingleOrDefault(a => a.Email =="acarson@cu.edu") },
                new Student { FirstMidName = "Meredith", LastName = "Alonso",    Gpa=1.0,  CreditsEarned=20,
                    EnrollmentDate = DateTime.Parse("2012-09-01"), Address = addresses.SingleOrDefault(a => a.Email =="malonso@cu.edu") },
                new Student { FirstMidName = "Arturo",   LastName = "Anand",     Gpa=1.7,   CreditsEarned=30,
                    EnrollmentDate = DateTime.Parse("2013-09-01"), Address = addresses.SingleOrDefault(a => a.Email =="aanand@cu.edu") },
                new Student { FirstMidName = "Gytis",    LastName = "Barzdukas",   Gpa=1.0, CreditsEarned=40,
                    EnrollmentDate = DateTime.Parse("2012-09-01"), Address = addresses.SingleOrDefault(a => a.Email =="gbarzdukas@cu.edu") },
                new Student { FirstMidName = "Yan",      LastName = "Li",       Gpa=4.0,    CreditsEarned=50,
                    EnrollmentDate = DateTime.Parse("2012-09-01"), Address = addresses.SingleOrDefault(a => a.Email =="yli@cu.edu") },
                new Student { FirstMidName = "Peggy",    LastName = "Justice",    Gpa=1.0,  CreditsEarned=60,
                    EnrollmentDate = DateTime.Parse("2011-09-01"), Address = addresses.SingleOrDefault(a => a.Email =="pjustice@cu.edu") },
                new Student { FirstMidName = "Laura",    LastName = "Norman",     Gpa=1.5,  CreditsEarned=70,
                    EnrollmentDate = DateTime.Parse("2013-09-01"), Address = addresses.SingleOrDefault(a => a.Email =="lnorman@cu.edu") },
                new Student { FirstMidName = "Nino",     LastName = "Olivetto",    Gpa=3.0, CreditsEarned=80,
                    EnrollmentDate = DateTime.Parse("2005-09-01"), Address = addresses.SingleOrDefault(a => a.Email =="nolivetto@cu.edu") }
            };


            students.ForEach(s => context.Students.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();

            var instructors = new List<Instructor>
            {
                new Instructor { FirstMidName = "Kim",     LastName = "Abercrombie", 
                    HireDate = DateTime.Parse("1995-03-11"), Address = addresses.SingleOrDefault(a => a.Email =="kabercrombi@cu.edu") },
                new Instructor { FirstMidName = "Fadi",    LastName = "Fakhouri",    
                    HireDate = DateTime.Parse("2002-07-06"), Address = addresses.SingleOrDefault(a => a.Email =="ffakori@cu.edu") },
                new Instructor { FirstMidName = "Roger",   LastName = "Harui",       
                    HireDate = DateTime.Parse("1998-07-01"), Address = addresses.SingleOrDefault(a => a.Email =="rhururi@cu.edu") },
                new Instructor { FirstMidName = "Candace", LastName = "Kapoor",      
                    HireDate = DateTime.Parse("2001-01-15"), Address = addresses.SingleOrDefault(a => a.Email =="ckapoor@cu.edu") },
                new Instructor { FirstMidName = "Roger",   LastName = "Zheng",      
                    HireDate = DateTime.Parse("2004-02-12"), Address = addresses.SingleOrDefault(a => a.Email =="rzheng@cu.edu") }
            };
            instructors.ForEach(s => context.Instructors.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();

            var departments = new List<Department>
            {
                new Department { Name = "English",     Budget = 350000, 
                    StartDate = DateTime.Parse("2007-09-01"), 
                    InstructorID  = instructors.Single( i => i.LastName == "Abercrombie").ID },
                new Department { Name = "Mathematics", Budget = 100000, 
                    StartDate = DateTime.Parse("2007-09-01"), 
                    InstructorID  = instructors.Single( i => i.LastName == "Fakhouri").ID },
                new Department { Name = "Engineering", Budget = 350000, 
                    StartDate = DateTime.Parse("2007-09-01"), 
                    InstructorID  = instructors.Single( i => i.LastName == "Harui").ID },
                new Department { Name = "Economics",   Budget = 100000, 
                    StartDate = DateTime.Parse("2007-09-01"), 
                    InstructorID  = instructors.Single( i => i.LastName == "Kapoor").ID }
            };
            departments.ForEach(s => context.Departments.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var courses = new List<Course>
            {
                new Course {CourseID = 1050, Title = "Chemistry",      Credits = 3,
                  DepartmentID = departments.Single( s => s.Name == "Engineering").DepartmentID,
                  Instructors = new List<Instructor>() 
                },
                new Course {CourseID = 4022, Title = "Microeconomics", Credits = 3,
                  DepartmentID = departments.Single( s => s.Name == "Economics").DepartmentID,
                  Instructors = new List<Instructor>() 
                },
                new Course {CourseID = 4041, Title = "Macroeconomics", Credits = 3,
                  DepartmentID = departments.Single( s => s.Name == "Economics").DepartmentID,
                  Instructors = new List<Instructor>() 
                },
                new Course {CourseID = 1045, Title = "Calculus",       Credits = 4,
                  DepartmentID = departments.Single( s => s.Name == "Mathematics").DepartmentID,
                  Instructors = new List<Instructor>() 
                },
                new Course {CourseID = 3141, Title = "Trigonometry",   Credits = 4,
                  DepartmentID = departments.Single( s => s.Name == "Mathematics").DepartmentID,
                  Instructors = new List<Instructor>() 
                },
                new Course {CourseID = 2021, Title = "Composition",    Credits = 3,
                  DepartmentID = departments.Single( s => s.Name == "English").DepartmentID,
                  Instructors = new List<Instructor>() 
                },
                new Course {CourseID = 2042, Title = "Literature",     Credits = 4,
                  DepartmentID = departments.Single( s => s.Name == "English").DepartmentID,
                  Instructors = new List<Instructor>() 
                },
            };
            courses.ForEach(s => context.Courses.AddOrUpdate(p => p.CourseID, s));
            context.SaveChanges();

            var officeAssignments = new List<OfficeAssignment>
            {
                new OfficeAssignment { 
                    InstructorID = instructors.Single( i => i.LastName == "Fakhouri").ID, 
                    Location = "Smith 17" },
                new OfficeAssignment { 
                    InstructorID = instructors.Single( i => i.LastName == "Harui").ID, 
                    Location = "Gowan 27" },
                new OfficeAssignment { 
                    InstructorID = instructors.Single( i => i.LastName == "Kapoor").ID, 
                    Location = "Thompson 304" },
            };
            officeAssignments.ForEach(s => context.OfficeAssignments.AddOrUpdate(p => p.InstructorID, s));
            context.SaveChanges();

            AddOrUpdateInstructor(context, "Chemistry", "Kapoor");
            AddOrUpdateInstructor(context, "Chemistry", "Harui");
            AddOrUpdateInstructor(context, "Microeconomics", "Zheng");
            AddOrUpdateInstructor(context, "Macroeconomics", "Zheng");

            AddOrUpdateInstructor(context, "Calculus", "Fakhouri");
            AddOrUpdateInstructor(context, "Trigonometry", "Harui");
            AddOrUpdateInstructor(context, "Composition", "Abercrombie");
            AddOrUpdateInstructor(context, "Literature", "Abercrombie");

            context.SaveChanges();

            var enrollments = new List<Enrollment>
            {
                new Enrollment { 
                    StudentID = students.Single(s => s.LastName == "Alexander").ID, 
                    CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID, 
                    Grade = Grade.A 
                },
                 new Enrollment { 
                    StudentID = students.Single(s => s.LastName == "Alexander").ID,
                    CourseID = courses.Single(c => c.Title == "Microeconomics" ).CourseID, 
                    Grade = Grade.C 
                 },                            
                 new Enrollment { 
                    StudentID = students.Single(s => s.LastName == "Alexander").ID,
                    CourseID = courses.Single(c => c.Title == "Macroeconomics" ).CourseID, 
                    Grade = Grade.B
                 },
                 new Enrollment { 
                     StudentID = students.Single(s => s.LastName == "Alonso").ID,
                    CourseID = courses.Single(c => c.Title == "Calculus" ).CourseID, 
                    Grade = Grade.B 
                 },
                 new Enrollment { 
                     StudentID = students.Single(s => s.LastName == "Alonso").ID,
                    CourseID = courses.Single(c => c.Title == "Trigonometry" ).CourseID, 
                    Grade = Grade.B 
                 },
                 new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Alonso").ID,
                    CourseID = courses.Single(c => c.Title == "Composition" ).CourseID, 
                    Grade = Grade.B 
                 },
                 new Enrollment { 
                    StudentID = students.Single(s => s.LastName == "Anand").ID,
                    CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID
                 },
                 new Enrollment { 
                    StudentID = students.Single(s => s.LastName == "Anand").ID,
                    CourseID = courses.Single(c => c.Title == "Microeconomics").CourseID,
                    Grade = Grade.B         
                 },
                new Enrollment { 
                    StudentID = students.Single(s => s.LastName == "Barzdukas").ID,
                    CourseID = courses.Single(c => c.Title == "Chemistry").CourseID,
                    Grade = Grade.B         
                 },
                 new Enrollment { 
                    StudentID = students.Single(s => s.LastName == "Li").ID,
                    CourseID = courses.Single(c => c.Title == "Composition").CourseID,
                    Grade = Grade.B         
                 },
                 new Enrollment { 
                    StudentID = students.Single(s => s.LastName == "Justice").ID,
                    CourseID = courses.Single(c => c.Title == "Literature").CourseID,
                    Grade = Grade.B         
                 }
            };

            foreach (Enrollment e in enrollments)
            {
                var enrollmentInDataBase = context.Enrollments.Where(
                    s =>
                         s.Student.ID == e.StudentID &&
                         s.Course.CourseID == e.CourseID).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.Enrollments.Add(e);
                }
            }
            context.SaveChanges();
        }

        void AddOrUpdateInstructor(SchoolContext context, string courseTitle, string instructorName)
        {
            var crs = context.Courses.SingleOrDefault(c => c.Title == courseTitle);
            var inst = crs.Instructors.SingleOrDefault(i => i.LastName == instructorName);
            if (inst == null)
                crs.Instructors.Add(context.Instructors.Single(i => i.LastName == instructorName));
        }
    }
}
