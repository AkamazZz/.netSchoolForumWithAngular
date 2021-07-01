using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class University : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "faculty",
                columns: table => new
                {
                    faculty_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    faculty_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_faculty", x => x.faculty_id);
                });

            migrationBuilder.CreateTable(
                name: "group",
                columns: table => new
                {
                    group_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    group_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_group", x => x.group_id);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    subject_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subject_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.subject_id);
                });

            migrationBuilder.CreateTable(
                name: "university",
                columns: table => new
                {
                    university_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    university_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_university", x => x.university_id);
                });

            migrationBuilder.CreateTable(
                name: "Specilaity",
                columns: table => new
                {
                    speciality_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    faculty_id = table.Column<int>(type: "int", nullable: false),
                    speciality_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specilaity", x => x.speciality_id);
                    table.ForeignKey(
                        name: "FK_Specilaity_faculty_faculty_id",
                        column: x => x.faculty_id,
                        principalTable: "faculty",
                        principalColumn: "faculty_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    teacher_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    university_id = table.Column<int>(type: "int", nullable: false),
                    teacher_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    teacher_surname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.teacher_id);
                    table.ForeignKey(
                        name: "FK_Teacher_university_university_id",
                        column: x => x.university_id,
                        principalTable: "university",
                        principalColumn: "university_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    university_id = table.Column<int>(type: "int", nullable: false),
                    speciality_id = table.Column<int>(type: "int", nullable: false),
                    faculty_id = table.Column<int>(type: "int", nullable: false),
                    group_id = table.Column<int>(type: "int", nullable: false),
                    student_name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    student_surname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.student_id);
                    table.ForeignKey(
                        name: "FK_Student_faculty_faculty_id",
                        column: x => x.faculty_id,
                        principalTable: "faculty",
                        principalColumn: "faculty_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_group_group_id",
                        column: x => x.group_id,
                        principalTable: "group",
                        principalColumn: "group_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_Specilaity_speciality_id",
                        column: x => x.speciality_id,
                        principalTable: "Specilaity",
                        principalColumn: "speciality_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_university_university_id",
                        column: x => x.university_id,
                        principalTable: "university",
                        principalColumn: "university_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teacher_subject",
                columns: table => new
                {
                    Teacher_Id = table.Column<int>(type: "int", nullable: false),
                    Subject_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher_subject", x => new { x.Teacher_Id, x.Subject_Id });
                    table.ForeignKey(
                        name: "FK_Teacher_subject_Subject_Subject_Id",
                        column: x => x.Subject_Id,
                        principalTable: "Subject",
                        principalColumn: "subject_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teacher_subject_Teacher_Teacher_Id",
                        column: x => x.Teacher_Id,
                        principalTable: "Teacher",
                        principalColumn: "teacher_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Assessment",
                columns: table => new
                {
                    assessment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    student_id = table.Column<int>(type: "int", nullable: false),
                    subject_id = table.Column<int>(type: "int", nullable: false),
                    grade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assessment", x => x.assessment_id);
                    table.ForeignKey(
                        name: "FK_Assessment_Student_student_id",
                        column: x => x.student_id,
                        principalTable: "Student",
                        principalColumn: "student_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assessment_Subject_subject_id",
                        column: x => x.subject_id,
                        principalTable: "Subject",
                        principalColumn: "subject_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Student_subject",
                columns: table => new
                {
                    Student_Id = table.Column<int>(type: "int", nullable: false),
                    Subject_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student_subject", x => new { x.Student_Id, x.Subject_Id });
                    table.ForeignKey(
                        name: "FK_Student_subject_Student_Student_Id",
                        column: x => x.Student_Id,
                        principalTable: "Student",
                        principalColumn: "student_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_subject_Subject_Subject_Id",
                        column: x => x.Subject_Id,
                        principalTable: "Subject",
                        principalColumn: "subject_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assessment_student_id",
                table: "Assessment",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "IX_Assessment_subject_id",
                table: "Assessment",
                column: "subject_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Specilaity_faculty_id",
                table: "Specilaity",
                column: "faculty_id");

            migrationBuilder.CreateIndex(
                name: "IX_Student_faculty_id",
                table: "Student",
                column: "faculty_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_group_id",
                table: "Student",
                column: "group_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_speciality_id",
                table: "Student",
                column: "speciality_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_university_id",
                table: "Student",
                column: "university_id");

            migrationBuilder.CreateIndex(
                name: "IX_Student_subject_Subject_Id",
                table: "Student_subject",
                column: "Subject_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_university_id",
                table: "Teacher",
                column: "university_id");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_subject_Subject_Id",
                table: "Teacher_subject",
                column: "Subject_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assessment");

            migrationBuilder.DropTable(
                name: "Student_subject");

            migrationBuilder.DropTable(
                name: "Teacher_subject");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "group");

            migrationBuilder.DropTable(
                name: "Specilaity");

            migrationBuilder.DropTable(
                name: "university");

            migrationBuilder.DropTable(
                name: "faculty");
        }
    }
}
