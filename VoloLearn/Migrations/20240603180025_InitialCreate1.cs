using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VoloLearn.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Users_OrganisationId",
                table: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_OrganisationId",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "OrganisationId",
                table: "Assignments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OrganisationId",
                table: "Assignments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_OrganisationId",
                table: "Assignments",
                column: "OrganisationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Users_OrganisationId",
                table: "Assignments",
                column: "OrganisationId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
