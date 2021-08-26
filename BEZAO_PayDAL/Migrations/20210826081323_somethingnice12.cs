using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BEZAO_PayDAL.Migrations
{
    public partial class somethingnice12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 8, 26, 9, 13, 22, 250, DateTimeKind.Local).AddTicks(7056));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 8, 26, 9, 13, 22, 252, DateTimeKind.Local).AddTicks(8646));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 8, 26, 9, 13, 22, 252, DateTimeKind.Local).AddTicks(8733));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 8, 26, 9, 13, 22, 252, DateTimeKind.Local).AddTicks(8740));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2021, 8, 26, 9, 13, 22, 252, DateTimeKind.Local).AddTicks(8744));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 8, 26, 9, 12, 32, 935, DateTimeKind.Local).AddTicks(139));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 8, 26, 9, 12, 32, 936, DateTimeKind.Local).AddTicks(9198));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 8, 26, 9, 12, 32, 936, DateTimeKind.Local).AddTicks(9278));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 8, 26, 9, 12, 32, 936, DateTimeKind.Local).AddTicks(9284));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2021, 8, 26, 9, 12, 32, 936, DateTimeKind.Local).AddTicks(9288));
        }
    }
}
