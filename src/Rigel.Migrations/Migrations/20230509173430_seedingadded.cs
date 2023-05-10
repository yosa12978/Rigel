using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Rigel.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class seedingadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { "aS2Fg5J77g", "test2" },
                    { "aS2Fg5J77h", "test3" },
                    { "aS2Fg5J77o", "test1" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "avatar", "isActive", "nickname", "password", "regDate", "role", "salt", "username" },
                values: new object[,]
                {
                    { "h80G46mN5p", "https://cdn.gpblog.com/news/2023/05/07/v2_large_7daff622d2093db14e6e82ff5810c16d444b8a8a.jpeg", true, "slave", "22b1f2494b8b75f069b5b00cc29e07ef", new DateTime(2023, 5, 9, 17, 34, 30, 495, DateTimeKind.Utc).AddTicks(8569), "USER", "usersalt", "user" },
                    { "Ul524hmF82", "https://cdn-6.motorsport.com/images/mgl/Y99JQRbY/s8/red-bull-racing-logo-1.jpg", true, "master", "c73d82322484717cb277b3146a968928", new DateTime(2023, 5, 9, 17, 34, 30, 495, DateTimeKind.Utc).AddTicks(8565), "USER", "adminsalt", "admin" }
                });

            migrationBuilder.InsertData(
                table: "posts",
                columns: new[] { "id", "authorId", "categoryId", "changeDate", "deleted", "edited", "pubDate", "subject" },
                values: new object[,]
                {
                    { "sdgwe3uhi1", "h80G46mN5p", "aS2Fg5J77o", new DateTime(2023, 5, 9, 17, 34, 30, 495, DateTimeKind.Utc).AddTicks(8668), false, false, new DateTime(2023, 5, 9, 17, 34, 30, 495, DateTimeKind.Utc).AddTicks(8668), "test subject 1" },
                    { "sdgweruhiq", "h80G46mN5p", "aS2Fg5J77o", new DateTime(2023, 5, 9, 17, 34, 30, 495, DateTimeKind.Utc).AddTicks(8668), false, false, new DateTime(2023, 5, 9, 17, 34, 30, 495, DateTimeKind.Utc).AddTicks(8668), "test subject 1" }
                });

            migrationBuilder.InsertData(
                table: "messages",
                columns: new[] { "id", "authorId", "content", "deleted", "edited", "parentId", "postId", "pubDate" },
                values: new object[,]
                {
                    { "1234567890", "Ul524hmF82", "test content 123", false, false, null, "sdgweruhiq", new DateTime(2023, 5, 9, 20, 34, 30, 495, DateTimeKind.Local).AddTicks(8678) },
                    { "0987654321", "h80G46mN5p", "test reply 1", false, false, "1234567890", "sdgweruhiq", new DateTime(2023, 5, 9, 20, 34, 30, 495, DateTimeKind.Local).AddTicks(8687) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: "aS2Fg5J77g");

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: "aS2Fg5J77h");

            migrationBuilder.DeleteData(
                table: "messages",
                keyColumn: "id",
                keyValue: "0987654321");

            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "id",
                keyValue: "sdgwe3uhi1");

            migrationBuilder.DeleteData(
                table: "messages",
                keyColumn: "id",
                keyValue: "1234567890");

            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "id",
                keyValue: "sdgweruhiq");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: "Ul524hmF82");

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: "aS2Fg5J77o");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: "h80G46mN5p");
        }
    }
}
