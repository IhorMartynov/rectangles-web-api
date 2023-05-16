using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rectangles.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddedIndexesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Rectangles_X1",
                table: "Rectangles",
                column: "X1");

            migrationBuilder.CreateIndex(
                name: "IX_Rectangles_X2",
                table: "Rectangles",
                column: "X2");

            migrationBuilder.CreateIndex(
                name: "IX_Rectangles_X3",
                table: "Rectangles",
                column: "X3");

            migrationBuilder.CreateIndex(
                name: "IX_Rectangles_X4",
                table: "Rectangles",
                column: "X4");

            migrationBuilder.CreateIndex(
                name: "IX_Rectangles_Y1",
                table: "Rectangles",
                column: "Y1");

            migrationBuilder.CreateIndex(
                name: "IX_Rectangles_Y2",
                table: "Rectangles",
                column: "Y2");

            migrationBuilder.CreateIndex(
                name: "IX_Rectangles_Y3",
                table: "Rectangles",
                column: "Y3");

            migrationBuilder.CreateIndex(
                name: "IX_Rectangles_Y4",
                table: "Rectangles",
                column: "Y4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Rectangles_X1",
                table: "Rectangles");

            migrationBuilder.DropIndex(
                name: "IX_Rectangles_X2",
                table: "Rectangles");

            migrationBuilder.DropIndex(
                name: "IX_Rectangles_X3",
                table: "Rectangles");

            migrationBuilder.DropIndex(
                name: "IX_Rectangles_X4",
                table: "Rectangles");

            migrationBuilder.DropIndex(
                name: "IX_Rectangles_Y1",
                table: "Rectangles");

            migrationBuilder.DropIndex(
                name: "IX_Rectangles_Y2",
                table: "Rectangles");

            migrationBuilder.DropIndex(
                name: "IX_Rectangles_Y3",
                table: "Rectangles");

            migrationBuilder.DropIndex(
                name: "IX_Rectangles_Y4",
                table: "Rectangles");
        }
    }
}
