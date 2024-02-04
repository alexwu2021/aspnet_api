using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace aspnetapp.Migrations
{
    /// <inheritdoc />
    public partial class createOtherTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "patient",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 4, 11, 49, 6, 562, DateTimeKind.Local).AddTicks(5970),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 2, 4, 9, 3, 35, 807, DateTimeKind.Local).AddTicks(1280));

            migrationBuilder.CreateTable(
                name: "patient_lab_result",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Patient_id = table.Column<int>(type: "int", nullable: false),
                    Lab_visit_id = table.Column<int>(type: "int", nullable: false),
                    Test_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Test_result = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Test_observation = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Attachments = table.Column<string>(type: "longtext", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2024, 2, 4, 11, 49, 6, 564, DateTimeKind.Local).AddTicks(2100)),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient_lab_result", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "patient_lab_visit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Patient_id = table.Column<int>(type: "int", nullable: false),
                    Lab_name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Lab_test_request = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Result_date = table.Column<string>(type: "longtext", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2024, 2, 4, 11, 49, 6, 563, DateTimeKind.Local).AddTicks(1080)),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient_lab_visit", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "patient_medicine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Patient_id = table.Column<int>(type: "int", nullable: false),
                    Visit_id = table.Column<int>(type: "int", nullable: false),
                    Medicine_name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Dosage = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Frequency = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Prescribed_by = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Prescription_date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Prescription_period = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2024, 2, 4, 11, 49, 6, 564, DateTimeKind.Local).AddTicks(9000)),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient_medicine", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "patient_vaccination_data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Patient_id = table.Column<int>(type: "int", nullable: false),
                    Vaccine_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Vaccine_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Vaccine_validity = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Administered_by = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2024, 2, 4, 11, 49, 6, 565, DateTimeKind.Local).AddTicks(4090)),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient_vaccination_data", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "patient_visit_history",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Patient_id = table.Column<int>(type: "int", nullable: false),
                    Visit_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Doctor_name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Nurse_name_1 = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Nurse_name_2 = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2024, 2, 4, 11, 49, 6, 563, DateTimeKind.Local).AddTicks(6350)),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient_visit_history", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "patient",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "State", "Zip" },
                values: new object[] { "CA", "94000" });

            migrationBuilder.UpdateData(
                table: "patient",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "State", "Zip" },
                values: new object[] { "CA", "94001" });

            migrationBuilder.InsertData(
                table: "patient_lab_result",
                columns: new[] { "Id", "Attachments", "CreatedAt", "Lab_visit_id", "Patient_id", "Test_name", "Test_observation", "Test_result", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "a certain attachment", new DateTime(2024, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "a certain test name", "a certain test observation", "a certain test result", null },
                    { 2, "yet antoher certain attachment", new DateTime(2024, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, "yet another certain test name", "yet another certain test observation", "yet another certain test result", null }
                });

            migrationBuilder.InsertData(
                table: "patient_lab_visit",
                columns: new[] { "Id", "CreatedAt", "Lab_name", "Lab_test_request", "Patient_id", "Result_date", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test Lab for Mike", "Need a test for Mike", 1, null, null },
                    { 2, new DateTime(2024, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test Lab for Steve", "Need a test for Steve", 2, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "patient_lab_result");

            migrationBuilder.DropTable(
                name: "patient_lab_visit");

            migrationBuilder.DropTable(
                name: "patient_medicine");

            migrationBuilder.DropTable(
                name: "patient_vaccination_data");

            migrationBuilder.DropTable(
                name: "patient_visit_history");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "patient",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 4, 9, 3, 35, 807, DateTimeKind.Local).AddTicks(1280),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 2, 4, 11, 49, 6, 562, DateTimeKind.Local).AddTicks(5970));

            migrationBuilder.UpdateData(
                table: "patient",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "State", "Zip" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "patient",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "State", "Zip" },
                values: new object[] { null, null });
        }
    }
}
