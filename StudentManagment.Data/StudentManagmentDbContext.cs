using Microsoft.EntityFrameworkCore;
using StudentManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagment.Data
{
    public class StudentManagmentDbContext : DbContext
    {
        public StudentManagmentDbContext() : base() { }
        public StudentManagmentDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Coaching> Coachings { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseTraining> CourseTrainings { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Students { get; set; }
        //public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<UserCourse> UserCourses { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StudentManagmentDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseTraining>().HasKey(ep => new {ep.CourseID, ep.TrainingID});
            modelBuilder.Entity<UserCourse>().HasKey(ep => new { ep.UserID, ep.CourseID });

            // One-to-Many relationship: Course - StudentCourse
            modelBuilder.Entity<UserCourse>()
                .HasOne<Course>(sc => sc.Course)
                .WithMany(c => c.UserCourses)
                .HasForeignKey(sc => sc.CourseID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserCourse>()
            .HasOne<User>(sc => sc.User)
            .WithMany(c => c.UserCourses)
            .HasForeignKey(sc => sc.CourseID)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

            // One-to-One relationship: User - Instructor
            modelBuilder.Entity<User>()
                .HasOne(u => u.Instructor)
                .WithOne(i => i.User)
                .HasForeignKey<Instructor>(i => i.UserID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            // One-to-Many relationship: Instructor - Course
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Instructor)
                .WithMany(i => i.Courses)
                .HasForeignKey(i => i.CourseID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            // One-to-Many relationship: Instructor - Coaching
            modelBuilder.Entity<Coaching>()
                .HasOne<Instructor>(co => co.Instructor)
                .WithMany(i => i.Coachings)
                .HasForeignKey(co => co.InstructorID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            // One-to-Many relationship: Course - CourseTraining
            modelBuilder.Entity<CourseTraining>()
                .HasOne<Course>(ct => ct.Course)
                .WithMany(c => c.CourseTrainings)
                .HasForeignKey(ct => ct.CourseID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // One-to-Many relationship: Training - CourseTraining
            modelBuilder.Entity<CourseTraining>()
                .HasOne<Training>(ct => ct.Training)
                .WithMany(t => t.CourseTrainings)
                .HasForeignKey(ct => ct.TrainingID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // One-to-Many relationship: Training - Attendance
            modelBuilder.Entity<Attendance>()
                .HasOne<Training>(a => a.Training)
                .WithMany(t => t.Attendances)
                .HasForeignKey(a => a.TrainingID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            // One-to-Many relationship: Training - Grade
            modelBuilder.Entity<Grade>()
                .HasOne<Training>(g => g.Training)
                .WithMany(t => t.Grades)
                .HasForeignKey(g => g.TrainingID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            // Twoje dotychczasowe konfiguracje

            modelBuilder.Entity<User>().HasData(
                new User { UserID = 1, Username = "AdminUser", Password = "Admin123", Role = Role.Administrator, Email = "admin@example.com" },
                new User { UserID = 2, Username = "InstructorUser", Password = "Instructor123", Role = Role.Instructor, Email = "instructor@example.com" },
                new User { UserID = 3, Username = "StudentUser", Password = "Student123", Role = Role.Student, Email = "student@example.com" }
            // Dodaj więcej użytkowników
            );

            modelBuilder.Entity<Instructor>().HasData(
                new Instructor { InstructorID = 1, UserID = 2, FirstName = "John", LastName = "Doe", DateOfBirth = DateTime.Now.AddYears(-30), Phone = "123456789", Address = "123 Main St" },
                new Instructor { InstructorID = 2, UserID = 3, FirstName = "Jane", LastName = "Smith", DateOfBirth = DateTime.Now.AddYears(-28), Phone = "987654321", Address = "456 Oak St" }
            // Dodaj więcej instruktorów
            );

            modelBuilder.Entity<Course>().HasData(
                new Course { CourseID = 1,InstructorID=1, CourseName = "Introduction to Programming", Description = "Learn the basics of programming" },
                new Course { CourseID = 2, InstructorID = 1, CourseName = "Physics 101", Description = "Introduction to Physics" },
                new Course { CourseID = 3, InstructorID = 2, CourseName = "Mathematics Fundamentals", Description = "Basic math concepts" }
            // Dodaj więcej kursów
            );

            modelBuilder.Entity<UserCourse>().HasData(
                new UserCourse { UserID = 3, CourseID = 1 },
                new UserCourse { UserID = 3, CourseID = 2 },
                new UserCourse { UserID = 3, CourseID = 3 }
            // Dodaj więcej przypisanych kursów dla użytkowników
            );


            modelBuilder.Entity<CourseTraining>().HasData(
                new CourseTraining { CourseID = 1, TrainingID = 1 },
                new CourseTraining { CourseID = 2, TrainingID = 2 },
                new CourseTraining { CourseID = 3, TrainingID = 3 }
            // Dodaj więcej przypisanych szkoleń do kursów
            );

            modelBuilder.Entity<Training>().HasData(
                new Training { TrainingID = 1, Location = "Room A", StartDate = DateTime.Now.AddMonths(1), EndDate = DateTime.Now.AddMonths(2), Topic = "Programming Basics" },
                new Training { TrainingID = 2, Location = "Room B", StartDate = DateTime.Now.AddMonths(2), EndDate = DateTime.Now.AddMonths(3), Topic = "Physics Fundamentals" },
                new Training { TrainingID = 3, Location = "Room C", StartDate = DateTime.Now.AddMonths(1), EndDate = DateTime.Now.AddMonths(2), Topic = "Math Basics" }
            // Dodaj więcej szkoleń
            );

            modelBuilder.Entity<Coaching>().HasData(
                new Coaching { CoachingID = 1, InstructorID = 1, Location = "Room X", StartDate = DateTime.Now.AddMonths(1), EndDate = DateTime.Now.AddMonths(2), Topic = "Advanced Programming", Feedback = "Good performance" },
                new Coaching { CoachingID = 2, InstructorID = 2, Location = "Room Y", StartDate = DateTime.Now.AddMonths(2), EndDate = DateTime.Now.AddMonths(3), Topic = "Advanced Physics", Feedback = "Excellent participation" }
            // Dodaj więcej coachings
            );

            modelBuilder.Entity<Attendance>().HasData(
                new Attendance { AttendanceID = 1, StudentID = 3, TrainingID = 1, Date = DateTime.Now.AddMonths(1), Present = true },
                new Attendance { AttendanceID = 2, StudentID = 3, TrainingID = 2, Date = DateTime.Now.AddMonths(2), Present = false }
            // Dodaj więcej obecności
            );

            modelBuilder.Entity<Grade>().HasData(
                new Grade { GradeID = 1, StudentID = 3, TrainingID = 1, Score = 90, Remarks = "Good performance" },
                new Grade { GradeID = 2, StudentID = 3, TrainingID = 2, Score = 95, Remarks = "Excellent work" }
            // Dodaj więcej ocen
            );


            base.OnModelCreating(modelBuilder);

        }


    }
}
