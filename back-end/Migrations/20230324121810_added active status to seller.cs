using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_end.Migrations
{
    public partial class addedactivestatustoseller : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Sellers",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d2286a95-a54b-4db7-9cdc-6e998c29fcfb", "AQAAAAEAACcQAAAAEOad6x605rGjQv65fpUxa3VUCoCe/ygL4rVSn/+k6/AXf6vK4zNMqlX9lHYPLgo6DQ==", "e69569d4-fef0-4168-89ef-c1ee07d5202d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Sellers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5e620a79-eb85-4f63-af60-b4b02e3fc2d6", "AQAAAAEAACcQAAAAELL7kMWzxxJ5ijWKoJhJ/500Wv7IZeEK0uafAHtvscMztGDNZ1jfJQh+SI+gECiQag==", "493d7fbe-fafa-4875-88a0-1533d4f192db" });
        }
    }
}
