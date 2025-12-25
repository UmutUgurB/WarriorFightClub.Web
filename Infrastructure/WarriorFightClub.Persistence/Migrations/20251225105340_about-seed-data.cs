using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarriorFightClub.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class aboutseeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Abouts",
                columns: new[] { "Id", "CreatedDate", "Description", "ImageUrl", "IsActive", "SubTitle", "Title" },
                values: new object[] { new Guid("a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d"), new DateTime(2025, 12, 25, 10, 53, 40, 264, DateTimeKind.Utc).AddTicks(1183), "Warrior Fight Club, modern dövüş sanatları tekniklerini profesyonel eğitmenler eşliğinde sunan, disiplin ve gücü odak noktasına alan bir spor salonudur. Burada sadece vücudunuzu değil, iradenizi de eğitiyoruz.", "https://lh5.googleusercontent.com/proxy/stFBPjVPFdJzQCb1Rbb2XU4MlsoM522iD7cVRBVpH-8Kj7VcmKxBMK03tHVqPifTmqL64p62CiJMduxyH3aEtX06Kp_9MppCXE3uUK2dcDVNRlvy-EsPRp9i62bmhYIJzcbVd24", true, "Sınırlarını Zorlamaya Hazır Mısın?", "Warrior Fight Club" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d"));
        }
    }
}
