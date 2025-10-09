using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameStore.Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ReleaseDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Fighting" },
                    { 2, "Roleplaying" },
                    { 3, "Sports" },
                    { 4, "Racing" },
                    { 5, "Kids and Family" },
                    { 6, "Adventure" },
                    { 7, "Sandbox" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "CreatedAt", "GenreId", "Name", "Price", "ReleaseDate", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 10, 9, 16, 28, 58, 898, DateTimeKind.Utc).AddTicks(6383), 1, "Street Fighter II", 19.99m, new DateOnly(2017, 3, 3), new DateTime(2025, 10, 9, 16, 28, 58, 898, DateTimeKind.Utc).AddTicks(6721) },
                    { 2, new DateTime(2025, 10, 9, 16, 28, 58, 898, DateTimeKind.Utc).AddTicks(7019), 6, "The Zelda", 29.99m, new DateOnly(1998, 11, 21), new DateTime(2025, 10, 9, 16, 28, 58, 898, DateTimeKind.Utc).AddTicks(7020) },
                    { 3, new DateTime(2025, 10, 9, 16, 28, 58, 898, DateTimeKind.Utc).AddTicks(7024), 7, "Minecraft", 26.95m, new DateOnly(2011, 11, 18), new DateTime(2025, 10, 9, 16, 28, 58, 898, DateTimeKind.Utc).AddTicks(7025) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_GenreId",
                table: "Games",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
