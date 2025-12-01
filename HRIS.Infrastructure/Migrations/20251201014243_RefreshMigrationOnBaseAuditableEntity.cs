using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRIS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RefreshMigrationOnBaseAuditableEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "lookup",
                table: "IdentificationTypes");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "lookup",
                table: "IdentificationTypes");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                schema: "lookup",
                table: "IdentificationTypes");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                schema: "lookup",
                table: "IdentificationTypes");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "lookup",
                table: "IdentificationTypes");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "lookup",
                table: "IdentificationTypes");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                schema: "lookup",
                table: "IdentificationTypes");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                schema: "lookup",
                table: "IdentificationTypes");

            migrationBuilder.AddColumn<string>(
                name: "DeletedReason",
                schema: "hris",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedReason",
                schema: "hris",
                table: "EmployeeIdentifications",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedReason",
                schema: "hris",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DeletedReason",
                schema: "hris",
                table: "EmployeeIdentifications");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "lookup",
                table: "IdentificationTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                schema: "lookup",
                table: "IdentificationTypes",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                schema: "lookup",
                table: "IdentificationTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeletedDate",
                schema: "lookup",
                table: "IdentificationTypes",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                schema: "lookup",
                table: "IdentificationTypes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "lookup",
                table: "IdentificationTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                schema: "lookup",
                table: "IdentificationTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDate",
                schema: "lookup",
                table: "IdentificationTypes",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "lookup",
                table: "IdentificationTypes",
                keyColumn: "IdentificationTypeID",
                keyValue: 1,
                columns: new[] { "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Id", "IsActive", "UpdatedBy", "UpdatedDate" },
                values: new object[] { "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("00000000-0000-0000-0000-000000000000"), true, null, null });

            migrationBuilder.UpdateData(
                schema: "lookup",
                table: "IdentificationTypes",
                keyColumn: "IdentificationTypeID",
                keyValue: 2,
                columns: new[] { "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Id", "IsActive", "UpdatedBy", "UpdatedDate" },
                values: new object[] { "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("00000000-0000-0000-0000-000000000000"), true, null, null });

            migrationBuilder.UpdateData(
                schema: "lookup",
                table: "IdentificationTypes",
                keyColumn: "IdentificationTypeID",
                keyValue: 3,
                columns: new[] { "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Id", "IsActive", "UpdatedBy", "UpdatedDate" },
                values: new object[] { "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("00000000-0000-0000-0000-000000000000"), true, null, null });

            migrationBuilder.UpdateData(
                schema: "lookup",
                table: "IdentificationTypes",
                keyColumn: "IdentificationTypeID",
                keyValue: 4,
                columns: new[] { "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Id", "IsActive", "UpdatedBy", "UpdatedDate" },
                values: new object[] { "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("00000000-0000-0000-0000-000000000000"), true, null, null });

            migrationBuilder.UpdateData(
                schema: "lookup",
                table: "IdentificationTypes",
                keyColumn: "IdentificationTypeID",
                keyValue: 5,
                columns: new[] { "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Id", "IsActive", "UpdatedBy", "UpdatedDate" },
                values: new object[] { "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("00000000-0000-0000-0000-000000000000"), true, null, null });

            migrationBuilder.UpdateData(
                schema: "lookup",
                table: "IdentificationTypes",
                keyColumn: "IdentificationTypeID",
                keyValue: 6,
                columns: new[] { "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Id", "IsActive", "UpdatedBy", "UpdatedDate" },
                values: new object[] { "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("00000000-0000-0000-0000-000000000000"), true, null, null });

            migrationBuilder.UpdateData(
                schema: "lookup",
                table: "IdentificationTypes",
                keyColumn: "IdentificationTypeID",
                keyValue: 7,
                columns: new[] { "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Id", "IsActive", "UpdatedBy", "UpdatedDate" },
                values: new object[] { "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("00000000-0000-0000-0000-000000000000"), true, null, null });
        }
    }
}
