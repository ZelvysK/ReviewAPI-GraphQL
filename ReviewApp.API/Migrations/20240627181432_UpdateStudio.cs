using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviewApp.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStudio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Studios",
                newName: "StudioType");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateEstablished",
                table: "Studios",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateEstablished",
                table: "Studios");

            migrationBuilder.RenameColumn(
                name: "StudioType",
                table: "Studios",
                newName: "Type");
        }
    }
}
