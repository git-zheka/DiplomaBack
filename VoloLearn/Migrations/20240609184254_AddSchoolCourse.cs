using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VoloLearn.Migrations
{
    /// <inheritdoc />
    public partial class AddSchoolCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Users_CreatedById",
                table: "Assignments");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("3a63080e-d287-4106-a35d-4c267a13b19e"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d3bd529-1813-4627-8ec9-0531b1c1f4f9"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a2b6dd96-2c14-4db1-8498-ccc36edaf6d2"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("fbb45d0f-8429-481c-9bdf-1ed6a8637702"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "SchoolCourses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedById",
                table: "Assignments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsSuperUser", "Name" },
                values: new object[,]
                {
                    { new Guid("0ea3e473-997f-499d-adbc-274164513597"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "School" },
                    { new Guid("49e17253-9089-417c-9b36-79f7a91bccfa"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Organisation" },
                    { new Guid("cac4fbc3-c513-448e-9720-ab75668fe682"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Volonteer" },
                    { new Guid("de373719-66f4-4599-af45-cff207e59126"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Moderator" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SchoolCourses_CreatedById",
                table: "SchoolCourses",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Users_CreatedById",
                table: "Assignments",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolCourses_Users_CreatedById",
                table: "SchoolCourses",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Users_CreatedById",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_SchoolCourses_Users_CreatedById",
                table: "SchoolCourses");

            migrationBuilder.DropIndex(
                name: "IX_SchoolCourses_CreatedById",
                table: "SchoolCourses");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("0ea3e473-997f-499d-adbc-274164513597"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("49e17253-9089-417c-9b36-79f7a91bccfa"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("cac4fbc3-c513-448e-9720-ab75668fe682"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("de373719-66f4-4599-af45-cff207e59126"));

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "SchoolCourses");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedById",
                table: "Assignments",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsSuperUser", "Name" },
                values: new object[,]
                {
                    { new Guid("3a63080e-d287-4106-a35d-4c267a13b19e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Moderator" },
                    { new Guid("8d3bd529-1813-4627-8ec9-0531b1c1f4f9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Volonteer" },
                    { new Guid("a2b6dd96-2c14-4db1-8498-ccc36edaf6d2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "School" },
                    { new Guid("fbb45d0f-8429-481c-9bdf-1ed6a8637702"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Organisation" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Users_CreatedById",
                table: "Assignments",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
