using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_end.Migrations
{
    public partial class ServiceGoal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Services_ServiceID",
                table: "Results");

            migrationBuilder.DropIndex(
                name: "IX_Results_ServiceID",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "ServiceID",
                table: "Results");

            migrationBuilder.AddColumn<bool>(
                name: "FirstLogin",
                table: "AspNetUsers",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ServiceGoal",
                columns: table => new
                {
                    ServiceID = table.Column<int>(type: "int", nullable: false),
                    GoalID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceGoal", x => new { x.GoalID, x.ServiceID });
                    table.ForeignKey(
                        name: "FK_ServiceGoal_Goals_GoalID",
                        column: x => x.GoalID,
                        principalTable: "Goals",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceGoal_Services_ServiceID",
                        column: x => x.ServiceID,
                        principalTable: "Services",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ServiceResult",
                columns: table => new
                {
                    ResultID = table.Column<int>(type: "int", nullable: false),
                    ServiceID = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceResult", x => new { x.ResultID, x.ServiceID });
                    table.ForeignKey(
                        name: "FK_ServiceResult_Results_ResultID",
                        column: x => x.ResultID,
                        principalTable: "Results",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceResult_Services_ServiceID",
                        column: x => x.ServiceID,
                        principalTable: "Services",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "576192a1-8f05-4d02-95f0-7723015f527e", "AQAAAAEAACcQAAAAEMKmAhC46LL8dpBuCiTaRUmg/zYiiBRPfmQIUp6DVsxWn7LyryohxlBEaLyPZKfAiA==", "0c006121-ca88-43f2-b67e-9d5ba95b862b" });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceGoal_ServiceID",
                table: "ServiceGoal",
                column: "ServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceResult_ServiceID",
                table: "ServiceResult",
                column: "ServiceID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceGoal");

            migrationBuilder.DropTable(
                name: "ServiceResult");

            migrationBuilder.DropColumn(
                name: "FirstLogin",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "ServiceID",
                table: "Results",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d2286a95-a54b-4db7-9cdc-6e998c29fcfb", "AQAAAAEAACcQAAAAEOad6x605rGjQv65fpUxa3VUCoCe/ygL4rVSn/+k6/AXf6vK4zNMqlX9lHYPLgo6DQ==", "e69569d4-fef0-4168-89ef-c1ee07d5202d" });

            migrationBuilder.CreateIndex(
                name: "IX_Results_ServiceID",
                table: "Results",
                column: "ServiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Services_ServiceID",
                table: "Results",
                column: "ServiceID",
                principalTable: "Services",
                principalColumn: "ID");
        }
    }
}
