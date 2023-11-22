using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace coreData.Migrations
{
    public partial class create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dutys",
                columns: table => new
                {
                    DutyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DutyDefinition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DutyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DutyPoint = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dutys", x => x.DutyID);
                });

            migrationBuilder.CreateTable(
                name: "titles",
                columns: table => new
                {
                    TitleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_titles", x => x.TitleID);
                });

            migrationBuilder.CreateTable(
                name: "units",
                columns: table => new
                {
                    UnitsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitsName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberofEmployee = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_units", x => x.UnitsID);
                });

            migrationBuilder.CreateTable(
                name: "projects",
                columns: table => new
                {
                    ProjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectsName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateofStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateofEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DutyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects", x => x.ProjectID);
                    table.ForeignKey(
                        name: "FK_projects_dutys_DutyID",
                        column: x => x.DutyID,
                        principalTable: "dutys",
                        principalColumn: "DutyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateofStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Shift = table.Column<bool>(type: "bit", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Bounty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DutyID = table.Column<int>(type: "int", nullable: false),
                    TitleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_employees_dutys_DutyID",
                        column: x => x.DutyID,
                        principalTable: "dutys",
                        principalColumn: "DutyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_employees_titles_TitleID",
                        column: x => x.TitleID,
                        principalTable: "titles",
                        principalColumn: "TitleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DutyUnits",
                columns: table => new
                {
                    DutyID = table.Column<int>(type: "int", nullable: false),
                    UnitsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DutyUnits", x => new { x.DutyID, x.UnitsID });
                    table.ForeignKey(
                        name: "FK_DutyUnits_dutys_DutyID",
                        column: x => x.DutyID,
                        principalTable: "dutys",
                        principalColumn: "DutyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DutyUnits_units_UnitsID",
                        column: x => x.UnitsID,
                        principalTable: "units",
                        principalColumn: "UnitsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "kids",
                columns: table => new
                {
                    KidID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSurname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateofBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kids", x => x.KidID);
                    table.ForeignKey(
                        name: "FK_kids_employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DutyUnits_UnitsID",
                table: "DutyUnits",
                column: "UnitsID");

            migrationBuilder.CreateIndex(
                name: "IX_employees_DutyID",
                table: "employees",
                column: "DutyID");

            migrationBuilder.CreateIndex(
                name: "IX_employees_TitleID",
                table: "employees",
                column: "TitleID");

            migrationBuilder.CreateIndex(
                name: "IX_kids_EmployeeID",
                table: "kids",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_projects_DutyID",
                table: "projects",
                column: "DutyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DutyUnits");

            migrationBuilder.DropTable(
                name: "kids");

            migrationBuilder.DropTable(
                name: "projects");

            migrationBuilder.DropTable(
                name: "units");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "dutys");

            migrationBuilder.DropTable(
                name: "titles");
        }
    }
}
