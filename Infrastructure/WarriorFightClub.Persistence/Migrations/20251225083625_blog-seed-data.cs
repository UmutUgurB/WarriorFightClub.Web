using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WarriorFightClub.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class blogseeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categories",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Blogs",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Blogs",
                type: "nvarchar(600)",
                maxLength: 600,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("0d9aa7a6-1bd6-46d2-9a8e-87e4d9b9c5b1"), new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc), "Sağlıklı beslenme ve yaşam tarzı.", "Beslenme" },
                    { new Guid("b4a4f2c6-6c55-4c45-8a16-2f3b6c0d1a11"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Kuvvet, kondisyon ve genel fitness içerikleri.", "Fitness" },
                    { new Guid("c9c1a2b0-7a26-4b2f-9b4c-1f0a2d7a3b22"), new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), "Boks, kickboks ve teknik içerikler.", "Dövüş Sporları" }
                });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "ImageUrl", "Status", "Title" },
                values: new object[,]
                {
                    { new Guid("0f3a2d7a-1b3c-4a61-8f9a-2f3b2f3c7d2f"), new Guid("0d9aa7a6-1bd6-46d2-9a8e-87e4d9b9c5b1"), new DateTime(2025, 1, 9, 0, 0, 0, 0, DateTimeKind.Utc), "Kas onarımı, toparlanma ve günlük protein hedefi.", "https://images.unsplash.com/photo-1540189549336-e6e99c3679fe?w=1200", 1, "Protein Nedir? Ne Zaman Tüketilmeli?" },
                    { new Guid("2f3b2f3c-7d2f-4a61-8f9a-0f3a2d7a1b3c"), new Guid("0d9aa7a6-1bd6-46d2-9a8e-87e4d9b9c5b1"), new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Kalori dengesi, protein önceliği ve sürdürülebilir alışkanlıklar.", "https://images.unsplash.com/photo-1490645935967-10de6ba17061?w=1200", 0, "Yağ Yakımı İçin Basit Beslenme Prensipleri" },
                    { new Guid("7c5d6c0d-6b03-4a90-a82e-3cefb2df0e3a"), new Guid("b4a4f2c6-6c55-4c45-8a16-2f3b6c0d1a11"), new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Squat, push-up, row, plank ve deadlift ile temel bir başlangıç planı.", "https://images.unsplash.com/photo-1517836357463-d25dfeac3438?w=1200", 1, "Yeni Başlayanlar İçin 5 Temel Hareket" },
                    { new Guid("b62f8d9d-4b17-4b2a-90e8-3f13f6a8d3e1"), new Guid("b4a4f2c6-6c55-4c45-8a16-2f3b6c0d1a11"), new DateTime(2025, 1, 6, 0, 0, 0, 0, DateTimeKind.Utc), "Interval, tempo koşu ve düzenli takip ile kondisyon geliştirme.", "https://images.unsplash.com/photo-1554284126-aa88f22d8b74?w=1200", 1, "Kondisyonu Artırmanın 3 Yolu" },
                    { new Guid("c1d6a6d3-9c2d-4c4f-9a89-8c90a4c5afaa"), new Guid("c9c1a2b0-7a26-4b2f-9b4c-1f0a2d7a3b22"), new DateTime(2025, 1, 7, 0, 0, 0, 0, DateTimeKind.Utc), "Doğru guard pozisyonu, mesafe ve zamanlama ipuçları.", "https://images.unsplash.com/photo-1517438984742-1262db08379e?w=1200", 1, "Boks’ta Guard ve Mesafe Kontrolü" },
                    { new Guid("f7a11f8a-3a7a-4df8-9b3d-5f4b3a9f1b22"), new Guid("c9c1a2b0-7a26-4b2f-9b4c-1f0a2d7a3b22"), new DateTime(2025, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), "1-2-low kick ve basic kombinasyon setleri.", "https://images.unsplash.com/photo-1549476464-37392f717541?w=1200", 0, "Kickboks’ta Kombinasyonlar" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CreatedDate",
                table: "Categories",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_CreatedDate",
                table: "Blogs",
                column: "CreatedDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Categories_CreatedDate",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_CreatedDate",
                table: "Blogs");

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: new Guid("0f3a2d7a-1b3c-4a61-8f9a-2f3b2f3c7d2f"));

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: new Guid("2f3b2f3c-7d2f-4a61-8f9a-0f3a2d7a1b3c"));

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: new Guid("7c5d6c0d-6b03-4a90-a82e-3cefb2df0e3a"));

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: new Guid("b62f8d9d-4b17-4b2a-90e8-3f13f6a8d3e1"));

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: new Guid("c1d6a6d3-9c2d-4c4f-9a89-8c90a4c5afaa"));

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: new Guid("f7a11f8a-3a7a-4df8-9b3d-5f4b3a9f1b22"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0d9aa7a6-1bd6-46d2-9a8e-87e4d9b9c5b1"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b4a4f2c6-6c55-4c45-8a16-2f3b6c0d1a11"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c9c1a2b0-7a26-4b2f-9b4c-1f0a2d7a3b22"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Blogs",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Blogs",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(600)",
                oldMaxLength: 600);
        }
    }
}
