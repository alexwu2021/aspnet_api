using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace aspnetapp.Migrations
{
    /// <inheritdoc />
    public partial class patientdb_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "patient",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "patient",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "patient",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "patient",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "patient",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 4, 9, 3, 35, 807, DateTimeKind.Local).AddTicks(1280));

            migrationBuilder.AddColumn<DateTime>(
                name: "Dob",
                table: "patient",
                type: "datetime(6)",
                maxLength: 15,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "patient",
                type: "varchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "patient",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "patient",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ssn",
                table: "patient",
                type: "varchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "patient",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "patient",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Zip",
                table: "patient",
                type: "varchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.InsertData(
                table: "patient",
                columns: new[] { "Id", "Address", "City", "CreatedAt", "Dob", "Email", "FirstName", "LastName", "MiddleName", "Ssn", "State", "UpdatedAt", "Zip" },
                values: new object[,]
                {
                    { 1, "101 A Str", "Somewhere", new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1970, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "aaa@b.com", "David", "Mike", "A", "123456789", null, null, null },
                    { 2, "101 A Str", "Somewhere", new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1972, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "bbbb@b.com", "Steve", "Warner", "B", "123456788", null, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "patient",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "patient",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Address",
                table: "patient");

            migrationBuilder.DropColumn(
                name: "City",
                table: "patient");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "patient");

            migrationBuilder.DropColumn(
                name: "Dob",
                table: "patient");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "patient");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "patient");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "patient");

            migrationBuilder.DropColumn(
                name: "Ssn",
                table: "patient");

            migrationBuilder.DropColumn(
                name: "State",
                table: "patient");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "patient");

            migrationBuilder.DropColumn(
                name: "Zip",
                table: "patient");

            migrationBuilder.InsertData(
                table: "patient",
                columns: new[] { "Id", "LastName" },
                values: new object[,]
                {
                    { -2, "Warner" },
                    { -1, "Mike" }
                });
        }
    }
}
