using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LedgerEntries_Balances_BalanceId",
                table: "LedgerEntries");

            migrationBuilder.DropColumn(
                name: "BalanceRemaining",
                table: "LedgerEntries");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "Balances");

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "LedgerEntries",
                type: "integer",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)");

            migrationBuilder.AddColumn<Guid>(
                name: "GameId",
                table: "LedgerEntries",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "Balances",
                type: "integer",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "character varying(254)",
                maxLength: 254,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GameName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

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
                column: "Amount",
                value: 1000);

            migrationBuilder.UpdateData(
                table: "Balances",
                keyColumn: "Id",
                keyValue: new Guid("817b5a71-cdde-4899-bf32-f685ca0adda2"),
                column: "Amount",
                value: 500);

            migrationBuilder.UpdateData(
                table: "Balances",
                keyColumn: "Id",
                keyValue: new Guid("af3fbcb8-b29e-4233-8c34-9ae529f5943a"),
                column: "Amount",
                value: 500);

            migrationBuilder.UpdateData(
                table: "Balances",
                keyColumn: "Id",
                keyValue: new Guid("f0edd732-876b-4879-bf97-8a9793107eb6"),
                column: "Amount",
                value: 500);

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "GameName" },
                values: new object[,]
                {
                    { new Guid("457158ec-b964-4287-b441-75599a9013bc"), "Game 2" },
                    { new Guid("94078db3-2fd2-4de9-9f16-2b34036c99b9"), "Game 1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LedgerEntries_GameId",
                table: "LedgerEntries",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_LedgerEntries_Balances_BalanceId",
                table: "LedgerEntries",
                column: "BalanceId",
                principalTable: "Balances",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LedgerEntries_Games_GameId",
                table: "LedgerEntries",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LedgerEntries_Balances_BalanceId",
                table: "LedgerEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_LedgerEntries_Games_GameId",
                table: "LedgerEntries");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropIndex(
                name: "IX_LedgerEntries_GameId",
                table: "LedgerEntries");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "LedgerEntries");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "LedgerEntries",
                type: "numeric(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<decimal>(
                name: "BalanceRemaining",
                table: "LedgerEntries",
                type: "numeric(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Balances",
                type: "numeric(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "Balances",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(254)",
                oldMaxLength: 254);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1365fcba-5ebf-45b9-b67c-11dc33b91b12"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5b32952d-2d0d-4a88-8f4e-ac2ad5eb9290", "AQAAAAIAAYagAAAAEFBtO+AA2WHG/U1LedWntiyC4D9MS9Q3Pt9oDbpbuGMw+nLiFHQEAN73IRyO93Gzqg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("31284e51-c5d0-4a66-9497-92d2f0ded4bf"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9d686793-283c-46b9-a833-05882e8b345c", "AQAAAAIAAYagAAAAEH5yhO9mp0dq3I8pwxrp6L4XuEAsPdQT7gw7CrNsGTLty5m+jJLmMBkcbmxc3NH0JA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c79eea5e-34fc-480b-a4df-7bd440d6c684"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "aff51b50-3f9b-4051-8865-e3520b16be0e", "AQAAAAIAAYagAAAAEB+H/nMgPKDXbyog3cTv650o7fx4aJsuguShScE5tpqjXDy42DG84xevOz/eBAqoXQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ec4a0ad9-5aa4-4f70-9ab6-f37246664eff"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5239416f-6d3e-4e2c-9bc6-5d2241af0bf8", "AQAAAAIAAYagAAAAEJ97rWfyHhrUkt2U5BlvG6Fn7+kAVfAQrYgXwcdLN9s9SDd4bKUnWI1GRx6E1x8d8w==" });

            migrationBuilder.UpdateData(
                table: "Balances",
                keyColumn: "Id",
                keyValue: new Guid("25238630-5128-4e60-bb20-d74294d27e0f"),
                columns: new[] { "Amount", "LastUpdated" },
                values: new object[] { 1000.00m, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Balances",
                keyColumn: "Id",
                keyValue: new Guid("817b5a71-cdde-4899-bf32-f685ca0adda2"),
                columns: new[] { "Amount", "LastUpdated" },
                values: new object[] { 500.00m, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Balances",
                keyColumn: "Id",
                keyValue: new Guid("af3fbcb8-b29e-4233-8c34-9ae529f5943a"),
                columns: new[] { "Amount", "LastUpdated" },
                values: new object[] { 500.00m, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Balances",
                keyColumn: "Id",
                keyValue: new Guid("f0edd732-876b-4879-bf97-8a9793107eb6"),
                columns: new[] { "Amount", "LastUpdated" },
                values: new object[] { 500.00m, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.AddForeignKey(
                name: "FK_LedgerEntries_Balances_BalanceId",
                table: "LedgerEntries",
                column: "BalanceId",
                principalTable: "Balances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
