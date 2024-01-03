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

                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.Property<int>("TrainingID")
                        .HasColumnType("int");

                    b.HasKey("AttendanceID");

                    b.HasIndex("TrainingID");

                    b.ToTable("Attendances");

                    b.HasData(
                        new
                        {
                            AttendanceID = 1,
                            Date = new DateTime(2024, 2, 3, 12, 50, 24, 633, DateTimeKind.Local).AddTicks(8867),
                            Present = true,
                            StudentID = 3,
                            TrainingID = 1
                        },
                        new
                        {
                            AttendanceID = 2,
                            Date = new DateTime(2024, 3, 3, 12, 50, 24, 633, DateTimeKind.Local).AddTicks(8869),
                            Present = false,
                            StudentID = 3,
                            TrainingID = 2
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

                    b.Property<int>("InstructorID")
                        .HasColumnType("int");

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

                    b.HasIndex("InstructorID");

                    b.ToTable("Coachings");

                    b.HasData(
                        new
                        {
                            CoachingID = 1,
                            EndDate = new DateTime(2024, 3, 3, 12, 50, 24, 633, DateTimeKind.Local).AddTicks(8855),
                            Feedback = "Good performance",
                            InstructorID = 1,
                            Location = "Room X",
                            StartDate = new DateTime(2024, 2, 3, 12, 50, 24, 633, DateTimeKind.Local).AddTicks(8854),
                            Topic = "Advanced Programming"
                        },
                        new
                        {
                            CoachingID = 2,
                            EndDate = new DateTime(2024, 4, 3, 12, 50, 24, 633, DateTimeKind.Local).AddTicks(8858),
                            Feedback = "Excellent participation",
                            InstructorID = 2,
                            Location = "Room Y",
                            StartDate = new DateTime(2024, 3, 3, 12, 50, 24, 633, DateTimeKind.Local).AddTicks(8857),
                            Topic = "Advanced Physics"
                        });
                });

            modelBuilder.Entity("StudentManagement.Models.Entities.Course", b =>
                {
                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InstructorID")
                        .HasColumnType("int");

                    b.HasKey("CourseID");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            CourseID = 1,
                            CourseName = "Introduction to Programming",
                            Description = "Learn the basics of programming",
                            InstructorID = 1
                        },
                        new
                        {
                            CourseID = 2,
                            CourseName = "Physics 101",
                            Description = "Introduction to Physics",
                            InstructorID = 1
                        },
                        new
                        {
                            CourseID = 3,
                            CourseName = "Mathematics Fundamentals",
                            Description = "Basic math concepts",
                            InstructorID = 2
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

                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.Property<int>("TrainingID")
                        .HasColumnType("int");

                    b.HasKey("GradeID");

                    b.HasIndex("TrainingID");

                    b.ToTable("Grades");

                    b.HasData(
                        new
                        {
                            GradeID = 1,
                            Remarks = "Good performance",
                            Score = 90f,
                            StudentID = 3,
                            TrainingID = 1
                        },
                        new
                        {
                            GradeID = 2,
                            Remarks = "Excellent work",
                            Score = 95f,
                            StudentID = 3,
                            TrainingID = 2
                        });
                });

            modelBuilder.Entity("StudentManagement.Models.Entities.Instructor", b =>
                {
                    b.Property<int>("InstructorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InstructorID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasMaxLength(20)
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("InstructorID");

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("Instructors");

                    b.HasData(
                        new
                        {
                            InstructorID = 1,
                            Address = "123 Main St",
                            DateOfBirth = new DateTime(1994, 1, 3, 12, 50, 24, 633, DateTimeKind.Local).AddTicks(8758),
                            FirstName = "John",
                            LastName = "Doe",
                            Phone = "123456789",
                            UserID = 2
                        },
                        new
                        {
                            InstructorID = 2,
                            Address = "456 Oak St",
                            DateOfBirth = new DateTime(1996, 1, 3, 12, 50, 24, 633, DateTimeKind.Local).AddTicks(8802),
                            FirstName = "Jane",
                            LastName = "Smith",
                            Phone = "987654321",
                            UserID = 3
                        });
                });

            modelBuilder.Entity("StudentManagement.Models.Entities.Student", b =>
                {
                    b.Property<int>("StudentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasMaxLength(20)
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("StudentID");

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("Students");
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
                            EndDate = new DateTime(2024, 3, 3, 12, 50, 24, 633, DateTimeKind.Local).AddTicks(8840),
                            Location = "Room A",
                            StartDate = new DateTime(2024, 2, 3, 12, 50, 24, 633, DateTimeKind.Local).AddTicks(8838),
                            Topic = "Programming Basics"
                        },
                        new
                        {
                            TrainingID = 2,
                            EndDate = new DateTime(2024, 4, 3, 12, 50, 24, 633, DateTimeKind.Local).AddTicks(8843),
                            Location = "Room B",
                            StartDate = new DateTime(2024, 3, 3, 12, 50, 24, 633, DateTimeKind.Local).AddTicks(8842),
                            Topic = "Physics Fundamentals"
                        },
                        new
                        {
                            TrainingID = 3,
                            EndDate = new DateTime(2024, 3, 3, 12, 50, 24, 633, DateTimeKind.Local).AddTicks(8846),
                            Location = "Room C",
                            StartDate = new DateTime(2024, 2, 3, 12, 50, 24, 633, DateTimeKind.Local).AddTicks(8845),
                            Topic = "Math Basics"
                        });
                });

            modelBuilder.Entity("StudentManagement.Models.Entities.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

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
                            Email = "admin@example.com",
                            Password = "Admin123",
                            Role = 0,
                            Username = "AdminUser"
                        },
                        new
                        {
                            UserID = 2,
                            Email = "instructor@example.com",
                            Password = "Instructor123",
                            Role = 1,
                            Username = "InstructorUser"
                        },
                        new
                        {
                            UserID = 3,
                            Email = "student@example.com",
                            Password = "Student123",
                            Role = 2,
                            Username = "StudentUser"
                        });
                });

            modelBuilder.Entity("StudentManagement.Models.Entities.UserCourse", b =>
                {
                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.HasKey("UserID", "CourseID");

                    b.HasIndex("CourseID");

                    b.ToTable("UserCourses");

                    b.HasData(
                        new
                        {
                            UserID = 3,
                            CourseID = 1
                        },
                        new
                        {
                            UserID = 3,
                            CourseID = 2
                        },
                        new
                        {
                            UserID = 3,
                            CourseID = 3
                        });
                });

            modelBuilder.Entity("StudentManagement.Models.Entities.Attendance", b =>
                {
                    b.HasOne("StudentManagement.Models.Entities.Training", "Training")
                        .WithMany("Attendances")
                        .HasForeignKey("TrainingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Training");
                });

            modelBuilder.Entity("StudentManagement.Models.Entities.Coaching", b =>
                {
                    b.HasOne("StudentManagement.Models.Entities.Instructor", "Instructor")
                        .WithMany("Coachings")
                        .HasForeignKey("InstructorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("StudentManagement.Models.Entities.Course", b =>
                {
                    b.HasOne("StudentManagement.Models.Entities.Instructor", "Instructor")
                        .WithMany("Courses")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Instructor");
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

                    b.Navigation("Training");
                });

            modelBuilder.Entity("StudentManagement.Models.Entities.Instructor", b =>
                {
                    b.HasOne("StudentManagement.Models.Entities.User", "User")
                        .WithOne("Instructor")
                        .HasForeignKey("StudentManagement.Models.Entities.Instructor", "UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudentManagement.Models.Entities.Student", b =>
                {
                    b.HasOne("StudentManagement.Models.Entities.User", "User")
                        .WithOne("Student")
                        .HasForeignKey("StudentManagement.Models.Entities.Student", "UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudentManagement.Models.Entities.Course", b =>
                {
                    b.Navigation("CourseTrainings");

                    b.Navigation("UserCourses");
                });

            modelBuilder.Entity("StudentManagement.Models.Entities.Instructor", b =>
                {
                    b.Navigation("Coachings");

                    b.Navigation("Courses");
                });

            modelBuilder.Entity("StudentManagement.Models.Entities.Training", b =>
                {
                    b.Navigation("Attendances");

                    b.Navigation("CourseTrainings");

                    b.Navigation("Grades");
                });

            modelBuilder.Entity("StudentManagement.Models.Entities.User", b =>
                {
                    b.Navigation("Instructor")
                        .IsRequired();

                    b.Navigation("Student")
                        .IsRequired();

                    b.Navigation("UserCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
