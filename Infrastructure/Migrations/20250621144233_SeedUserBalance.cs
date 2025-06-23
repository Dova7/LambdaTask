using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedUserBalance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1365fcba-5ebf-45b9-b67c-11dc33b91b12"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "35de993d-af6c-46f1-9337-ba0ff0f6f709", "AQAAAAIAAYagAAAAEMwuFfSBc6Vb65ITqrIzY/LRqwVg1KDLpf+/mdnzFzqg9Wg4vCmKjZc0SCSGEIUtBg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("31284e51-c5d0-4a66-9497-92d2f0ded4bf"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "86937606-031b-439d-9a7f-c8a5e0d5bf4d", "AQAAAAIAAYagAAAAEKHqLefDPhzHsMQg+dOhOy2UJu8TT1p2umpE5qu7bw/gmXK50/m9+BOcYDrYMe+JOQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c79eea5e-34fc-480b-a4df-7bd440d6c684"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1cc00873-179e-4aaf-9b58-bc1842e62d44", "AQAAAAIAAYagAAAAEL01+5nDaEuTpl0joeJZRF7HMlnywxR9L4glsL/55279hx1Yer5Ck08kskFFhI/DJg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ec4a0ad9-5aa4-4f70-9ab6-f37246664eff"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "56ccba08-5234-45c7-a4c8-63068da293dc", "AQAAAAIAAYagAAAAECMbFcLp3A3/UAe/PWm1si6T0tSpo0/y9vvdSktgtw67Tja97hYgz8aesLdtjwFtNw==" });

            migrationBuilder.InsertData(
                table: "Balances",
                columns: new[] { "Id", "Amount", "Currency", "UserId" },
                values: new object[,]
                {
                    { new Guid("2eb6f3b2-3064-4583-97db-c0d1758aff08"), 500, "USD", new Guid("31284e51-c5d0-4a66-9497-92d2f0ded4bf") },
                    { new Guid("60cf14c1-ea82-4d9f-bc46-ee5eb7ccb2ef"), 1000, "USD", new Guid("c79eea5e-34fc-480b-a4df-7bd440d6c684") },
                    { new Guid("74311927-5419-4ae4-b108-e8aa66b5048c"), 500, "USD", new Guid("ec4a0ad9-5aa4-4f70-9ab6-f37246664eff") },
                    { new Guid("c3042a39-b938-46b8-a61e-ed0554a7950f"), 1000, "EUR", new Guid("c79eea5e-34fc-480b-a4df-7bd440d6c684") },
                    { new Guid("d828da65-f3ca-4ebd-a5a1-ca0a1f92c171"), 500, "USD", new Guid("1365fcba-5ebf-45b9-b67c-11dc33b91b12") },
                    { new Guid("f0a99876-a81e-481b-8d41-c614907c7c89"), 500, "EUR", new Guid("ec4a0ad9-5aa4-4f70-9ab6-f37246664eff") },
                    { new Guid("f2d497cb-ed02-4f32-ad0a-37d4a18e0655"), 500, "EUR", new Guid("31284e51-c5d0-4a66-9497-92d2f0ded4bf") },
                    { new Guid("f6f338e8-3e16-4a5f-9d8b-41694c434fae"), 500, "EUR", new Guid("1365fcba-5ebf-45b9-b67c-11dc33b91b12") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Balances",
                keyColumn: "Id",
                keyValue: new Guid("2eb6f3b2-3064-4583-97db-c0d1758aff08"));

            migrationBuilder.DeleteData(
                table: "Balances",
                keyColumn: "Id",
                keyValue: new Guid("60cf14c1-ea82-4d9f-bc46-ee5eb7ccb2ef"));

            migrationBuilder.DeleteData(
                table: "Balances",
                keyColumn: "Id",
                keyValue: new Guid("74311927-5419-4ae4-b108-e8aa66b5048c"));

            migrationBuilder.DeleteData(
                table: "Balances",
                keyColumn: "Id",
                keyValue: new Guid("c3042a39-b938-46b8-a61e-ed0554a7950f"));

            migrationBuilder.DeleteData(
                table: "Balances",
                keyColumn: "Id",
                keyValue: new Guid("d828da65-f3ca-4ebd-a5a1-ca0a1f92c171"));

            migrationBuilder.DeleteData(
                table: "Balances",
                keyColumn: "Id",
                keyValue: new Guid("f0a99876-a81e-481b-8d41-c614907c7c89"));

            migrationBuilder.DeleteData(
                table: "Balances",
                keyColumn: "Id",
                keyValue: new Guid("f2d497cb-ed02-4f32-ad0a-37d4a18e0655"));

            migrationBuilder.DeleteData(
                table: "Balances",
                keyColumn: "Id",
                keyValue: new Guid("f6f338e8-3e16-4a5f-9d8b-41694c434fae"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1365fcba-5ebf-45b9-b67c-11dc33b91b12"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "88646f82-f329-428d-b786-d333af93e5c1", "AQAAAAIAAYagAAAAEPQjPaWeIpkPWzH+y4ogZgw7ly8Rw/lM4Qr89x5fcBoFId1Fz8pn65CqDf8+egY2oA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("31284e51-c5d0-4a66-9497-92d2f0ded4bf"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9c690d29-4a87-4376-8f96-254aa7845fb9", "AQAAAAIAAYagAAAAEBn9wM5PtVax8315/oBBEF6oTH6PPpB7rYwi6vvtub2CL8tviqbPmV51M6t1C+CiPA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c79eea5e-34fc-480b-a4df-7bd440d6c684"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e30b1aa7-20d8-4838-bf2c-dfbbc0787031", "AQAAAAIAAYagAAAAEOQylWXyUaZcGq9ycnGST7j6SDcmJIDJj0FxndW4DXjiBMHTTIuLeeB3jtVxMGr+nQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ec4a0ad9-5aa4-4f70-9ab6-f37246664eff"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "04d5eb64-c289-4c1b-a8e8-1d5dea0be772", "AQAAAAIAAYagAAAAEOXyIgJITHNUqlcAfCOcriwgqSvGIjWQf157fdmKbtjabvc8TyFApDQ2dUlIjDSfwA==" });
        }
    }
}
