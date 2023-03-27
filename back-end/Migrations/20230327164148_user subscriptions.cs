using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_end.Migrations
{
    public partial class usersubscriptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentOnDay",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<DateTime>(
                name: "SubscriptionBegin",
                table: "AspNetUsers",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SubscriptionExpiration",
                table: "AspNetUsers",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubscriptionType",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "51d49b8a-44b5-4a17-bce7-09aae7470565", "AQAAAAEAACcQAAAAEMMRvuoVdUZvnDdRWTuf+gmiX3uiYsH1AtTt4QQi01wj3XNt3+koFKA5Afbh6EN6nQ==", "0bc3a698-0533-4b69-99ed-6ffa785c25a7" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubscriptionBegin",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SubscriptionExpiration",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SubscriptionType",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<bool>(
                name: "PaymentOnDay",
                table: "AspNetUsers",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "576192a1-8f05-4d02-95f0-7723015f527e", "AQAAAAEAACcQAAAAEMKmAhC46LL8dpBuCiTaRUmg/zYiiBRPfmQIUp6DVsxWn7LyryohxlBEaLyPZKfAiA==", "0c006121-ca88-43f2-b67e-9d5ba95b862b" });
        }
    }
}
