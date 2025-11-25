using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HRIS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "lookup",
                table: "CivilStatuses",
                columns: new[] { "CivilStatusID", "StatusCode", "StatusDescription" },
                values: new object[,]
                {
                    { 1, "S", "Single" },
                    { 2, "M", "Married" },
                    { 3, "W", "Widowed" },
                    { 4, "S", "Separated" }
                });

            migrationBuilder.InsertData(
                schema: "lookup",
                table: "IdentificationTypes",
                columns: new[] { "IdentificationTypeID", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Description", "Id", "IsActive", "Type", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Tax Identification Number", new Guid("00000000-0000-0000-0000-000000000000"), false, "TIN", null, null },
                    { 2, "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "PhilHealth ID", new Guid("00000000-0000-0000-0000-000000000000"), false, "PhilHealth", null, null },
                    { 3, "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Social Security System ID", new Guid("00000000-0000-0000-0000-000000000000"), false, "SSS", null, null },
                    { 4, "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Government Service Insurance System ID", new Guid("00000000-0000-0000-0000-000000000000"), false, "GSIS", null, null },
                    { 5, "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Philippine National ID", new Guid("00000000-0000-0000-0000-000000000000"), false, "National ID", null, null },
                    { 6, "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "PRC License", new Guid("00000000-0000-0000-0000-000000000000"), false, "PRC License", null, null },
                    { 7, "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Driver's License ID", new Guid("00000000-0000-0000-0000-000000000000"), false, "Driver's License", null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "lookup",
                table: "CivilStatuses",
                keyColumn: "CivilStatusID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "lookup",
                table: "CivilStatuses",
                keyColumn: "CivilStatusID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "lookup",
                table: "CivilStatuses",
                keyColumn: "CivilStatusID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "lookup",
                table: "CivilStatuses",
                keyColumn: "CivilStatusID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "lookup",
                table: "IdentificationTypes",
                keyColumn: "IdentificationTypeID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "lookup",
                table: "IdentificationTypes",
                keyColumn: "IdentificationTypeID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "lookup",
                table: "IdentificationTypes",
                keyColumn: "IdentificationTypeID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "lookup",
                table: "IdentificationTypes",
                keyColumn: "IdentificationTypeID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "lookup",
                table: "IdentificationTypes",
                keyColumn: "IdentificationTypeID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "lookup",
                table: "IdentificationTypes",
                keyColumn: "IdentificationTypeID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "lookup",
                table: "IdentificationTypes",
                keyColumn: "IdentificationTypeID",
                keyValue: 7);
        }
    }
}
