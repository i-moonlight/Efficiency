using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_end.Migrations
{
    public partial class addedstoreID1toadmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StoreID", "SubscriptionBegin" },
                values: new object[] { "641c9919-6a9d-41e0-afd6-2f62b1d8772a", "AQAAAAEAACcQAAAAENkKRyWMj8YDnvtrartxu35KhRJMJ6fFzVJUCfgEolx+GX6U9iJAn0l4ZsYJ95Dpxg==", "518b6760-899d-4a96-ba20-c959afd811d4", 1, new DateTime(2023, 5, 3, 20, 17, 55, 410, DateTimeKind.Utc).AddTicks(2639) });

            migrationBuilder.UpdateData(
                table: "Results",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Date", "SellerID" },
                values: new object[] { new DateOnly(2022, 7, 30), 2 });

            migrationBuilder.UpdateData(
                table: "Results",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Date", "SellerID" },
                values: new object[] { new DateOnly(2023, 3, 17), 3 });

            migrationBuilder.UpdateData(
                table: "Results",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "Date", "SellerID" },
                values: new object[] { new DateOnly(2023, 1, 16), 1 });

            migrationBuilder.UpdateData(
                table: "Results",
                keyColumn: "ID",
                keyValue: 4,
                column: "Date",
                value: new DateOnly(2022, 7, 20));

            migrationBuilder.UpdateData(
                table: "Results",
                keyColumn: "ID",
                keyValue: 5,
                column: "Date",
                value: new DateOnly(2023, 2, 15));

            migrationBuilder.UpdateData(
                table: "Results",
                keyColumn: "ID",
                keyValue: 6,
                column: "Date",
                value: new DateOnly(2022, 10, 29));

            migrationBuilder.UpdateData(
                table: "Results",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "Date", "SellerID" },
                values: new object[] { new DateOnly(2022, 7, 9), 2 });

            migrationBuilder.UpdateData(
                table: "Results",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "Date", "SellerID" },
                values: new object[] { new DateOnly(2023, 3, 7), 2 });

            migrationBuilder.UpdateData(
                table: "Results",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "Date", "SellerID" },
                values: new object[] { new DateOnly(2022, 5, 6), 3 });

            migrationBuilder.UpdateData(
                table: "Results",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "Date", "SellerID" },
                values: new object[] { new DateOnly(2023, 3, 29), 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StoreID", "SubscriptionBegin" },
                values: new object[] { "44b249d7-f0f2-4be2-bf1a-9c464999121c", "AQAAAAEAACcQAAAAEFCMD0OoSk5I8P+gfl7iobUPKlySnBez3PYy3ANE4YJ7vXvYxLX8u0Uph1JmdAn9PQ==", "0a6b671f-6138-42b4-88e6-07d7e526a71a", null, new DateTime(2023, 5, 3, 19, 3, 47, 269, DateTimeKind.Utc).AddTicks(9227) });

            migrationBuilder.UpdateData(
                table: "Results",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Date", "SellerID" },
                values: new object[] { new DateOnly(2022, 12, 22), 3 });

            migrationBuilder.UpdateData(
                table: "Results",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Date", "SellerID" },
                values: new object[] { new DateOnly(2023, 4, 4), 4 });

            migrationBuilder.UpdateData(
                table: "Results",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "Date", "SellerID" },
                values: new object[] { new DateOnly(2022, 7, 12), 2 });

            migrationBuilder.UpdateData(
                table: "Results",
                keyColumn: "ID",
                keyValue: 4,
                column: "Date",
                value: new DateOnly(2023, 4, 8));

            migrationBuilder.UpdateData(
                table: "Results",
                keyColumn: "ID",
                keyValue: 5,
                column: "Date",
                value: new DateOnly(2022, 10, 21));

            migrationBuilder.UpdateData(
                table: "Results",
                keyColumn: "ID",
                keyValue: 6,
                column: "Date",
                value: new DateOnly(2022, 8, 31));

            migrationBuilder.UpdateData(
                table: "Results",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "Date", "SellerID" },
                values: new object[] { new DateOnly(2022, 8, 8), 3 });

            migrationBuilder.UpdateData(
                table: "Results",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "Date", "SellerID" },
                values: new object[] { new DateOnly(2023, 3, 2), 3 });

            migrationBuilder.UpdateData(
                table: "Results",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "Date", "SellerID" },
                values: new object[] { new DateOnly(2023, 1, 24), 1 });

            migrationBuilder.UpdateData(
                table: "Results",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "Date", "SellerID" },
                values: new object[] { new DateOnly(2023, 4, 9), 4 });
        }
    }
}
