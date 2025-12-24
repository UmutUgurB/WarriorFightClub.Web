using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarriorFightClub.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class bannerimageUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SutTitle",
                table: "Banners",
                newName: "SubTitle");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Banners",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Banners");

            migrationBuilder.RenameColumn(
                name: "SubTitle",
                table: "Banners",
                newName: "SutTitle");
        }
    }
}
