using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VoloLearn.Migrations
{
    /// <inheritdoc />
    public partial class AddAsignmentStatuses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentVisitors_Assignments_AssignmentId",
                table: "AssignmentVisitors");

            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentVisitors_Users_UserId",
                table: "AssignmentVisitors");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("3f55c138-996e-42a4-a77a-efc39103d02f"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7b0422e9-3efc-4e4a-83a0-7f321a5dfb21"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("80dea8a8-2062-48ee-afd5-c3f74f89125b"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("e938c6e6-a67a-4e77-8d82-c9166bfa5b58"));

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "AssignmentVisitors",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "AssignmentId",
                table: "AssignmentVisitors",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("1a807876-0bb2-4bc1-90d0-ebaca6e7a0df"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7043e3dc-bda2-427d-a12b-0f664c09defe"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("99d85222-51f1-4f2f-8fd4-bec554bae19c"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("bf076036-c548-4095-acfd-6006ca12858c"));

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "AssignmentVisitors",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AssignmentId",
                table: "AssignmentVisitors",
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
                    { new Guid("3f55c138-996e-42a4-a77a-efc39103d02f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Moderator" },
                    { new Guid("7b0422e9-3efc-4e4a-83a0-7f321a5dfb21"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Volonteer" },
                    { new Guid("80dea8a8-2062-48ee-afd5-c3f74f89125b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Organisation" },
                    { new Guid("e938c6e6-a67a-4e77-8d82-c9166bfa5b58"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "School" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AssignmentVisitors_Assignments_AssignmentId",
                table: "AssignmentVisitors",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssignmentVisitors_Users_UserId",
                table: "AssignmentVisitors",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
