using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogSitesi.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReadCount",
                table: "Articles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PublishDate", "ReadCount" },
                values: new object[] { new DateTime(2025, 1, 1, 0, 57, 13, 522, DateTimeKind.Local).AddTicks(6386), 0 });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PublishDate", "ReadCount" },
                values: new object[] { new DateTime(2025, 1, 1, 0, 57, 13, 522, DateTimeKind.Local).AddTicks(6399), 0 });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PublishDate", "ReadCount" },
                values: new object[] { new DateTime(2025, 1, 1, 0, 57, 13, 522, DateTimeKind.Local).AddTicks(6401), 0 });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8ab919e4-833e-4989-ae76-752ddd541cf6",
                column: "SecurityStamp",
                value: "dd76bf72-3e98-4368-99e3-460d388d608e");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReadCount",
                table: "Articles");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2024, 12, 31, 22, 44, 18, 156, DateTimeKind.Local).AddTicks(4148));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishDate",
                value: new DateTime(2024, 12, 31, 22, 44, 18, 156, DateTimeKind.Local).AddTicks(4160));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishDate",
                value: new DateTime(2024, 12, 31, 22, 44, 18, 156, DateTimeKind.Local).AddTicks(4162));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8ab919e4-833e-4989-ae76-752ddd541cf6",
                column: "SecurityStamp",
                value: "646628cd-2066-4b16-905a-310a63c6c680");
        }
    }
}
