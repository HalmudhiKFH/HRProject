using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRProject_BackEnd.Migrations
{
    public partial class Meetings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MeetingsMeetingID",
                table: "Committees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Meetings",
                columns: table => new
                {
                    MeetingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeetingTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeetingStartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MeetingEndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CommitteeID1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetings", x => x.MeetingID);
                    table.ForeignKey(
                        name: "FK_Meetings_Committees_CommitteeID1",
                        column: x => x.CommitteeID1,
                        principalTable: "Committees",
                        principalColumn: "CommitteeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Committees_MeetingsMeetingID",
                table: "Committees",
                column: "MeetingsMeetingID");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_CommitteeID1",
                table: "Meetings",
                column: "CommitteeID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Committees_Meetings_MeetingsMeetingID",
                table: "Committees",
                column: "MeetingsMeetingID",
                principalTable: "Meetings",
                principalColumn: "MeetingID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Committees_Meetings_MeetingsMeetingID",
                table: "Committees");

            migrationBuilder.DropTable(
                name: "Meetings");

            migrationBuilder.DropIndex(
                name: "IX_Committees_MeetingsMeetingID",
                table: "Committees");

            migrationBuilder.DropColumn(
                name: "MeetingsMeetingID",
                table: "Committees");
        }
    }
}
