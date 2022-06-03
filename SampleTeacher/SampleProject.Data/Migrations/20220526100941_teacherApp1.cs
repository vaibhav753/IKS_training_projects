using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleProject.Data.Migrations
{
    public partial class teacherApp1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "teacherModel",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Skills = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalStudents = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<float>(type: "real", nullable: false),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teacherModel", x => x.TeacherId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "teacherModel");
        }
    }
}
