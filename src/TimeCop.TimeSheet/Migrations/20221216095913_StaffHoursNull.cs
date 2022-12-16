using Microsoft.EntityFrameworkCore.Migrations;
using NodaTime;

#nullable disable

namespace TimeCop.TimeSheet.Migrations
{
    /// <inheritdoc />
    public partial class StaffHoursNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ModifyState",
                table: "Hours",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ModifyReason",
                table: "Hours",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<LocalTime>(
                name: "ModifiedTo",
                table: "Hours",
                type: "time",
                nullable: true,
                oldClrType: typeof(LocalTime),
                oldType: "time");

            migrationBuilder.AlterColumn<LocalTime>(
                name: "ModifiedFrom",
                table: "Hours",
                type: "time",
                nullable: true,
                oldClrType: typeof(LocalTime),
                oldType: "time");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "Hours",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ModifyState",
                table: "Hours",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifyReason",
                table: "Hours",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<LocalTime>(
                name: "ModifiedTo",
                table: "Hours",
                type: "time",
                nullable: false,
                defaultValue: new NodaTime.LocalTime(0, 0),
                oldClrType: typeof(LocalTime),
                oldType: "time",
                oldNullable: true);

            migrationBuilder.AlterColumn<LocalTime>(
                name: "ModifiedFrom",
                table: "Hours",
                type: "time",
                nullable: false,
                defaultValue: new NodaTime.LocalTime(0, 0),
                oldClrType: typeof(LocalTime),
                oldType: "time",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "Hours",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
