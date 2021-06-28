using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DAL.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LecturerType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LecturerType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Semester",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semester", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeSlot",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time(0)", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time(0)", nullable: false),
                    PriorityPoint = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSlot", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Blog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiledDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    BlogCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blog_BlogCategory",
                        column: x => x.BlogCategoryId,
                        principalTable: "BlogCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectCode = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PreviousCode = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subject_Department",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: true),
                    Fullname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Birthdate = table.Column<DateTime>(type: "date", nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: false),
                    Gender = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    CreateBy = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false),
                    AvatarLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_1", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Role",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MasterPlan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SemesterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterPlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MasterPlan_Semester",
                        column: x => x.SemesterId,
                        principalTable: "Semester",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentBlog",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    BlogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentBlog", x => new { x.DepartmentId, x.BlogId });
                    table.ForeignKey(
                        name: "FK_DepartmentBlog_Blog",
                        column: x => x.BlogId,
                        principalTable: "Blog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DepartmentBlog_Department",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    SemesterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Course_Semester",
                        column: x => x.SemesterId,
                        principalTable: "Semester",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Course_Subject1",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lecturer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    MaxCourse = table.Column<int>(type: "int", nullable: false),
                    MinCourse = table.Column<int>(type: "int", nullable: false),
                    LecturerTypeId = table.Column<int>(type: "int", nullable: false),
                    PriorityPoint = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", unicode: false, maxLength: 32, nullable: false),
                    LecturerCode = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lecturer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lecture_Department",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lecture_LecturerType",
                        column: x => x.LecturerTypeId,
                        principalTable: "LecturerType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lecture_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SemesterPlan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SemesterId = table.Column<int>(type: "int", nullable: false),
                    MasterPlanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SemesterPlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SemesterPlan_MasterPlan",
                        column: x => x.MasterPlanId,
                        principalTable: "MasterPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SemesterPlan_Semester",
                        column: x => x.SemesterId,
                        principalTable: "Semester",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LectureSemesterRegister",
                columns: table => new
                {
                    LecturerId = table.Column<int>(type: "int", nullable: false),
                    SemesterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LectureSemesterRegister", x => new { x.LecturerId, x.SemesterId });
                    table.ForeignKey(
                        name: "FK_LectureSemesterRegister_Lecture",
                        column: x => x.LecturerId,
                        principalTable: "Lecturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LectureSemesterRegister_Semester",
                        column: x => x.SemesterId,
                        principalTable: "Semester",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeachableSubject",
                columns: table => new
                {
                    LecturerId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    PreferPoint = table.Column<int>(type: "int", nullable: false),
                    MatchPoint = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreferSubject", x => new { x.LecturerId, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_PreferSubject_Lecture",
                        column: x => x.LecturerId,
                        principalTable: "Lecturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeachableSubject_Subject",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LecturerRating",
                columns: table => new
                {
                    LecturerId = table.Column<int>(type: "int", nullable: false),
                    SemesterPlanId = table.Column<int>(type: "int", nullable: false),
                    RatePoint = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LecturerRating", x => new { x.LecturerId, x.SemesterPlanId });
                    table.ForeignKey(
                        name: "FK_LecturerRating_Lecture",
                        column: x => x.LecturerId,
                        principalTable: "Lecturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LecturerRating_SemesterPlan",
                        column: x => x.SemesterPlanId,
                        principalTable: "SemesterPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubjectRegister",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LecturerId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    SemesterPlanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectRegister", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectRegister_Lecture",
                        column: x => x.LecturerId,
                        principalTable: "Lecturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubjectRegister_SemesterPlan",
                        column: x => x.SemesterPlanId,
                        principalTable: "SemesterPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubjectRegister_Subject1",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TimeSlotRegister",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PreferPoint = table.Column<int>(type: "int", nullable: false),
                    SemesterPlanId = table.Column<int>(type: "int", nullable: false),
                    LecturerId = table.Column<int>(type: "int", nullable: false),
                    TimeSlotId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSlotRegister", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeSlotRegister_Lecture",
                        column: x => x.LecturerId,
                        principalTable: "Lecturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TimeSlotRegister_SemesterPlan",
                        column: x => x.SemesterPlanId,
                        principalTable: "SemesterPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TimeSlotRegister_TimeSlot",
                        column: x => x.TimeSlotId,
                        principalTable: "TimeSlot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blog_BlogCategoryId",
                table: "Blog",
                column: "BlogCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_SemesterId",
                table: "Course",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_SubjectId",
                table: "Course",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentBlog_BlogId",
                table: "DepartmentBlog",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_Lecturer_DepartmentId",
                table: "Lecturer",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Lecturer_LecturerTypeId",
                table: "Lecturer",
                column: "LecturerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Lecturer_UserId",
                table: "Lecturer",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LecturerRating_SemesterPlanId",
                table: "LecturerRating",
                column: "SemesterPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_LectureSemesterRegister_SemesterId",
                table: "LectureSemesterRegister",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterPlan_SemesterId",
                table: "MasterPlan",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_SemesterPlan_MasterPlanId",
                table: "SemesterPlan",
                column: "MasterPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_SemesterPlan_SemesterId",
                table: "SemesterPlan",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_DepartmentId",
                table: "Subject",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectRegister_LecturerId",
                table: "SubjectRegister",
                column: "LecturerId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectRegister_SemesterPlanId",
                table: "SubjectRegister",
                column: "SemesterPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectRegister_SubjectId",
                table: "SubjectRegister",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TeachableSubject_SubjectId",
                table: "TeachableSubject",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlotRegister_LecturerId",
                table: "TimeSlotRegister",
                column: "LecturerId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlotRegister_SemesterPlanId",
                table: "TimeSlotRegister",
                column: "SemesterPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlotRegister_TimeSlotId",
                table: "TimeSlotRegister",
                column: "TimeSlotId");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "DepartmentBlog");

            migrationBuilder.DropTable(
                name: "LecturerRating");

            migrationBuilder.DropTable(
                name: "LectureSemesterRegister");

            migrationBuilder.DropTable(
                name: "SubjectRegister");

            migrationBuilder.DropTable(
                name: "TeachableSubject");

            migrationBuilder.DropTable(
                name: "TimeSlotRegister");

            migrationBuilder.DropTable(
                name: "Blog");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "Lecturer");

            migrationBuilder.DropTable(
                name: "SemesterPlan");

            migrationBuilder.DropTable(
                name: "TimeSlot");

            migrationBuilder.DropTable(
                name: "BlogCategory");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "LecturerType");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "MasterPlan");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Semester");
        }
    }
}
