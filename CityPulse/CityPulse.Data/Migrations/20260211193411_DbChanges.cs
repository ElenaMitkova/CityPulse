using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityPulse.Data.Migrations
{
    /// <inheritdoc />
    public partial class DbChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_AuthorId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Users_AuthorId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Users_ModifierId",
                table: "Reports");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Reports_AuthorId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_ModifierId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Comments_AuthorId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "ModifierId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Comments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Reports",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifierId",
                table: "Reports",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    JoinedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastLogIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reports_AuthorId",
                table: "Reports",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ModifierId",
                table: "Reports",
                column: "ModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AuthorId",
                table: "Comments",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_AuthorId",
                table: "Comments",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Users_AuthorId",
                table: "Reports",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Users_ModifierId",
                table: "Reports",
                column: "ModifierId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
