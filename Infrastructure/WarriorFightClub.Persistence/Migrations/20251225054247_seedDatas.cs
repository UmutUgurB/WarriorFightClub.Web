using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WarriorFightClub.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class seedDatas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Packages_Title",
                table: "Packages");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Packages",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Packages",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Packages",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Id", "CreatedDate", "Description", "Features", "ImageUrl", "IsActive", "Title" },
                values: new object[,]
                {
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb1"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Spora yeni başlayanlar için temel program ve takip.", "Haftada 3 gün program; Ölçüm takibi; Salon kullanımı", "https://www.macfit.com/wp-content/uploads/2022/11/fitness-salonlari-1024x683.jpg", true, "Başlangıç Paketi" },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb2"), new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), "Gelişmiş program + daha sık takip ve danışmanlık.", "Haftada 5 gün program; Beslenme önerisi; Aylık ölçüm", "https://www.sportsuniverse.com.tr/wp-content/uploads/2020/06/905A8B53-D0A3-45E3-8CDF-3AA4A5B9C24F.jpeg", true, "Pro Paket" },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb3"), new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc), "Antrenör ile bire bir çalışma ve maksimum verim.", "Bire bir seans; Program planlama; Haftalık takip", "https://media.istockphoto.com/id/2075354173/tr/foto%C4%9Fraf/fitness-couple-is-doing-kettlebell-twist-in-a-gym-togehter.jpg?s=612x612&w=0&k=20&c=GibU8-6Ydswl3qjVPJ8FIx8c7_15aYf-rw0wg85M_oo=", true, "PT (Bire Bir) Paketi" }
                });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Id", "CreatedDate", "Description", "Features", "ImageUrl", "Title" },
                values: new object[] { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb4"), new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Şirket çalışanlarına özel toplu üyelik ve avantajlar.", "Toplu üyelik indirimi; Kurumsal raporlama; Esnek plan", "https://nutrade.com.tr/cdn/shop/articles/Fitness-ile-Ilgili-Bilinmesi-Gerekenler.jpg?v=1701794880", "Kurumsal Paket" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreatedDate", "Description", "ImageUrl", "Title" },
                values: new object[] { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaeaaaaa4"), new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Uzaktan program, beslenme önerileri ve düzenli kontrol.", "https://images.squarespace-cdn.com/content/v1/60b770454e1e5542857bb262/1694527499153-QZ4BDA3SIN9L5AICSB34/ukactive-Swimming-lessons-lost-in-lockdown.jpg", "Yüzme Dersleri" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreatedDate", "Description", "ImageUrl", "IsActive", "Title" },
                values: new object[,]
                {
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaacaaaaaa2"), new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), "Dayanıklılık, kuvvet ve hareket kabiliyetini artıran programlar.", "https://www.skechers.com.tr/blog/wp-content/uploads/2023/03/fitnes.jpg", true, "Fonksiyonel Antrenman" },
                    { new Guid("aaaaaaaa-aaaa-aafa-aaaa-aaaaaaaaaaa3"), new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc), "Teknik gelişim + kondisyon odaklı dövüş sporları antrenmanları.", "https://img2.storyblok.com/690x690/filters:focal(null):format(png)/f/115220/1100x1100/f1f74de82a/mitt_work.png", true, "Boks & Kickboks" },
                    { new Guid("aaaaaaaa-abaa-aaaa-aaaa-aaaaaaaaaaa1"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Hedeflerinize uygun, bire bir antrenman planı ve takip.", "https://images.squarespace-cdn.com/content/v1/5ede457a2188e55de5de09a7/1591889835496-GPGGP2ZIRL0V41HKKOGH/The+Benefits+Of+Personal+Training+At+Home.jpg", true, "Kişisel Antrenman" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreatedDate", "Description", "ImageUrl", "Title" },
                values: new object[,]
                {
                    { new Guid("aaaafaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa4"), new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Uzaktan program, beslenme önerileri ve düzenli kontrol.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTxl96SR5NMdDrgO2O2wkRFmlfUPrYTobwBzA&s", "Pilates" },
                    { new Guid("aaacaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa4"), new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Uzaktan program, beslenme önerileri ve düzenli kontrol.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTqAiIpZh7QAtitPhv_6kLZPftvIU1_G3lbRg&s", "Online Koçluk" }
                });

            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "Id", "BirthDate", "CreatedDate", "Description", "ImageUrl", "Name", "Surname" },
                values: new object[] { new Guid("cccccccc-cccc-bccc-cccc-ccccccccccc4"), null, new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Uzmanlar için temel programlar ve beslenme danışmanlığı.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcStzFOrI0wwFupHIFL7p0lU3Brr9MaQv70MrQ&s", "Akif", "Aydın" });

            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "Id", "BirthDate", "CreatedDate", "Description", "ImageUrl", "IsActive", "Name", "Surname" },
                values: new object[,]
                {
                    { new Guid("cccccccc-cccc-cccc-cccc-ccccccccccc1"), new DateTime(1992, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Fonksiyonel antrenman ve kuvvet geliştirme uzmanı.", "https://hips.hearstapps.com/hmg-prod/images/mh-trainer-2-1533576998.png?resize=640:*", true, "Ahmet", "Yılmaz" },
                    { new Guid("cccccccc-ccfc-cccc-cccc-ccccccccccc2"), new DateTime(1995, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), "Pilates, mobilite ve postür düzeltme odaklı çalışmalar.", "https://www.shutterstock.com/shutterstock/photos/1583397034/display_1500/stock-photo-young-female-fitness-personal-trainer-with-notepad-standing-in-the-gym-with-thumb-up-1583397034.jpg", true, "Elif", "Demir" },
                    { new Guid("cccccccd-cccc-cccc-cccc-ccccccccccc3"), new DateTime(1990, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc), "Boks ve kickboks antrenörü, kondisyon odaklı programlar.", "https://images.ctfassets.net/qw8ps43tg2ux/1LPfI8kPATAzojZMBalhli/7dbdddba786444110a762b75977a8fd8/how-it-works-issa-certified-personal-trainer.webp?fm=webp&w=1440&q=75", true, "Mert", "Kaya" }
                });

            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "Id", "BirthDate", "CreatedDate", "Description", "ImageUrl", "Name", "Surname" },
                values: new object[] { new Guid("ccccccec-cccc-cccc-cccc-cccccaccccc4"), null, new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Yeni başlayanlar için temel programlar ve beslenme danışmanlığı.", "https://ici.net.au/blog/wp-content/uploads/2019/04/BecomePersonalTrainer-1024x683.jpg", "Zeynep", "Aydın" });

            migrationBuilder.CreateIndex(
                name: "IX_Packages_CreatedDate",
                table: "Packages",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_IsActive",
                table: "Packages",
                column: "IsActive");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Packages_CreatedDate",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_IsActive",
                table: "Packages");

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb1"));

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb2"));

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb3"));

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb4"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaeaaaaa4"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaacaaaaaa2"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aafa-aaaa-aaaaaaaaaaa3"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-abaa-aaaa-aaaa-aaaaaaaaaaa1"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("aaaafaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa4"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("aaacaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa4"));

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-cccc-bccc-cccc-ccccccccccc4"));

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-cccc-cccc-cccc-ccccccccccc1"));

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-ccfc-cccc-cccc-ccccccccccc2"));

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: new Guid("cccccccd-cccc-cccc-cccc-ccccccccccc3"));

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: new Guid("ccccccec-cccc-cccc-cccc-cccccaccccc4"));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Packages",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Packages",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Packages",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.CreateIndex(
                name: "IX_Packages_Title",
                table: "Packages",
                column: "Title");
        }
    }
}
