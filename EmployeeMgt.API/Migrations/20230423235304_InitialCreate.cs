using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeMgt.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    Photopath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "DepartmentName" },
                values: new object[,]
                {
                    { 1, "IT" },
                    { 2, "HR" },
                    { 3, "Payroll" },
                    { 4, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "DateOfBirth", "DepartmentId", "Email", "FirstName", "Gender", "LastName", "Photopath" },
                values: new object[,]
                {
                    { 1, new DateTime(1983, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "ebedo4real2015@gmail.com", "Imo", 0, "Ebere", "../css/Image/1.png" },
                    { 2, new DateTime(1991, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "ebedo4real@gmail.com", "Test", 1, "ImoTest", "../css/Image/12.png" },
                    { 3, new DateTime(1997, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "wisdom4real@gmail.com", "Nwachukwu", 0, "Wisdom", "../css/Image/13.png" },
                    { 4, new DateTime(1998, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "nduagu@gmail.com", "Ndubisi", 0, "Agu", "../css/Image/22.jpg" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
