using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VoloLearn.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssimnetVisitors_Assignments_AssignmentId",
                table: "AssimnetVisitors");

            migrationBuilder.DropForeignKey(
                name: "FK_AssimnetVisitors_Users_UserId",
                table: "AssimnetVisitors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssimnetVisitors",
                table: "AssimnetVisitors");

            migrationBuilder.RenameTable(
                name: "AssimnetVisitors",
                newName: "AssignmentVisitors");

            migrationBuilder.RenameIndex(
                name: "IX_AssimnetVisitors_UserId",
                table: "AssignmentVisitors",
                newName: "IX_AssignmentVisitors_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AssimnetVisitors_AssignmentId",
                table: "AssignmentVisitors",
                newName: "IX_AssignmentVisitors_AssignmentId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Roles",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssignmentVisitors",
                table: "AssignmentVisitors",
                column: "Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Name",
                table: "Roles",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AssignmentVisitors_Assignments_AssignmentId",
                table: "AssignmentVisitors",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignmentVisitors_Users_UserId",
                table: "AssignmentVisitors",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentVisitors_Assignments_AssignmentId",
                table: "AssignmentVisitors");

            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentVisitors_Users_UserId",
                table: "AssignmentVisitors");

            migrationBuilder.DropIndex(
                name: "IX_Roles_Name",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssignmentVisitors",
                table: "AssignmentVisitors");

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

            migrationBuilder.RenameTable(
                name: "AssignmentVisitors",
                newName: "AssimnetVisitors");

            migrationBuilder.RenameIndex(
                name: "IX_AssignmentVisitors_UserId",
                table: "AssimnetVisitors",
                newName: "IX_AssimnetVisitors_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AssignmentVisitors_AssignmentId",
                table: "AssimnetVisitors",
                newName: "IX_AssimnetVisitors_AssignmentId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssimnetVisitors",
                table: "AssimnetVisitors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AssimnetVisitors_Assignments_AssignmentId",
                table: "AssimnetVisitors",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AssimnetVisitors_Users_UserId",
                table: "AssimnetVisitors",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
