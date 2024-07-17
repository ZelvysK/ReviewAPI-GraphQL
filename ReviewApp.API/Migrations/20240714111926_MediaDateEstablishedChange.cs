using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviewApp.API.Migrations
{
    /// <inheritdoc />
    public partial class MediaDateEstablishedChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateFounded",
                table: "Media",
                newName: "DateEstablished");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateEstablished",
                table: "Media",
                newName: "DateFounded");
        }
    }
}
