using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VoloLearn.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusToEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Assignments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("0c0b897e-44ff-4e6c-9c1b-98ca025670e3"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("41028355-f898-4f84-b042-948020fec3af"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("6fa73bc6-fe3d-40b7-8bbc-b75251b21d7a"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("749d69d7-adf3-4e1c-8bf5-c191a25edf6c"));

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Assignments");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsSuperUser", "Name" },
                values: new object[,]
                {
                    { new Guid("7eb41aa7-4cc7-4891-854f-b1d1392db8f1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Organisation" },
                    { new Guid("8ea33f91-58f4-4076-979b-626d3c4ad713"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Moderator" },
                    { new Guid("b6b228e5-01cc-48e7-898b-c5064fdfb607"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Volonteer" },
                    { new Guid("dbb5552c-e463-41fe-8cd3-db9cba033674"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "School" }
                });
        }
    }
}
