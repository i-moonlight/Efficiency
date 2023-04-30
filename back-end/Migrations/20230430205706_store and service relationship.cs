using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_end.Migrations
{
    public partial class storeandservicerelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StoreID",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "SubscriptionBegin" },
                values: new object[] { "850f6be4-0292-4eb9-abcd-19148a11245a", "AQAAAAEAACcQAAAAEE3fDC0AS+YZHZ7s9CoUmNPJkgzhjkVSskiFjW3WA9WfkAiY9+jCi4YsvDaUzLM5Uw==", "805c9046-6d50-4458-b2ff-8390273df674", new DateTime(2023, 4, 30, 20, 57, 5, 876, DateTimeKind.Utc).AddTicks(6295) });

            migrationBuilder.CreateIndex(
                name: "IX_Services_StoreID",
                table: "Services",
                column: "StoreID");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Stores_StoreID",
                table: "Services",
                column: "StoreID",
                principalTable: "Stores",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Stores_StoreID",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_StoreID",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "StoreID",
                table: "Services");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "SubscriptionBegin" },
                values: new object[] { "35a07c63-4161-4def-b37e-e3537449b798", "AQAAAAEAACcQAAAAEDcQGA7Fr3QLOGGFZDC1NSi6xfE5BhkgO0TlNelH2XYwhaJhJZnpoYTJAeSwa4VCpQ==", "d8448418-b4fc-4407-a1d3-e80696e62d89", new DateTime(2023, 3, 27, 19, 13, 20, 190, DateTimeKind.Utc).AddTicks(7728) });
        }
    }
}
