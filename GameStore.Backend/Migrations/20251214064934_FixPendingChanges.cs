using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.Backend.Migrations
{
    /// <inheritdoc />
    public partial class FixPendingChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 14, 6, 49, 33, 8, DateTimeKind.Utc).AddTicks(1622), new DateTime(2025, 12, 14, 6, 49, 33, 8, DateTimeKind.Utc).AddTicks(1818) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 14, 6, 49, 33, 8, DateTimeKind.Utc).AddTicks(1999), new DateTime(2025, 12, 14, 6, 49, 33, 8, DateTimeKind.Utc).AddTicks(1999) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 14, 6, 49, 33, 8, DateTimeKind.Utc).AddTicks(2003), new DateTime(2025, 12, 14, 6, 49, 33, 8, DateTimeKind.Utc).AddTicks(2004) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
