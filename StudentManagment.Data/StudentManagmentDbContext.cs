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
                .OnDelete(DeleteBehavior.Cascade);

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
                .OnDelete(DeleteBehavior.Cascade);

            // One-to-Many relationship: Training - CourseTraining
            modelBuilder.Entity<CourseTraining>()
                .HasOne<Training>(ct => ct.Training)
                .WithMany(t => t.CourseTrainings)
                .HasForeignKey(ct => ct.TrainingID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

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

            base.OnModelCreating(modelBuilder);

        }


    }
}
