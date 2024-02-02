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

        public DbSet<UserCourse> UserCourses { get; set; }
        public DbSet<UserCoaching> UserCoachings { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TestDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseTraining>().HasKey(ep => new {ep.CourseID, ep.TrainingID});
            modelBuilder.Entity<UserCourse>().HasKey(ep => new { ep.UserID, ep.CourseID });
            modelBuilder.Entity<UserCoaching>().HasKey(ep => new { ep.UserID, ep.CoachingID });

            // One-to-Many relationship: Course - UserCourses
            modelBuilder.Entity<UserCourse>()
                .HasOne<Course>(uc => uc.Course)
                .WithMany(c => c.UserCourses)
                .HasForeignKey(uc => uc.CourseID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // One-to-Many relationship: User - UserCourses
            modelBuilder.Entity<UserCourse>()
                .HasOne<User>(uc => uc.User)
                .WithMany(c => c.UserCourses)
                .HasForeignKey(uc => uc.UserID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // One-to-Many relationship: Coaching - UserCoaching
            modelBuilder.Entity<UserCoaching>()
                .HasOne<Coaching>(uc => uc.Coaching)
                .WithMany(c => c.UserCoachings)
                .HasForeignKey(uc => uc.CoachingID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // One-to-Many relationship: User - UserCoaching
            modelBuilder.Entity<UserCoaching>()
                .HasOne<User>(uc => uc.User)
                .WithMany(c => c.UserCoachings)
                .HasForeignKey(uc => uc.UserID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

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

            // One-to-Many relationship: User - Attendance
            modelBuilder.Entity<Attendance>()
                .HasOne<User>(a => a.User)
                .WithMany(u => u.Attendances)
                .HasForeignKey(a => a.UserID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            // One-to-Many relationship: User - Grade
            modelBuilder.Entity<Grade>()
                .HasOne<User>(g => g.User)
                .WithMany(u => u.Grades)
                .HasForeignKey(g => g.UserID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserID = 1,
                    Username = "AdminUser",
                    Password = "Admin123",
                    Role = Role.Administrator,
                    Email = "admin@example.com",
                    FirstName = "Admin",
                    LastName = "Admin",
                    DateOfBirth = new DateTime(1990, 1, 1),
                    Phone = "123-456-789",
                    Avatar= "https://images.unsplash.com/photo-1593085512500-5d55148d6f0d?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1yZWxhdGVkfDExfHx8ZW58MHx8fHx8"
                },
                new User
                {
                    UserID = 2,
                    Username = "InstructorUser",
                    Password = "Instructor123",
                    Role = Role.Instructor,
                    Email = "instructor@example.com",
                    FirstName = "Instructor",
                    LastName = "Instructor",
                    DateOfBirth = new DateTime(1980, 1, 1),
                    Phone = "987-654-321",
                    Avatar= "https://images.unsplash.com/photo-1610981755415-3f7c9202cccb?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1yZWxhdGVkfDEzfHx8ZW58MHx8fHx8"
                },
                new User
                {
                    UserID = 3,
                    Username = "StudentUser",
                    Password = "Student123",
                    Role = Role.Student,
                    Email = "student@example.com",
                    FirstName = "Student",
                    LastName = "Student",
                    DateOfBirth = new DateTime(2000, 1, 1),
                    Phone = "555-123-456",
                    Avatar= "https://images.unsplash.com/photo-1638803040283-7a5ffd48dad5?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1yZWxhdGVkfDl8fHxlbnwwfHx8fHw%3D"
                }
            );

            modelBuilder.Entity<Course>().HasData(
                new Course { CourseID = 1, CourseName = "Introduction to Programming", Description = "Learn the basics of programming" },
                new Course { CourseID = 2, CourseName = "Physics 101", Description = "Introduction to Physics" },
                new Course { CourseID = 3, CourseName = "Mathematics Fundamentals", Description = "Basic math concepts" }
  
            );

            modelBuilder.Entity<UserCourse>().HasData(
                new UserCourse { UserID = 3, Role = Role.Student, CourseID = 1 },
                new UserCourse { UserID = 3, Role = Role.Student, CourseID = 2 },
                new UserCourse { UserID = 2, Role = Role.Instructor, CourseID = 3 }

            );

            modelBuilder.Entity<CourseTraining>().HasData(
                new CourseTraining { CourseID = 1, TrainingID = 1 },
                new CourseTraining { CourseID = 2, TrainingID = 2 },
                new CourseTraining { CourseID = 3, TrainingID = 3 }
 
            );

            modelBuilder.Entity<Training>().HasData(
                new Training { TrainingID = 1, Location = "Room A", StartDate = DateTime.Now.AddMonths(1), EndDate = DateTime.Now.AddMonths(2), Topic = "Programming Basics" },
                new Training { TrainingID = 2, Location = "Room B", StartDate = DateTime.Now.AddMonths(2), EndDate = DateTime.Now.AddMonths(3), Topic = "Physics Fundamentals" },
                new Training { TrainingID = 3, Location = "Room C", StartDate = DateTime.Now.AddMonths(1), EndDate = DateTime.Now.AddMonths(2), Topic = "Math Basics" }

            );

            modelBuilder.Entity<Coaching>().HasData(
                new Coaching { CoachingID = 1, Location = "Room X", StartDate = DateTime.Now.AddMonths(1), EndDate = DateTime.Now.AddMonths(2), Topic = "Advanced Programming", Feedback = "Good performance" },
                new Coaching { CoachingID = 2, Location = "Room Y", StartDate = DateTime.Now.AddMonths(2), EndDate = DateTime.Now.AddMonths(3), Topic = "Advanced Physics", Feedback = "Excellent participation" }
            );

            modelBuilder.Entity<UserCoaching>().HasData(
                new UserCoaching { UserID = 3, Role = Role.Student, CoachingID = 1 },
                new UserCoaching { UserID = 3, Role = Role.Student, CoachingID = 2 },
                new UserCoaching { UserID = 2, Role = Role.Instructor, CoachingID = 1 }

            );

            modelBuilder.Entity<Attendance>().HasData(
                new Attendance { AttendanceID = 1, UserID = 3, TrainingID = 1, Date = DateTime.Now.AddMonths(1), Present = true },
                new Attendance { AttendanceID = 2, UserID = 3, TrainingID = 2, Date = DateTime.Now.AddMonths(2), Present = false }
            );

            modelBuilder.Entity<Grade>().HasData(
                new Grade { GradeID = 1, UserID = 3, TrainingID = 1, Score = 90, Remarks = "Good performance" },
                new Grade { GradeID = 2, UserID = 3, TrainingID = 2, Score = 95, Remarks = "Excellent work" }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
