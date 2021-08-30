using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BEZAO_PayDAL.Migrations
{
    public partial class CreateDbAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Password", "Salt" },
                values: new object[] { new DateTime(2021, 8, 28, 17, 18, 40, 63, DateTimeKind.Local).AddTicks(9810), "auXCg6p2Zf7mO7vG6VwDgWFb3o0u0xnwF9QRFWr9", "29-2f-30-e1-cd-7a-88-83-9d-9c-cf-96-ba-59-97-c2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Password", "Salt" },
                values: new object[] { new DateTime(2021, 8, 28, 17, 18, 40, 80, DateTimeKind.Local).AddTicks(8672), "ivh8m/sY5gwyGjU6+Qv4qxgqLi4uepNyVVZki2B4", "28-fe-52-0b-7e-56-90-a0-80-87-fd-d1-08-bd-13-c6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Password", "Salt" },
                values: new object[] { new DateTime(2021, 8, 28, 17, 18, 40, 91, DateTimeKind.Local).AddTicks(6011), "MteaRuL3p20QI4j0qZZTypIePnCfmm177WzEAk9q", "e0-74-3f-61-d2-e3-20-ae-dc-34-57-95-9d-7d-2e-06" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Password", "Salt" },
                values: new object[] { new DateTime(2021, 8, 28, 17, 18, 40, 102, DateTimeKind.Local).AddTicks(1655), "EilEGGvFKLo32Qe3+Txq23DGjWMnrzCASyZmg3gN", "6c-4e-ae-0c-af-5d-b1-e5-c9-11-38-26-3a-d0-58-a4" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "Password", "Salt" },
                values: new object[] { new DateTime(2021, 8, 28, 17, 18, 40, 112, DateTimeKind.Local).AddTicks(7371), "9uwTNdDtbHGkHs3gVN5mS8SWfk6M0TVFy/3cRmnn", "56-7c-8b-e3-54-a8-69-4a-8b-76-54-a3-60-cd-17-8b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Password", "Salt" },
                values: new object[] { new DateTime(2021, 8, 28, 13, 2, 10, 817, DateTimeKind.Local).AddTicks(3056), "EHExEnk2/IeRznXvYwczgjNVEnK+9a6cHwn4srEg", "31-d2-89-94-04-ec-50-b5-b6-3e-85-57-46-d5-0e-d4" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Password", "Salt" },
                values: new object[] { new DateTime(2021, 8, 28, 13, 2, 10, 850, DateTimeKind.Local).AddTicks(945), "Mu0qwsdQiVHMmf2Q+bgfpHDN7LaJJWx9Li5j/MYZ", "c0-a6-b8-32-09-3b-36-87-30-8c-db-73-24-8e-d5-a0" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Password", "Salt" },
                values: new object[] { new DateTime(2021, 8, 28, 13, 2, 10, 869, DateTimeKind.Local).AddTicks(5922), "SPXFL8vB9Yq+6IJ6xkQQEcvLyqd7VN1Y3oPkePz3", "a1-d6-27-bc-20-2e-77-b0-6a-e0-92-1f-7d-5e-72-1a" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Password", "Salt" },
                values: new object[] { new DateTime(2021, 8, 28, 13, 2, 10, 892, DateTimeKind.Local).AddTicks(2621), "kFtGywq+kw2cppcVaNLucER4FHsuhaQDKepy4y5t", "8a-20-ba-56-99-1d-a7-0f-9f-b2-06-31-44-fb-8a-12" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "Password", "Salt" },
                values: new object[] { new DateTime(2021, 8, 28, 13, 2, 10, 908, DateTimeKind.Local).AddTicks(6282), "46KmE/G8cypjnEA59P3bmX5aAy6xvw+H9a/7NLdw", "c7-c8-9d-af-01-50-fa-b0-f2-e8-83-3e-ee-9f-e5-ba" });
        }
    }
}
