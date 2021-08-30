using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BEZAO_PayDAL.Migrations
{
    public partial class CreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNumber = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(38,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Username = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TransactionMode = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(38,2)", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountNumber", "Balance" },
                values: new object[,]
                {
                    { 1, 760015555, 23456782340m },
                    { 2, 222833403, 56000000000m },
                    { 3, 456723646, 78345678230m },
                    { 4, 1642347213, 63723456780m },
                    { 5, 753485382, 88978234000m }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountId", "Birthday", "Created", "Email", "IsActive", "Name", "Password", "Salt", "Username" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1990, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 28, 13, 2, 10, 817, DateTimeKind.Local).AddTicks(3056), "sorry.sir@abeg.com", true, "Francis Sorry", "EHExEnk2/IeRznXvYwczgjNVEnK+9a6cHwn4srEg", "31-d2-89-94-04-ec-50-b5-b6-3e-85-57-46-d5-0e-d4", "francissorry" },
                    { 2, 2, new DateTime(1420, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 28, 13, 2, 10, 850, DateTimeKind.Local).AddTicks(945), "badguy@BBA.com", true, "GrandMaster KC", "Mu0qwsdQiVHMmf2Q+bgfpHDN7LaJJWx9Li5j/MYZ", "c0-a6-b8-32-09-3b-36-87-30-8c-db-73-24-8e-d5-a0", "grandmasterkc" },
                    { 3, 3, new DateTime(1420, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 28, 13, 2, 10, 869, DateTimeKind.Local).AddTicks(5922), "dara.sage@ned.com", true, "Dara John", "SPXFL8vB9Yq+6IJ6xkQQEcvLyqd7VN1Y3oPkePz3", "a1-d6-27-bc-20-2e-77-b0-6a-e0-92-1f-7d-5e-72-1a", "darajohn" },
                    { 4, 4, new DateTime(1420, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 28, 13, 2, 10, 892, DateTimeKind.Local).AddTicks(2621), "sadboy@BBA.com", true, "Kachi !Thename", "kFtGywq+kw2cppcVaNLucER4FHsuhaQDKepy4y5t", "8a-20-ba-56-99-1d-a7-0f-9f-b2-06-31-44-fb-8a-12", "kachi!thename" },
                    { 5, 5, new DateTime(1420, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 28, 13, 2, 10, 908, DateTimeKind.Local).AddTicks(6282), "omo@BBA.com", true, "Sammy ROCBAFDEZ", "46KmE/G8cypjnEA59P3bmX5aAy6xvw+H9a/7NLdw", "c7-c8-9d-af-01-50-fa-b0-f2-e8-83-3e-ee-9f-e5-ba", "sammyrocbafdez" }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "Amount", "TimeStamp", "TransactionMode", "UserId" },
                values: new object[,]
                {
                    { 1, 50000000m, new DateTime(2021, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, 60000000m, new DateTime(2022, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 3, 70000000m, new DateTime(2023, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { 4, 80000000m, new DateTime(2024, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4 },
                    { 5, 90000000m, new DateTime(2025, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UserId",
                table: "Transactions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AccountId",
                table: "Users",
                column: "AccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
