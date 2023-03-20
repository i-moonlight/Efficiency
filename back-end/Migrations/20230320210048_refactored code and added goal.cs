using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_end.Migrations
{
    public partial class refactoredcodeandaddedgoal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Companies_CompanyID",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "EmployeeFinancialResult");

            migrationBuilder.DropTable(
                name: "EmployeesFinancialResults");

            migrationBuilder.DropTable(
                name: "FinancialResultFinancialService");

            migrationBuilder.DropTable(
                name: "FinancialResultsFinancialServices");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "FinancialResults");

            migrationBuilder.DropTable(
                name: "FinancialServices");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.RenameColumn(
                name: "CompanyID",
                table: "AspNetUsers",
                newName: "StoreID");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_CompanyID",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_StoreID");

            migrationBuilder.AddColumn<bool>(
                name: "PaymentOnDay",
                table: "AspNetUsers",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "AspNetUsers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    State = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Country = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressLine1 = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressLine2 = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ZipCode = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Goals",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<double>(type: "double", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    StoreID = table.Column<int>(type: "int", nullable: true),
                    ServiceID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goals", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Goals_Services_ServiceID",
                        column: x => x.ServiceID,
                        principalTable: "Services",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Goals_Stores_StoreID",
                        column: x => x.StoreID,
                        principalTable: "Stores",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RegistrationNumber = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StoreID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Sellers_Stores_StoreID",
                        column: x => x.StoreID,
                        principalTable: "Stores",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    SellerID = table.Column<int>(type: "int", nullable: false),
                    ServiceID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Results_Sellers_SellerID",
                        column: x => x.SellerID,
                        principalTable: "Sellers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Results_Services_ServiceID",
                        column: x => x.ServiceID,
                        principalTable: "Services",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PaymentOnDay", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "StoreID", "TwoFactorEnabled", "UserName" },
                values: new object[] { 9999, 0, "5e620a79-eb85-4f63-af60-b4b02e3fc2d6", "User", "admin@admin.com", true, null, null, false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAELL7kMWzxxJ5ijWKoJhJ/500Wv7IZeEK0uafAHtvscMztGDNZ1jfJQh+SI+gECiQag==", null, null, null, false, null, "493d7fbe-fafa-4875-88a0-1533d4f192db", null, false, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Goals_ServiceID",
                table: "Goals",
                column: "ServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_Goals_StoreID",
                table: "Goals",
                column: "StoreID");

            migrationBuilder.CreateIndex(
                name: "IX_Results_SellerID",
                table: "Results",
                column: "SellerID");

            migrationBuilder.CreateIndex(
                name: "IX_Results_ServiceID",
                table: "Results",
                column: "ServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_Sellers_StoreID",
                table: "Sellers",
                column: "StoreID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Stores_StoreID",
                table: "AspNetUsers",
                column: "StoreID",
                principalTable: "Stores",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Stores_StoreID",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Goals");

            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "Sellers");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9999);

            migrationBuilder.DropColumn(
                name: "PaymentOnDay",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "StoreID",
                table: "AspNetUsers",
                newName: "CompanyID");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_StoreID",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_CompanyID");

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FinancialResults",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    SalesResult = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialResults", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FinancialServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialServices", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    RegistrationNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CompanyID = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.RegistrationNumber);
                    table.ForeignKey(
                        name: "FK_Employees_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FinancialResultFinancialService",
                columns: table => new
                {
                    FinancialResultsID = table.Column<int>(type: "int", nullable: false),
                    FinancialServicesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialResultFinancialService", x => new { x.FinancialResultsID, x.FinancialServicesId });
                    table.ForeignKey(
                        name: "FK_FinancialResultFinancialService_FinancialResults_FinancialRe~",
                        column: x => x.FinancialResultsID,
                        principalTable: "FinancialResults",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FinancialResultFinancialService_FinancialServices_FinancialS~",
                        column: x => x.FinancialServicesId,
                        principalTable: "FinancialServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FinancialResultsFinancialServices",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FinancialResultID = table.Column<int>(type: "int", nullable: false),
                    FinancialServiceID = table.Column<int>(type: "int", nullable: false),
                    Result = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialResultsFinancialServices", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FinancialResultsFinancialServices_FinancialResults_Financial~",
                        column: x => x.FinancialResultID,
                        principalTable: "FinancialResults",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FinancialResultsFinancialServices_FinancialServices_Financia~",
                        column: x => x.FinancialServiceID,
                        principalTable: "FinancialServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EmployeeFinancialResult",
                columns: table => new
                {
                    EmployeesRegistrationNumber = table.Column<int>(type: "int", nullable: false),
                    FinancialResultsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeFinancialResult", x => new { x.EmployeesRegistrationNumber, x.FinancialResultsID });
                    table.ForeignKey(
                        name: "FK_EmployeeFinancialResult_Employees_EmployeesRegistrationNumber",
                        column: x => x.EmployeesRegistrationNumber,
                        principalTable: "Employees",
                        principalColumn: "RegistrationNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeFinancialResult_FinancialResults_FinancialResultsID",
                        column: x => x.FinancialResultsID,
                        principalTable: "FinancialResults",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EmployeesFinancialResults",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    FinancialResultID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesFinancialResults", x => x.ID);
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
                name: "IX_EmployeeFinancialResult_FinancialResultsID",
                table: "EmployeeFinancialResult",
                column: "FinancialResultsID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompanyID",
                table: "Employees",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesFinancialResults_EmployeeID",
                table: "EmployeesFinancialResults",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesFinancialResults_FinancialResultID",
                table: "EmployeesFinancialResults",
                column: "FinancialResultID");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialResultFinancialService_FinancialServicesId",
                table: "FinancialResultFinancialService",
                column: "FinancialServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialResultsFinancialServices_FinancialResultID",
                table: "FinancialResultsFinancialServices",
                column: "FinancialResultID");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialResultsFinancialServices_FinancialServiceID",
                table: "FinancialResultsFinancialServices",
                column: "FinancialServiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Companies_CompanyID",
                table: "AspNetUsers",
                column: "CompanyID",
                principalTable: "Companies",
                principalColumn: "ID");
        }
    }
}
