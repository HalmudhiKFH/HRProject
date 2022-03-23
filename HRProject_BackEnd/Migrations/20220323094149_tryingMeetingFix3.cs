using Microsoft.EntityFrameworkCore.Migrations;

namespace HRProject_BackEnd.Migrations
{
    public partial class tryingMeetingFix3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_Committees_CommitteeID",
                table: "Meetings");

            migrationBuilder.AlterColumn<int>(
                name: "CommitteeID",
                table: "Meetings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_Committees_CommitteeID",
                table: "Meetings",
                column: "CommitteeID",
                principalTable: "Committees",
                principalColumn: "CommitteeID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_Committees_CommitteeID",
                table: "Meetings");

            migrationBuilder.AlterColumn<int>(
                name: "CommitteeID",
                table: "Meetings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_Committees_CommitteeID",
                table: "Meetings",
                column: "CommitteeID",
                principalTable: "Committees",
                principalColumn: "CommitteeID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
