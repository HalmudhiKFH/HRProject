using Microsoft.EntityFrameworkCore.Migrations;

namespace HRProject_BackEnd.Migrations
{
    public partial class tryingMeetingFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Committees_Meetings_MeetingsMeetingID",
                table: "Committees");

            migrationBuilder.DropIndex(
                name: "IX_Committees_MeetingsMeetingID",
                table: "Committees");

            migrationBuilder.DropColumn(
                name: "MeetingsMeetingID",
                table: "Committees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MeetingsMeetingID",
                table: "Committees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Committees_MeetingsMeetingID",
                table: "Committees",
                column: "MeetingsMeetingID");

            migrationBuilder.AddForeignKey(
                name: "FK_Committees_Meetings_MeetingsMeetingID",
                table: "Committees",
                column: "MeetingsMeetingID",
                principalTable: "Meetings",
                principalColumn: "MeetingID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
