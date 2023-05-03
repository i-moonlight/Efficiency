using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_end.Migrations
{
    public partial class AdresspropertiesinStoreupdatedcreatedinitialdatafactory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AddressLine2",
                table: "Stores",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "AddressLine1",
                table: "Stores",
                newName: "Observations");

            migrationBuilder.AddColumn<string>(
                name: "Complement",
                table: "Stores",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "Stores",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Role", "SecurityStamp", "SubscriptionBegin" },
                values: new object[] { "44b249d7-f0f2-4be2-bf1a-9c464999121c", "AQAAAAEAACcQAAAAEFCMD0OoSk5I8P+gfl7iobUPKlySnBez3PYy3ANE4YJ7vXvYxLX8u0Uph1JmdAn9PQ==", "ADMIN", "0a6b671f-6138-42b4-88e6-07d7e526a71a", new DateTime(2023, 5, 3, 19, 3, 47, 269, DateTimeKind.Utc).AddTicks(9227) });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "ID", "City", "Complement", "Country", "District", "Name", "Observations", "State", "Street", "ZipCode" },
                values: new object[] { 1, "São Paulo", "Prédio público", "Brazil", "Mooca", "EFFICIENCY STORE", "This is where the observations should be inserted", "São Paulo", "Praça Maria Cândida Freitas de Oliveira, 18", "03168070" });

            migrationBuilder.InsertData(
                table: "Goals",
                columns: new[] { "ID", "Month", "StoreID", "Value", "Year" },
                values: new object[,]
                {
                    { 1, 9, 1, 8481317.0, 2022 },
                    { 2, 10, 1, 7079055.0, 2022 },
                    { 3, 11, 1, 4581755.0, 2022 },
                    { 4, 12, 1, 6721971.0, 2022 },
                    { 5, 1, 1, 8239781.0, 2023 },
                    { 6, 2, 1, 1687245.0, 2023 },
                    { 7, 3, 1, 6932877.0, 2023 },
                    { 8, 4, 1, 7093967.0, 2023 }
                });

            migrationBuilder.InsertData(
                table: "Sellers",
                columns: new[] { "ID", "Active", "Email", "FirstName", "LastName", "Phone", "RegistrationNumber", "StoreID" },
                values: new object[,]
                {
                    { 1, true, "tereza-lopes72@comdados.com", "Tereza Carla", "Isabelly Lopes", "81985172642", 5170971, 1 },
                    { 2, true, "claudia.sophia.dasneves@octagonbrasil.com.br", "Cláudia Sophia", "Luciana das Neves", "84992669321", 8377984, 1 },
                    { 3, true, "henry.guilherme.campos@integrasjc.com.br", "Henry Guilherme", "Isaac Campos", "42983716441", 2054591, 1 },
                    { 4, true, "danilo_dias@marithimaconstrutora.com.br", "Danilo Giovanni", "Dias", "45996347291", 2096378, 1 },
                    { 5, true, "jorge_mario_farias@yool.com.br", "Jorge Mário José", "Farias", "68983670574", 1328623, 1 }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ID", "Name", "StoreID" },
                values: new object[,]
                {
                    { 1, "Extended Guarantee", 1 },
                    { 2, "Techinical Insurance", 1 }
                });

            migrationBuilder.InsertData(
                table: "Results",
                columns: new[] { "ID", "Date", "SellerID", "Value" },
                values: new object[,]
                {
                    { 1, new DateOnly(2022, 12, 22), 3, 10574m },
                    { 2, new DateOnly(2023, 4, 4), 4, 12384m },
                    { 3, new DateOnly(2022, 7, 12), 2, 114443m },
                    { 4, new DateOnly(2023, 4, 8), 4, 1823m },
                    { 5, new DateOnly(2022, 10, 21), 4, 176370m },
                    { 6, new DateOnly(2022, 8, 31), 2, 147842m },
                    { 7, new DateOnly(2022, 8, 8), 3, 23805m },
                    { 8, new DateOnly(2023, 3, 2), 3, 156669m },
                    { 9, new DateOnly(2023, 1, 24), 1, 73181m },
                    { 10, new DateOnly(2023, 4, 9), 4, 124042m }
                });

            migrationBuilder.InsertData(
                table: "ServicesGoal",
                columns: new[] { "GoalID", "ServiceID", "Value" },
                values: new object[,]
                {
                    { 1, 1, 676597m },
                    { 1, 2, 445315m },
                    { 2, 1, 912491m },
                    { 2, 2, 912491m },
                    { 3, 1, 549813m },
                    { 3, 2, 894390m },
                    { 4, 1, 472433m },
                    { 4, 2, 983652m },
                    { 5, 1, 237428m },
                    { 5, 2, 235060m },
                    { 6, 1, 131204m },
                    { 6, 2, 938524m },
                    { 7, 1, 877191m },
                    { 7, 2, 557740m },
                    { 8, 1, 500145m },
                    { 8, 2, 360438m }
                });

            migrationBuilder.InsertData(
                table: "ServicesResult",
                columns: new[] { "ResultID", "ServiceID", "Value" },
                values: new object[,]
                {
                    { 1, 1, 67784m },
                    { 1, 2, 173210m },
                    { 2, 1, 62121m },
                    { 2, 2, 12506m },
                    { 3, 1, 106495m },
                    { 3, 2, 12170m },
                    { 4, 1, 113523m },
                    { 4, 2, 173869m },
                    { 5, 1, 181087m },
                    { 5, 2, 106883m },
                    { 6, 1, 103405m },
                    { 6, 2, 197037m },
                    { 7, 1, 139618m },
                    { 7, 2, 36531m },
                    { 8, 1, 1906m },
                    { 8, 2, 1058m },
                    { 9, 1, 1215m },
                    { 9, 2, 1888m },
                    { 10, 1, 110m },
                    { 10, 2, 1312m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sellers",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ServicesGoal",
                keyColumns: new[] { "GoalID", "ServiceID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ServicesGoal",
                keyColumns: new[] { "GoalID", "ServiceID" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "ServicesGoal",
                keyColumns: new[] { "GoalID", "ServiceID" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "ServicesGoal",
                keyColumns: new[] { "GoalID", "ServiceID" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "ServicesGoal",
                keyColumns: new[] { "GoalID", "ServiceID" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "ServicesGoal",
                keyColumns: new[] { "GoalID", "ServiceID" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "ServicesGoal",
                keyColumns: new[] { "GoalID", "ServiceID" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "ServicesGoal",
                keyColumns: new[] { "GoalID", "ServiceID" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "ServicesGoal",
                keyColumns: new[] { "GoalID", "ServiceID" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "ServicesGoal",
                keyColumns: new[] { "GoalID", "ServiceID" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "ServicesGoal",
                keyColumns: new[] { "GoalID", "ServiceID" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "ServicesGoal",
                keyColumns: new[] { "GoalID", "ServiceID" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "ServicesGoal",
                keyColumns: new[] { "GoalID", "ServiceID" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "ServicesGoal",
                keyColumns: new[] { "GoalID", "ServiceID" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "ServicesGoal",
                keyColumns: new[] { "GoalID", "ServiceID" },
                keyValues: new object[] { 8, 1 });

            migrationBuilder.DeleteData(
                table: "ServicesGoal",
                keyColumns: new[] { "GoalID", "ServiceID" },
                keyValues: new object[] { 8, 2 });

            migrationBuilder.DeleteData(
                table: "ServicesResult",
                keyColumns: new[] { "ResultID", "ServiceID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ServicesResult",
                keyColumns: new[] { "ResultID", "ServiceID" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "ServicesResult",
                keyColumns: new[] { "ResultID", "ServiceID" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "ServicesResult",
                keyColumns: new[] { "ResultID", "ServiceID" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "ServicesResult",
                keyColumns: new[] { "ResultID", "ServiceID" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "ServicesResult",
                keyColumns: new[] { "ResultID", "ServiceID" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "ServicesResult",
                keyColumns: new[] { "ResultID", "ServiceID" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "ServicesResult",
                keyColumns: new[] { "ResultID", "ServiceID" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "ServicesResult",
                keyColumns: new[] { "ResultID", "ServiceID" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "ServicesResult",
                keyColumns: new[] { "ResultID", "ServiceID" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "ServicesResult",
                keyColumns: new[] { "ResultID", "ServiceID" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "ServicesResult",
                keyColumns: new[] { "ResultID", "ServiceID" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "ServicesResult",
                keyColumns: new[] { "ResultID", "ServiceID" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "ServicesResult",
                keyColumns: new[] { "ResultID", "ServiceID" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "ServicesResult",
                keyColumns: new[] { "ResultID", "ServiceID" },
                keyValues: new object[] { 8, 1 });

            migrationBuilder.DeleteData(
                table: "ServicesResult",
                keyColumns: new[] { "ResultID", "ServiceID" },
                keyValues: new object[] { 8, 2 });

            migrationBuilder.DeleteData(
                table: "ServicesResult",
                keyColumns: new[] { "ResultID", "ServiceID" },
                keyValues: new object[] { 9, 1 });

            migrationBuilder.DeleteData(
                table: "ServicesResult",
                keyColumns: new[] { "ResultID", "ServiceID" },
                keyValues: new object[] { 9, 2 });

            migrationBuilder.DeleteData(
                table: "ServicesResult",
                keyColumns: new[] { "ResultID", "ServiceID" },
                keyValues: new object[] { 10, 1 });

            migrationBuilder.DeleteData(
                table: "ServicesResult",
                keyColumns: new[] { "ResultID", "ServiceID" },
                keyValues: new object[] { 10, 2 });

            migrationBuilder.DeleteData(
                table: "Goals",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Goals",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Goals",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Goals",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Goals",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Goals",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Goals",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Goals",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Results",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Results",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Results",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Results",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Results",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Results",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Results",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Results",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Results",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Results",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sellers",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sellers",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sellers",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sellers",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Complement",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "District",
                table: "Stores");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Stores",
                newName: "AddressLine2");

            migrationBuilder.RenameColumn(
                name: "Observations",
                table: "Stores",
                newName: "AddressLine1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Role", "SecurityStamp", "SubscriptionBegin" },
                values: new object[] { "b175f637-5359-4ecb-83cc-b23e4151f0c9", "AQAAAAEAACcQAAAAECnPSiFI9U81B93qYQview9OeU/2XI+hzrx1bRNNaa7kLR+htFk5bGe555jm5fgasg==", null, "5602554d-32c8-469e-9244-497cbd76bb45", new DateTime(2023, 4, 30, 21, 18, 11, 697, DateTimeKind.Utc).AddTicks(8671) });
        }
    }
}
