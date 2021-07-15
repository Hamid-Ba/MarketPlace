using Microsoft.EntityFrameworkCore.Migrations;

namespace MarketPlace.Infrastructure.EfCore.Migrations
{
    public partial class MappingCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketMessage_Tickets_TicketId",
                table: "TicketMessage");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketMessage_Tickets_TicketId",
                table: "TicketMessage",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketMessage_Tickets_TicketId",
                table: "TicketMessage");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketMessage_Tickets_TicketId",
                table: "TicketMessage",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
