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
                name: "Coachings",
                columns: table => new
                {
                    CoachingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Topic = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Feedback = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coachings", x => x.CoachingID);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseID);
                });

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
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", maxLength: 20, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
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
                name: "Attendances",
                columns: table => new
                {
                    AttendanceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_Attendances_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    GradeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_Grades_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserCoachings",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false),
                    CoachingID = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCoachings", x => new { x.UserID, x.CoachingID });
                    table.ForeignKey(
                        name: "FK_UserCoachings_Coachings_CoachingID",
                        column: x => x.CoachingID,
                        principalTable: "Coachings",
                        principalColumn: "CoachingID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserCoachings_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserCourses",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_UserCourses_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Coachings",
                columns: new[] { "CoachingID", "EndDate", "Feedback", "Location", "StartDate", "Topic" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 17, 15, 54, 7, 844, DateTimeKind.Local).AddTicks(3156), "Good performance", "Room X", new DateTime(2024, 2, 17, 15, 54, 7, 844, DateTimeKind.Local).AddTicks(3155), "Advanced Programming" },
                    { 2, new DateTime(2024, 4, 17, 15, 54, 7, 844, DateTimeKind.Local).AddTicks(3163), "Excellent participation", "Room Y", new DateTime(2024, 3, 17, 15, 54, 7, 844, DateTimeKind.Local).AddTicks(3161), "Advanced Physics" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseID", "CourseName", "Description" },
                values: new object[,]
                {
                    { 1, "Introduction to Programming", "Learn the basics of programming" },
                    { 2, "Physics 101", "Introduction to Physics" },
                    { 3, "Mathematics Fundamentals", "Basic math concepts" }
                });

            migrationBuilder.InsertData(
                table: "Trainings",
                columns: new[] { "TrainingID", "EndDate", "Location", "StartDate", "Topic" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 17, 15, 54, 7, 844, DateTimeKind.Local).AddTicks(3131), "Room A", new DateTime(2024, 2, 17, 15, 54, 7, 844, DateTimeKind.Local).AddTicks(3090), "Programming Basics" },
                    { 2, new DateTime(2024, 4, 17, 15, 54, 7, 844, DateTimeKind.Local).AddTicks(3138), "Room B", new DateTime(2024, 3, 17, 15, 54, 7, 844, DateTimeKind.Local).AddTicks(3137), "Physics Fundamentals" },
                    { 3, new DateTime(2024, 3, 17, 15, 54, 7, 844, DateTimeKind.Local).AddTicks(3142), "Room C", new DateTime(2024, 2, 17, 15, 54, 7, 844, DateTimeKind.Local).AddTicks(3141), "Math Basics" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Phone", "Role", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@example.com", "Admin", "Admin", "Admin123", "123-456-789", 0, "AdminUser" },
                    { 2, new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "instructor@example.com", "Instructor", "Instructor", "Instructor123", "987-654-321", 1, "InstructorUser" },
                    { 3, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "student@example.com", "Student", "Student", "Student123", "555-123-456", 2, "StudentUser" }
                });

            migrationBuilder.InsertData(
                table: "Attendances",
                columns: new[] { "AttendanceID", "Date", "Present", "TrainingID", "UserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 17, 15, 54, 7, 844, DateTimeKind.Local).AddTicks(3185), true, 1, 3 },
                    { 2, new DateTime(2024, 3, 17, 15, 54, 7, 844, DateTimeKind.Local).AddTicks(3189), false, 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "CourseTrainings",
                columns: new[] { "CourseID", "TrainingID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "GradeID", "Remarks", "Score", "TrainingID", "UserID" },
                values: new object[,]
                {
                    { 1, "Good performance", 90f, 1, 3 },
                    { 2, "Excellent work", 95f, 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "UserCoachings",
                columns: new[] { "CoachingID", "UserID", "Role" },
                values: new object[,]
                {
                    { 1, 2, 1 },
                    { 1, 3, 2 },
                    { 2, 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "UserCourses",
                columns: new[] { "CourseID", "UserID", "Role" },
                values: new object[,]
                {
                    { 3, 2, 1 },
                    { 1, 3, 2 },
                    { 2, 3, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_TrainingID",
                table: "Attendances",
                column: "TrainingID");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_UserID",
                table: "Attendances",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTrainings_TrainingID",
                table: "CourseTrainings",
                column: "TrainingID");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_TrainingID",
                table: "Grades",
                column: "TrainingID");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_UserID",
                table: "Grades",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserCoachings_CoachingID",
                table: "UserCoachings",
                column: "CoachingID");

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
                name: "CourseTrainings");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "UserCoachings");

            migrationBuilder.DropTable(
                name: "UserCourses");

            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.DropTable(
                name: "Coachings");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
