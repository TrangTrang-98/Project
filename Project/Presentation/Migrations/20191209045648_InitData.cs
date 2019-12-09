using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Presentation.Migrations
{
    public partial class InitData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Roles = table.Column<string>(nullable: true)
                    
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 40, nullable: false),
                    BirthDay = table.Column<DateTime>(nullable: false),
                    NumHouse = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    AccountUsername = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(maxLength: 10, nullable: false),
                    Gender = table.Column<int>(maxLength: 84, nullable: false),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Accounts_AccountUsername",
                        column: x => x.AccountUsername,
                        principalTable: "Accounts",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 40, nullable: false),
                    BirthDay = table.Column<DateTime>(nullable: false),
                    Address_NumHouse = table.Column<string>(nullable: true),
                    Address_Street = table.Column<string>(nullable: true),
                    Address_District = table.Column<string>(nullable: true),
                    Address_City = table.Column<string>(nullable: true),
                    Address_Country = table.Column<string>(nullable: true),
                    AccountUsername = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(maxLength: 10, nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    DeptId = table.Column<string>(nullable: true),
                    DepartmentDeptId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Accounts_AccountUsername",
                        column: x => x.AccountUsername,
                        principalTable: "Accounts",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DeptId = table.Column<string>(nullable: false),
                    DeptName = table.Column<string>(nullable: true),
                    DoctorId = table.Column<string>(nullable: true),
                    DoctorHead = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DeptId);
                    table.ForeignKey(
                        name: "FK_Departments_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    PatientId = table.Column<string>(nullable: false),
                    DoctorId = table.Column<string>(nullable: false),
                    EnrollmentDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => new { x.PatientId, x.DoctorId });
                    table.ForeignKey(
                        name: "FK_Enrollments_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_DoctorId",
                table: "Departments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_AccountUsername",
                table: "Doctors",
                column: "AccountUsername");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DepartmentDeptId",
                table: "Doctors",
                column: "DepartmentDeptId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_DoctorId",
                table: "Enrollments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_AccountUsername",
                table: "Patients",
                column: "AccountUsername");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Departments_DepartmentDeptId",
                table: "Doctors",
                column: "DepartmentDeptId",
                principalTable: "Departments",
                principalColumn: "DeptId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Doctors_DoctorId",
                table: "Departments");

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
