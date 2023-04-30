using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_end.Migrations
{
    public partial class storeandservicerelationshiponcontext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "SubscriptionBegin" },
                values: new object[] { "b175f637-5359-4ecb-83cc-b23e4151f0c9", "AQAAAAEAACcQAAAAECnPSiFI9U81B93qYQview9OeU/2XI+hzrx1bRNNaa7kLR+htFk5bGe555jm5fgasg==", "5602554d-32c8-469e-9244-497cbd76bb45", new DateTime(2023, 4, 30, 21, 18, 11, 697, DateTimeKind.Utc).AddTicks(8671) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "SubscriptionBegin" },
                values: new object[] { "850f6be4-0292-4eb9-abcd-19148a11245a", "AQAAAAEAACcQAAAAEE3fDC0AS+YZHZ7s9CoUmNPJkgzhjkVSskiFjW3WA9WfkAiY9+jCi4YsvDaUzLM5Uw==", "805c9046-6d50-4458-b2ff-8390273df674", new DateTime(2023, 4, 30, 20, 57, 5, 876, DateTimeKind.Utc).AddTicks(6295) });
        }
    }
}
