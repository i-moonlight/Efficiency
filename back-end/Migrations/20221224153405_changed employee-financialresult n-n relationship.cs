using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_end.Migrations
{
    public partial class changedemployeefinancialresultnnrelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeesFinancialResults",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    FinancialResultID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesFinancialResults", x => new { x.EmployeeID, x.FinancialResultID });
                    table.ForeignKey(
                        name: "FK_EmployeesFinancialResults_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "RegistrationNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeesFinancialResults_FinancialResults_FinancialResultID",
                        column: x => x.FinancialResultID,
                        principalTable: "FinancialResults",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesFinancialResults_FinancialResultID",
                table: "EmployeesFinancialResults",
                column: "FinancialResultID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeesFinancialResults");
        }
    }
}
