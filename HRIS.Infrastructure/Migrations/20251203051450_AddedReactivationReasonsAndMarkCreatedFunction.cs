using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRIS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedReactivationReasonsAndMarkCreatedFunction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "hris",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ReactivatedReason",
                schema: "hris",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "hris",
                table: "EmployeeIdentifications",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ReactivatedReason",
                schema: "hris",
                table: "EmployeeIdentifications",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReactivatedReason",
                schema: "hris",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ReactivatedReason",
                schema: "hris",
                table: "EmployeeIdentifications");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "hris",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "hris",
                table: "EmployeeIdentifications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
