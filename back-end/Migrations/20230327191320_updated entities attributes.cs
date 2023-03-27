using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_end.Migrations
{
    public partial class updatedentitiesattributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goals_Services_ServiceID",
                table: "Goals");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceGoal_Goals_GoalID",
                table: "ServiceGoal");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceGoal_Services_ServiceID",
                table: "ServiceGoal");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceResult_Results_ResultID",
                table: "ServiceResult");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceResult_Services_ServiceID",
                table: "ServiceResult");

            migrationBuilder.DropIndex(
                name: "IX_Goals_ServiceID",
                table: "Goals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceResult",
                table: "ServiceResult");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceGoal",
                table: "ServiceGoal");

            migrationBuilder.DropColumn(
                name: "ServiceID",
                table: "Goals");

            migrationBuilder.RenameTable(
                name: "ServiceResult",
                newName: "ServicesResult");

            migrationBuilder.RenameTable(
                name: "ServiceGoal",
                newName: "ServicesGoal");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceResult_ServiceID",
                table: "ServicesResult",
                newName: "IX_ServicesResult_ServiceID");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceGoal_ServiceID",
                table: "ServicesGoal",
                newName: "IX_ServicesGoal_ServiceID");

            migrationBuilder.AddColumn<decimal>(
                name: "Value",
                table: "ServicesGoal",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServicesResult",
                table: "ServicesResult",
                columns: new[] { "ResultID", "ServiceID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServicesGoal",
                table: "ServicesGoal",
                columns: new[] { "GoalID", "ServiceID" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9999,
                columns: new[] { "ConcurrencyStamp", "FirstLogin", "PasswordHash", "SecurityStamp", "SubscriptionBegin", "SubscriptionExpiration", "SubscriptionType" },
                values: new object[] { "35a07c63-4161-4def-b37e-e3537449b798", true, "AQAAAAEAACcQAAAAEDcQGA7Fr3QLOGGFZDC1NSi6xfE5BhkgO0TlNelH2XYwhaJhJZnpoYTJAeSwa4VCpQ==", "d8448418-b4fc-4407-a1d3-e80696e62d89", new DateTime(2023, 3, 27, 19, 13, 20, 190, DateTimeKind.Utc).AddTicks(7728), new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), 120000 });

            migrationBuilder.AddForeignKey(
                name: "FK_ServicesGoal_Goals_GoalID",
                table: "ServicesGoal",
                column: "GoalID",
                principalTable: "Goals",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServicesGoal_Services_ServiceID",
                table: "ServicesGoal",
                column: "ServiceID",
                principalTable: "Services",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServicesResult_Results_ResultID",
                table: "ServicesResult",
                column: "ResultID",
                principalTable: "Results",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServicesResult_Services_ServiceID",
                table: "ServicesResult",
                column: "ServiceID",
                principalTable: "Services",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServicesGoal_Goals_GoalID",
                table: "ServicesGoal");

            migrationBuilder.DropForeignKey(
                name: "FK_ServicesGoal_Services_ServiceID",
                table: "ServicesGoal");

            migrationBuilder.DropForeignKey(
                name: "FK_ServicesResult_Results_ResultID",
                table: "ServicesResult");

            migrationBuilder.DropForeignKey(
                name: "FK_ServicesResult_Services_ServiceID",
                table: "ServicesResult");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServicesResult",
                table: "ServicesResult");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServicesGoal",
                table: "ServicesGoal");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "ServicesGoal");

            migrationBuilder.RenameTable(
                name: "ServicesResult",
                newName: "ServiceResult");

            migrationBuilder.RenameTable(
                name: "ServicesGoal",
                newName: "ServiceGoal");

            migrationBuilder.RenameIndex(
                name: "IX_ServicesResult_ServiceID",
                table: "ServiceResult",
                newName: "IX_ServiceResult_ServiceID");

            migrationBuilder.RenameIndex(
                name: "IX_ServicesGoal_ServiceID",
                table: "ServiceGoal",
                newName: "IX_ServiceGoal_ServiceID");

            migrationBuilder.AddColumn<int>(
                name: "ServiceID",
                table: "Goals",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceResult",
                table: "ServiceResult",
                columns: new[] { "ResultID", "ServiceID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceGoal",
                table: "ServiceGoal",
                columns: new[] { "GoalID", "ServiceID" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9999,
                columns: new[] { "ConcurrencyStamp", "FirstLogin", "PasswordHash", "SecurityStamp", "SubscriptionBegin", "SubscriptionExpiration", "SubscriptionType" },
                values: new object[] { "51d49b8a-44b5-4a17-bce7-09aae7470565", null, "AQAAAAEAACcQAAAAEMMRvuoVdUZvnDdRWTuf+gmiX3uiYsH1AtTt4QQi01wj3XNt3+koFKA5Afbh6EN6nQ==", "0bc3a698-0533-4b69-99ed-6ffa785c25a7", null, null, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Goals_ServiceID",
                table: "Goals",
                column: "ServiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_Services_ServiceID",
                table: "Goals",
                column: "ServiceID",
                principalTable: "Services",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceGoal_Goals_GoalID",
                table: "ServiceGoal",
                column: "GoalID",
                principalTable: "Goals",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceGoal_Services_ServiceID",
                table: "ServiceGoal",
                column: "ServiceID",
                principalTable: "Services",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceResult_Results_ResultID",
                table: "ServiceResult",
                column: "ResultID",
                principalTable: "Results",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceResult_Services_ServiceID",
                table: "ServiceResult",
                column: "ServiceID",
                principalTable: "Services",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
