using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb4IndividuelltDatabasProjekt.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ClassID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ClassID);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CourseStatus = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, defaultValueSql: "('Active')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseID);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    GradesID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grade = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.GradesID);
                });

            migrationBuilder.CreateTable(
                name: "Proffesions",
                columns: table => new
                {
                    ProffesionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProffesionName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProffesionSalary = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proffesions", x => x.ProffesionID);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StudentLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SocialSecurityNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    StudentEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FKClassID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentID);
                    table.ForeignKey(
                        name: "FK_Students_Classes",
                        column: x => x.FKClassID,
                        principalTable: "Classes",
                        principalColumn: "ClassID");
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    StaffID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StaffLastName = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    FKProffesionID = table.Column<int>(type: "int", nullable: true),
                    StaffStartDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.StaffID);
                    table.ForeignKey(
                        name: "FK_Staffs_Proffesions",
                        column: x => x.FKProffesionID,
                        principalTable: "Proffesions",
                        principalColumn: "ProffesionID");
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    EnrollmentsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FKStudentID = table.Column<int>(type: "int", nullable: true),
                    FKCourseID = table.Column<int>(type: "int", nullable: true),
                    FKGradesID = table.Column<int>(type: "int", nullable: true),
                    FKStaffID = table.Column<int>(type: "int", nullable: true),
                    GradeSetDay = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.EnrollmentsID);
                    table.ForeignKey(
                        name: "FK_Enrollments_Courses",
                        column: x => x.FKCourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID");
                    table.ForeignKey(
                        name: "FK_Enrollments_Grades",
                        column: x => x.FKGradesID,
                        principalTable: "Grades",
                        principalColumn: "GradesID");
                    table.ForeignKey(
                        name: "FK_Enrollments_Staffs",
                        column: x => x.FKStaffID,
                        principalTable: "Staffs",
                        principalColumn: "StaffID");
                    table.ForeignKey(
                        name: "FK_Enrollments_Students1",
                        column: x => x.FKStudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_FKCourseID",
                table: "Enrollments",
                column: "FKCourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_FKGradesID",
                table: "Enrollments",
                column: "FKGradesID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_FKStaffID",
                table: "Enrollments",
                column: "FKStaffID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_FKStudentID",
                table: "Enrollments",
                column: "FKStudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_FKProffesionID",
                table: "Staffs",
                column: "FKProffesionID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_FKClassID",
                table: "Students",
                column: "FKClassID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Proffesions");

            migrationBuilder.DropTable(
                name: "Classes");
        }
    }
}
