﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentManagment.Data;

#nullable disable

namespace StudentManagment.Data.Migrations
{
    [DbContext(typeof(StudentManagmentDbContext))]
    partial class StudentManagmentDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StudentManagement.Models.Entities.Attendance", b =>
                {
                    b.Property<int>("AttendanceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AttendanceID"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Present")
                        .HasColumnType("bit");

                    b.Property<int>("TrainingID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("AttendanceID");

                    b.HasIndex("TrainingID");

                    b.HasIndex("UserID");

                    b.ToTable("Attendances");

                    b.HasData(
                        new
                        {
                            AttendanceID = 1,
                            Date = new DateTime(2024, 2, 25, 15, 53, 17, 850, DateTimeKind.Local).AddTicks(4857),
                            Present = true,
                            TrainingID = 1,
                            UserID = 3
                        },
                        new
                        {
                            AttendanceID = 2,
                            Date = new DateTime(2024, 3, 25, 15, 53, 17, 850, DateTimeKind.Local).AddTicks(4859),
                            Present = false,
                            TrainingID = 2,
                            UserID = 3
                        });
                });

            modelBuilder.Entity("StudentManagement.Models.Entities.Coaching", b =>
                {
                    b.Property<int>("CoachingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CoachingID"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Feedback")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Topic")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("CoachingID");

                    b.ToTable("Coachings");

                    b.HasData(
                        new
                        {
                            CoachingID = 1,
                            EndDate = new DateTime(2024, 3, 25, 15, 53, 17, 850, DateTimeKind.Local).AddTicks(4835),
                            Feedback = "Good performance",
                            Location = "Room X",
                            StartDate = new DateTime(2024, 2, 25, 15, 53, 17, 850, DateTimeKind.Local).AddTicks(4834),
                            Topic = "Advanced Programming"
                        },
                        new
                        {
                            CoachingID = 2,
                            EndDate = new DateTime(2024, 4, 25, 15, 53, 17, 850, DateTimeKind.Local).AddTicks(4838),
                            Feedback = "Excellent participation",
                            Location = "Room Y",
                            StartDate = new DateTime(2024, 3, 25, 15, 53, 17, 850, DateTimeKind.Local).AddTicks(4837),
                            Topic = "Advanced Physics"
                        });
                });

