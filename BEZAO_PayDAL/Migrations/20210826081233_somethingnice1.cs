using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BEZAO_PayDAL.Migrations
{
    public partial class somethingnice1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountId", "Birthday", "Created", "Email", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1990, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 26, 9, 12, 32, 935, DateTimeKind.Local).AddTicks(139), "sorry.sir@abeg.com", true, "Francis Sorry" },
                    { 2, 2, new DateTime(1420, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 26, 9, 12, 32, 936, DateTimeKind.Local).AddTicks(9198), "badguy@BBA.com", true, "GrandMaster KC" },
                    { 3, 3, new DateTime(1420, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 26, 9, 12, 32, 936, DateTimeKind.Local).AddTicks(9278), "dara.sage@ned.com", true, "Dara John" },
                    { 4, 4, new DateTime(1420, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 26, 9, 12, 32, 936, DateTimeKind.Local).AddTicks(9284), "sadboy@BBA.com", true, "Kachi !Thename" },
                    { 5, 5, new DateTime(1420, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 26, 9, 12, 32, 936, DateTimeKind.Local).AddTicks(9288), "omo@BBA.com", true, "Sammy ROCBAFDEZ" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
