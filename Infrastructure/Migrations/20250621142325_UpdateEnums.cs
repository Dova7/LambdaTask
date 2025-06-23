using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEnums : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TransactionDescription",
                table: "LedgerEntries",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Currency",
                table: "Balances",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

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

            migrationBuilder.UpdateData(
                table: "Balances",
                keyColumn: "Id",
                keyValue: new Guid("25238630-5128-4e60-bb20-d74294d27e0f"),
                column: "Currency",
                value: "GEL");

            migrationBuilder.UpdateData(
                table: "Balances",
                keyColumn: "Id",
                keyValue: new Guid("817b5a71-cdde-4899-bf32-f685ca0adda2"),
                column: "Currency",
                value: "GEL");

            migrationBuilder.UpdateData(
                table: "Balances",
                keyColumn: "Id",
                keyValue: new Guid("af3fbcb8-b29e-4233-8c34-9ae529f5943a"),
                column: "Currency",
                value: "GEL");

            migrationBuilder.UpdateData(
                table: "Balances",
                keyColumn: "Id",
                keyValue: new Guid("f0edd732-876b-4879-bf97-8a9793107eb6"),
                column: "Currency",
                value: "GEL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TransactionDescription",
                table: "LedgerEntries",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "Currency",
                table: "Balances",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1365fcba-5ebf-45b9-b67c-11dc33b91b12"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ea54aa7c-d347-4c53-9e9e-92ea9537b399", "AQAAAAIAAYagAAAAEC1/XJteAGjtT42I5EgLk8mNvBOHxytHg/yQzeTZfn5rUsPRI8Y+18aqnzEfQ2e4AA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("31284e51-c5d0-4a66-9497-92d2f0ded4bf"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6a3af97b-7f0b-45e8-81a1-76f44254fde2", "AQAAAAIAAYagAAAAEGEh3jAOCi0giONFwqqKDrONkHYF3Ea8D3PIyRD8H5qWyDmANv9D7udNj6V3Dim9LQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c79eea5e-34fc-480b-a4df-7bd440d6c684"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4229f8a4-86e7-42d9-b588-91f47795f322", "AQAAAAIAAYagAAAAELQH7+6VkAN1a2EmYyMAQXAoX0gsStnT0Zu9ignOPOaxExDqNJnYLfh2b2iqG6izkw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ec4a0ad9-5aa4-4f70-9ab6-f37246664eff"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0f939802-5a6a-4d57-91b7-b9a5224fd09d", "AQAAAAIAAYagAAAAEI0sn1hguq5sQDbdQMGKJiEvxHCtztdyrL854UKeHX83IQ6h3gP3w8TF/oRHfnG1lQ==" });

            migrationBuilder.UpdateData(
                table: "Balances",
                keyColumn: "Id",
                keyValue: new Guid("25238630-5128-4e60-bb20-d74294d27e0f"),
                column: "Currency",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Balances",
                keyColumn: "Id",
                keyValue: new Guid("817b5a71-cdde-4899-bf32-f685ca0adda2"),
                column: "Currency",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Balances",
                keyColumn: "Id",
                keyValue: new Guid("af3fbcb8-b29e-4233-8c34-9ae529f5943a"),
                column: "Currency",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Balances",
                keyColumn: "Id",
                keyValue: new Guid("f0edd732-876b-4879-bf97-8a9793107eb6"),
                column: "Currency",
                value: 1);
        }
    }
}