            modelBuilder.Entity("StudentManagement.Models.Entities.Course", b =>
                {
                    b.Property<int>("CourseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseID"));

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseID");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            CourseID = 1,
                            CourseName = "Introduction to Programming",
                            Description = "Learn the basics of programming"
                        },
                        new
                        {
                            CourseID = 2,
                            CourseName = "Physics 101",
                            Description = "Introduction to Physics"
                        },
                        new
                        {
                            CourseID = 3,
                            CourseName = "Mathematics Fundamentals",
                            Description = "Basic math concepts"
                        });
                });

            modelBuilder.Entity("StudentManagement.Models.Entities.CourseTraining", b =>
                {
                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<int>("TrainingID")
                        .HasColumnType("int");

                    b.HasKey("CourseID", "TrainingID");

                    b.HasIndex("TrainingID");

                    b.ToTable("CourseTrainings");

                    b.HasData(
                        new
                        {
                            CourseID = 1,
                            TrainingID = 1
                        },
                        new
                        {
                            CourseID = 2,
                            TrainingID = 2
                        },
                        new
                        {
                            CourseID = 3,
                            TrainingID = 3
                        });
                });

            modelBuilder.Entity("StudentManagement.Models.Entities.Grade", b =>
                {
                    b.Property<int>("GradeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GradeID"));

                    b.Property<string>("Remarks")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Score")
                        .HasColumnType("real");

                    b.Property<int>("TrainingID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("GradeID");

                    b.HasIndex("TrainingID");

                    b.HasIndex("UserID");

                    b.ToTable("Grades");

                    b.HasData(
                        new
                        {
                            GradeID = 1,
                            Remarks = "Good performance",
                            Score = 90f,
                            TrainingID = 1,
                            UserID = 3
                        },
                        new
                        {
                            GradeID = 2,
                            Remarks = "Excellent work",
                            Score = 95f,
                            TrainingID = 2,
                            UserID = 3
                        });
                });

            modelBuilder.Entity("StudentManagement.Models.Entities.Training", b =>
                {
                    b.Property<int>("TrainingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrainingID"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Topic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TrainingID");

                    b.ToTable("Trainings");

                    b.HasData(
                        new
                        {
                            TrainingID = 1,
                            EndDate = new DateTime(2024, 3, 25, 15, 53, 17, 850, DateTimeKind.Local).AddTicks(4783),
                            Location = "Room A",
                            StartDate = new DateTime(2024, 2, 25, 15, 53, 17, 850, DateTimeKind.Local).AddTicks(4741),
                            Topic = "Programming Basics"
                        },
                        new
                        {
                            TrainingID = 2,
                            EndDate = new DateTime(2024, 4, 25, 15, 53, 17, 850, DateTimeKind.Local).AddTicks(4819),
                            Location = "Room B",
                            StartDate = new DateTime(2024, 3, 25, 15, 53, 17, 850, DateTimeKind.Local).AddTicks(4818),
                            Topic = "Physics Fundamentals"
                        },
                        new
                        {
                            TrainingID = 3,
                            EndDate = new DateTime(2024, 3, 25, 15, 53, 17, 850, DateTimeKind.Local).AddTicks(4822),
                            Location = "Room C",
                            StartDate = new DateTime(2024, 2, 25, 15, 53, 17, 850, DateTimeKind.Local).AddTicks(4821),
                            Topic = "Math Basics"
                        });
                });

            modelBuilder.Entity("StudentManagement.Models.Entities.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("UserID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserID = 1,
                            Avatar = "https://images.unsplash.com/photo-1593085512500-5d55148d6f0d?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1yZWxhdGVkfDExfHx8ZW58MHx8fHx8",
                            DateOfBirth = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "admin@example.com",
                            FirstName = "Admin",
                            LastName = "Admin",
                            Password = "Admin123",
                            Phone = "123-456-789",
                            Role = 0,
                            Username = "AdminUser"
                        },
                        new
                        {
                            UserID = 2,
                            Avatar = "https://images.unsplash.com/photo-1610981755415-3f7c9202cccb?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1yZWxhdGVkfDEzfHx8ZW58MHx8fHx8",
                            DateOfBirth = new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "instructor@example.com",
                            FirstName = "Instructor",
                            LastName = "Instructor",
                            Password = "Instructor123",
                            Phone = "987-654-321",
                            Role = 1,
                            Username = "InstructorUser"
                        },
                        new
                        {
                            UserID = 3,
                            Avatar = "https://images.unsplash.com/photo-1638803040283-7a5ffd48dad5?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1yZWxhdGVkfDl8fHxlbnwwfHx8fHw%3D",
                            DateOfBirth = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "student@example.com",
                            FirstName = "Student",
                            LastName = "Student",
                            Password = "Student123",
                            Phone = "555-123-456",
                            Role = 2,
                            Username = "StudentUser"
                        });
                });

            modelBuilder.Entity("StudentManagement.Models.Entities.UserCoaching", b =>
                {
                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<int>("CoachingID")
                        .HasColumnType("int");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("UserID", "CoachingID");

                    b.HasIndex("CoachingID");

                    b.ToTable("UserCoachings");

                    b.HasData(
                        new
                        {
                            UserID = 3,
                            CoachingID = 1,
                            Role = 2
                        },
                        new
                        {
                            UserID = 3,
                            CoachingID = 2,
                            Role = 2
                        },
                        new
                        {
                            UserID = 2,
                            CoachingID = 1,
                            Role = 1
                        });
                });

            modelBuilder.Entity("StudentManagement.Models.Entities.UserCourse", b =>
                {
                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("UserID", "CourseID");

                    b.HasIndex("CourseID");

                    b.ToTable("UserCourses");

                    b.HasData(
                        new
                        {
                            UserID = 3,
                            CourseID = 1,
                            Role = 2
                        },
                        new
                        {
                            UserID = 3,
                            CourseID = 2,
                            Role = 2
                        },
                        new
                        {
                            UserID = 2,
                            CourseID = 3,
                            Role = 1
                        });
                });

            modelBuilder.Entity("StudentManagement.Models.Entities.Attendance", b =>
                {
                    b.HasOne("StudentManagement.Models.Entities.Training", "Training")
                        .WithMany("Attendances")
                        .HasForeignKey("TrainingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentManagement.Models.Entities.User", "User")
                        .WithMany("Attendances")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Training");

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudentManagement.Models.Entities.CourseTraining", b =>
                {
                    b.HasOne("StudentManagement.Models.Entities.Course", "Course")
                        .WithMany("CourseTrainings")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("StudentManagement.Models.Entities.Training", "Training")
                        .WithMany("CourseTrainings")
                        .HasForeignKey("TrainingID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Training");
                });

            modelBuilder.Entity("StudentManagement.Models.Entities.Grade", b =>
                {
                    b.HasOne("StudentManagement.Models.Entities.Training", "Training")
                        .WithMany("Grades")
                        .HasForeignKey("TrainingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentManagement.Models.Entities.User", "User")
                        .WithMany("Grades")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Training");

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudentManagement.Models.Entities.UserCoaching", b =>
                {
                    b.HasOne("StudentManagement.Models.Entities.Coaching", "Coaching")
                        .WithMany("UserCoachings")
                        .HasForeignKey("CoachingID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("StudentManagement.Models.Entities.User", "User")
                        .WithMany("UserCoachings")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Coaching");

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudentManagement.Models.Entities.UserCourse", b =>
                {
                    b.HasOne("StudentManagement.Models.Entities.Course", "Course")
                        .WithMany("UserCourses")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("StudentManagement.Models.Entities.User", "User")
                        .WithMany("UserCourses")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudentManagement.Models.Entities.Coaching", b =>
                {
                    b.Navigation("UserCoachings");
                });

            modelBuilder.Entity("StudentManagement.Models.Entities.Course", b =>
                {
                    b.Navigation("CourseTrainings");

                    b.Navigation("UserCourses");
                });

            modelBuilder.Entity("StudentManagement.Models.Entities.Training", b =>
                {
                    b.Navigation("Attendances");

                    b.Navigation("CourseTrainings");

                    b.Navigation("Grades");
                });

            modelBuilder.Entity("StudentManagement.Models.Entities.User", b =>
                {
                    b.Navigation("Attendances");

                    b.Navigation("Grades");

                    b.Navigation("UserCoachings");

                    b.Navigation("UserCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
