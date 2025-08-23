using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventManagement.Migrations
{
    /// <inheritdoc />
    public partial class MigrationName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventCategoryId",
                table: "BookingRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BookingRequests_EventCategoryId",
                table: "BookingRequests",
                column: "EventCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingRequests_EventCategories_EventCategoryId",
                table: "BookingRequests",
                column: "EventCategoryId",
                principalTable: "EventCategories",
                principalColumn: "EventCategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingRequests_EventCategories_EventCategoryId",
                table: "BookingRequests");

            migrationBuilder.DropIndex(
                name: "IX_BookingRequests_EventCategoryId",
                table: "BookingRequests");

            migrationBuilder.DropColumn(
                name: "EventCategoryId",
                table: "BookingRequests");
        }
    }
}
