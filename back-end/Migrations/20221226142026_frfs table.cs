using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_end.Migrations
{
    public partial class frfstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FResultsFServices_FinancialResults_FinancialResultID",
                table: "FResultsFServices");

            migrationBuilder.DropForeignKey(
                name: "FK_FResultsFServices_FinancialServices_FinancialServiceID",
                table: "FResultsFServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FResultsFServices",
                table: "FResultsFServices");

            migrationBuilder.RenameTable(
                name: "FResultsFServices",
                newName: "FinancialResultsFinancialServices");

            migrationBuilder.RenameIndex(
                name: "IX_FResultsFServices_FinancialServiceID",
                table: "FinancialResultsFinancialServices",
                newName: "IX_FinancialResultsFinancialServices_FinancialServiceID");

            migrationBuilder.RenameIndex(
                name: "IX_FResultsFServices_FinancialResultID",
                table: "FinancialResultsFinancialServices",
                newName: "IX_FinancialResultsFinancialServices_FinancialResultID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FinancialResultsFinancialServices",
                table: "FinancialResultsFinancialServices",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialResultsFinancialServices_FinancialResults_Financial~",
                table: "FinancialResultsFinancialServices",
                column: "FinancialResultID",
                principalTable: "FinancialResults",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialResultsFinancialServices_FinancialServices_Financia~",
                table: "FinancialResultsFinancialServices",
                column: "FinancialServiceID",
                principalTable: "FinancialServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinancialResultsFinancialServices_FinancialResults_Financial~",
                table: "FinancialResultsFinancialServices");

            migrationBuilder.DropForeignKey(
                name: "FK_FinancialResultsFinancialServices_FinancialServices_Financia~",
                table: "FinancialResultsFinancialServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FinancialResultsFinancialServices",
                table: "FinancialResultsFinancialServices");

            migrationBuilder.RenameTable(
                name: "FinancialResultsFinancialServices",
                newName: "FResultsFServices");

            migrationBuilder.RenameIndex(
                name: "IX_FinancialResultsFinancialServices_FinancialServiceID",
                table: "FResultsFServices",
                newName: "IX_FResultsFServices_FinancialServiceID");

            migrationBuilder.RenameIndex(
                name: "IX_FinancialResultsFinancialServices_FinancialResultID",
                table: "FResultsFServices",
                newName: "IX_FResultsFServices_FinancialResultID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FResultsFServices",
                table: "FResultsFServices",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_FResultsFServices_FinancialResults_FinancialResultID",
                table: "FResultsFServices",
                column: "FinancialResultID",
                principalTable: "FinancialResults",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FResultsFServices_FinancialServices_FinancialServiceID",
                table: "FResultsFServices",
                column: "FinancialServiceID",
                principalTable: "FinancialServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
