using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MarketPlace.Infrastructure.EfCore.Migrations
{
    public partial class AddCreationDateToTicketMessages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketMessage_Tickets_TicketId",
                table: "TicketMessage");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "TicketMessage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

            migrationBuilder.DropColumn(
                name: "CreationDate",
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
