using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentManagment.Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    TrainingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.TrainingID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    AttendanceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    TrainingID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Present = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.AttendanceID);
                    table.ForeignKey(
                        name: "FK_Attendances_Trainings_TrainingID",
                        column: x => x.TrainingID,
                        principalTable: "Trainings",
                        principalColumn: "TrainingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    GradeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    TrainingID = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<float>(type: "real", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.GradeID);
                    table.ForeignKey(
                        name: "FK_Grades_Trainings_TrainingID",
                        column: x => x.TrainingID,
                        principalTable: "Trainings",
                        principalColumn: "TrainingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    InstructorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", maxLength: 20, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.InstructorID);
                    table.ForeignKey(
                        name: "FK_Instructors_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", maxLength: 20, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentID);
                    table.ForeignKey(
                        name: "FK_Students_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Coachings",
                columns: table => new
                {
                    CoachingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstructorID = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Topic = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Feedback = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coachings", x => x.CoachingID);
                    table.ForeignKey(
                        name: "FK_Coachings_Instructors_InstructorID",
                        column: x => x.InstructorID,
                        principalTable: "Instructors",
                        principalColumn: "InstructorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    InstructorID = table.Column<int>(type: "int", nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseID);
                    table.ForeignKey(
                        name: "FK_Courses_Instructors_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Instructors",
                        principalColumn: "InstructorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseTrainings",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    TrainingID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTrainings", x => new { x.CourseID, x.TrainingID });
                    table.ForeignKey(
                        name: "FK_CourseTrainings_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseTrainings_Trainings_TrainingID",
                        column: x => x.TrainingID,
                        principalTable: "Trainings",
                        principalColumn: "TrainingID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserCourses",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCourses", x => new { x.UserID, x.CourseID });
                    table.ForeignKey(
                        name: "FK_UserCourses_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserCourses_Users_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseID", "CourseName", "Description", "InstructorID" },
                values: new object[] { 3, "Mathematics Fundamentals", "Basic math concepts", 2 });

            migrationBuilder.InsertData(
                table: "Trainings",
                columns: new[] { "TrainingID", "EndDate", "Location", "StartDate", "Topic" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 3, 12, 50, 24, 633, DateTimeKind.Local).AddTicks(8840), "Room A", new DateTime(2024, 2, 3, 12, 50, 24, 633, DateTimeKind.Local).AddTicks(8838), "Programming Basics" },
                    { 2, new DateTime(2024, 4, 3, 12, 50, 24, 633, DateTimeKind.Local).AddTicks(8843), "Room B", new DateTime(2024, 3, 3, 12, 50, 24, 633, DateTimeKind.Local).AddTicks(8842), "Physics Fundamentals" },
                    { 3, new DateTime(2024, 3, 3, 12, 50, 24, 633, DateTimeKind.Local).AddTicks(8846), "Room C", new DateTime(2024, 2, 3, 12, 50, 24, 633, DateTimeKind.Local).AddTicks(8845), "Math Basics" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Email", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { 1, "admin@example.com", "Admin123", 0, "AdminUser" },
                    { 2, "instructor@example.com", "Instructor123", 1, "InstructorUser" },
                    { 3, "student@example.com", "Student123", 2, "StudentUser" }
                });

            migrationBuilder.InsertData(
                table: "Attendances",
                columns: new[] { "AttendanceID", "Date", "Present", "StudentID", "TrainingID" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 3, 12, 50, 24, 633, DateTimeKind.Local).AddTicks(8867), true, 3, 1 },
                    { 2, new DateTime(2024, 3, 3, 12, 50, 24, 633, DateTimeKind.Local).AddTicks(8869), false, 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "CourseTrainings",
                columns: new[] { "CourseID", "TrainingID" },
                values: new object[] { 3, 3 });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "GradeID", "Remarks", "Score", "StudentID", "TrainingID" },
                values: new object[,]
                {
                    { 1, "Good performance", 90f, 3, 1 },
                    { 2, "Excellent work", 95f, 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "InstructorID", "Address", "DateOfBirth", "FirstName", "LastName", "Phone", "UserID" },
                values: new object[,]
                {
                    { 1, "123 Main St", new DateTime(1994, 1, 3, 12, 50, 24, 633, DateTimeKind.Local).AddTicks(8758), "John", "Doe", "123456789", 2 },
                    { 2, "456 Oak St", new DateTime(1996, 1, 3, 12, 50, 24, 633, DateTimeKind.Local).AddTicks(8802), "Jane", "Smith", "987654321", 3 }
                });

            migrationBuilder.InsertData(
                table: "UserCourses",
                columns: new[] { "CourseID", "UserID" },
                values: new object[] { 3, 3 });

            migrationBuilder.InsertData(
                table: "Coachings",
                columns: new[] { "CoachingID", "EndDate", "Feedback", "InstructorID", "Location", "StartDate", "Topic" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 3, 12, 50, 24, 633, DateTimeKind.Local).AddTicks(8855), "Good performance", 1, "Room X", new DateTime(2024, 2, 3, 12, 50, 24, 633, DateTimeKind.Local).AddTicks(8854), "Advanced Programming" },
                    { 2, new DateTime(2024, 4, 3, 12, 50, 24, 633, DateTimeKind.Local).AddTicks(8858), "Excellent participation", 2, "Room Y", new DateTime(2024, 3, 3, 12, 50, 24, 633, DateTimeKind.Local).AddTicks(8857), "Advanced Physics" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseID", "CourseName", "Description", "InstructorID" },
                values: new object[,]
                {
                    { 1, "Introduction to Programming", "Learn the basics of programming", 1 },
                    { 2, "Physics 101", "Introduction to Physics", 1 }
                });

            migrationBuilder.InsertData(
                table: "CourseTrainings",
                columns: new[] { "CourseID", "TrainingID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "UserCourses",
                columns: new[] { "CourseID", "UserID" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 2, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_TrainingID",
                table: "Attendances",
                column: "TrainingID");

            migrationBuilder.CreateIndex(
                name: "IX_Coachings_InstructorID",
                table: "Coachings",
                column: "InstructorID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTrainings_TrainingID",
                table: "CourseTrainings",
                column: "TrainingID");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_TrainingID",
                table: "Grades",
                column: "TrainingID");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_UserID",
                table: "Instructors",
                column: "UserID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserID",
                table: "Students",
                column: "UserID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserCourses_CourseID",
                table: "UserCourses",
                column: "CourseID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "Coachings");

            migrationBuilder.DropTable(
                name: "CourseTrainings");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "UserCourses");

            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
