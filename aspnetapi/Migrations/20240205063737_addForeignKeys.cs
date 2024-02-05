using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspnetapp.Migrations
{
    /// <inheritdoc />
    public partial class addForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "patient_visit_history",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 4, 22, 37, 37, 642, DateTimeKind.Local).AddTicks(1520),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 2, 4, 11, 49, 6, 563, DateTimeKind.Local).AddTicks(6350));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "patient_vaccination_data",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 4, 22, 37, 37, 642, DateTimeKind.Local).AddTicks(8170),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 2, 4, 11, 49, 6, 565, DateTimeKind.Local).AddTicks(4090));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "patient_medicine",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 4, 22, 37, 37, 642, DateTimeKind.Local).AddTicks(5880),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 2, 4, 11, 49, 6, 564, DateTimeKind.Local).AddTicks(9000));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "patient_lab_visit",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 4, 22, 37, 37, 641, DateTimeKind.Local).AddTicks(8880),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 2, 4, 11, 49, 6, 563, DateTimeKind.Local).AddTicks(1080));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "patient_lab_result",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 4, 22, 37, 37, 642, DateTimeKind.Local).AddTicks(3640),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 2, 4, 11, 49, 6, 564, DateTimeKind.Local).AddTicks(2100));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "patient",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 4, 22, 37, 37, 641, DateTimeKind.Local).AddTicks(8030),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 2, 4, 11, 49, 6, 562, DateTimeKind.Local).AddTicks(5970));

            migrationBuilder.CreateIndex(
                name: "IX_patient_visit_history_Patient_id",
                table: "patient_visit_history",
                column: "Patient_id");

            migrationBuilder.CreateIndex(
                name: "IX_patient_vaccination_data_Patient_id",
                table: "patient_vaccination_data",
                column: "Patient_id");

            migrationBuilder.CreateIndex(
                name: "IX_patient_medicine_Patient_id",
                table: "patient_medicine",
                column: "Patient_id");

            migrationBuilder.CreateIndex(
                name: "IX_patient_lab_visit_Patient_id",
                table: "patient_lab_visit",
                column: "Patient_id");

            migrationBuilder.CreateIndex(
                name: "IX_patient_lab_result_Patient_id",
                table: "patient_lab_result",
                column: "Patient_id");

            migrationBuilder.AddForeignKey(
                name: "FK_patient_lab_result_patient_Patient_id",
                table: "patient_lab_result",
                column: "Patient_id",
                principalTable: "patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_patient_lab_visit_patient_Patient_id",
                table: "patient_lab_visit",
                column: "Patient_id",
                principalTable: "patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_patient_medicine_patient_Patient_id",
                table: "patient_medicine",
                column: "Patient_id",
                principalTable: "patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_patient_vaccination_data_patient_Patient_id",
                table: "patient_vaccination_data",
                column: "Patient_id",
                principalTable: "patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_patient_visit_history_patient_Patient_id",
                table: "patient_visit_history",
                column: "Patient_id",
                principalTable: "patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_patient_lab_result_patient_Patient_id",
                table: "patient_lab_result");

            migrationBuilder.DropForeignKey(
                name: "FK_patient_lab_visit_patient_Patient_id",
                table: "patient_lab_visit");

            migrationBuilder.DropForeignKey(
                name: "FK_patient_medicine_patient_Patient_id",
                table: "patient_medicine");

            migrationBuilder.DropForeignKey(
                name: "FK_patient_vaccination_data_patient_Patient_id",
                table: "patient_vaccination_data");

            migrationBuilder.DropForeignKey(
                name: "FK_patient_visit_history_patient_Patient_id",
                table: "patient_visit_history");

            migrationBuilder.DropIndex(
                name: "IX_patient_visit_history_Patient_id",
                table: "patient_visit_history");

            migrationBuilder.DropIndex(
                name: "IX_patient_vaccination_data_Patient_id",
                table: "patient_vaccination_data");

            migrationBuilder.DropIndex(
                name: "IX_patient_medicine_Patient_id",
                table: "patient_medicine");

            migrationBuilder.DropIndex(
                name: "IX_patient_lab_visit_Patient_id",
                table: "patient_lab_visit");

            migrationBuilder.DropIndex(
                name: "IX_patient_lab_result_Patient_id",
                table: "patient_lab_result");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "patient_visit_history",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 4, 11, 49, 6, 563, DateTimeKind.Local).AddTicks(6350),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 2, 4, 22, 37, 37, 642, DateTimeKind.Local).AddTicks(1520));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "patient_vaccination_data",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 4, 11, 49, 6, 565, DateTimeKind.Local).AddTicks(4090),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 2, 4, 22, 37, 37, 642, DateTimeKind.Local).AddTicks(8170));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "patient_medicine",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 4, 11, 49, 6, 564, DateTimeKind.Local).AddTicks(9000),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 2, 4, 22, 37, 37, 642, DateTimeKind.Local).AddTicks(5880));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "patient_lab_visit",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 4, 11, 49, 6, 563, DateTimeKind.Local).AddTicks(1080),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 2, 4, 22, 37, 37, 641, DateTimeKind.Local).AddTicks(8880));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "patient_lab_result",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 4, 11, 49, 6, 564, DateTimeKind.Local).AddTicks(2100),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 2, 4, 22, 37, 37, 642, DateTimeKind.Local).AddTicks(3640));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "patient",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 4, 11, 49, 6, 562, DateTimeKind.Local).AddTicks(5970),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 2, 4, 22, 37, 37, 641, DateTimeKind.Local).AddTicks(8030));
        }
    }
}
