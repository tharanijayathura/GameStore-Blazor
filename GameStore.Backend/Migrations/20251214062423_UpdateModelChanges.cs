using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.Backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModelChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 14, 6, 24, 22, 282, DateTimeKind.Utc).AddTicks(2324), new DateTime(2025, 12, 14, 6, 24, 22, 282, DateTimeKind.Utc).AddTicks(2516) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 14, 6, 24, 22, 282, DateTimeKind.Utc).AddTicks(2734), new DateTime(2025, 12, 14, 6, 24, 22, 282, DateTimeKind.Utc).AddTicks(2734) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 14, 6, 24, 22, 282, DateTimeKind.Utc).AddTicks(2737), new DateTime(2025, 12, 14, 6, 24, 22, 282, DateTimeKind.Utc).AddTicks(2737) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 9, 16, 28, 58, 898, DateTimeKind.Utc).AddTicks(6383), new DateTime(2025, 10, 9, 16, 28, 58, 898, DateTimeKind.Utc).AddTicks(6721) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 9, 16, 28, 58, 898, DateTimeKind.Utc).AddTicks(7019), new DateTime(2025, 10, 9, 16, 28, 58, 898, DateTimeKind.Utc).AddTicks(7020) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 9, 16, 28, 58, 898, DateTimeKind.Utc).AddTicks(7024), new DateTime(2025, 10, 9, 16, 28, 58, 898, DateTimeKind.Utc).AddTicks(7025) });
        }
    }
}
