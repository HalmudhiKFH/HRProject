using Microsoft.EntityFrameworkCore.Migrations;

namespace HRProject_BackEnd.Migrations
{
    public partial class tryingMeetingFix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_Committees_CommitteeID1",
                table: "Meetings");

            migrationBuilder.DropTable(
                name: "CommitteesUserInfoes");

            migrationBuilder.RenameColumn(
                name: "CommitteeID1",
                table: "Meetings",
                newName: "CommitteeID");

            migrationBuilder.RenameIndex(
                name: "IX_Meetings_CommitteeID1",
                table: "Meetings",
                newName: "IX_Meetings_CommitteeID");

            migrationBuilder.CreateTable(
                name: "CommitteeUserInfo",
                columns: table => new
                {
                    CommitteesCommitteeID = table.Column<int>(type: "int", nullable: false),
                    UserInfoesUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommitteeUserInfo", x => new { x.CommitteesCommitteeID, x.UserInfoesUserID });
                    table.ForeignKey(
                        name: "FK_CommitteeUserInfo_Committees_CommitteesCommitteeID",
                        column: x => x.CommitteesCommitteeID,
                        principalTable: "Committees",
                        principalColumn: "CommitteeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommitteeUserInfo_UserInfoes_UserInfoesUserID",
                        column: x => x.UserInfoesUserID,
                        principalTable: "UserInfoes",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommitteeUserInfo_UserInfoesUserID",
                table: "CommitteeUserInfo",
                column: "UserInfoesUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_Committees_CommitteeID",
                table: "Meetings",
                column: "CommitteeID",
                principalTable: "Committees",
                principalColumn: "CommitteeID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_Committees_CommitteeID",
                table: "Meetings");

            migrationBuilder.DropTable(
                name: "CommitteeUserInfo");

            migrationBuilder.RenameColumn(
                name: "CommitteeID",
                table: "Meetings",
                newName: "CommitteeID1");

            migrationBuilder.RenameIndex(
                name: "IX_Meetings_CommitteeID",
                table: "Meetings",
                newName: "IX_Meetings_CommitteeID1");

            migrationBuilder.CreateTable(
                name: "CommitteesUserInfoes",
                columns: table => new
                {
                    CommitteesCommitteeID = table.Column<int>(type: "int", nullable: false),
                    UserInfoesUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommitteesUserInfoes", x => new { x.CommitteesCommitteeID, x.UserInfoesUserID });
                    table.ForeignKey(
                        name: "FK_CommitteesUserInfoes_Committees_CommitteesCommitteeID",
                        column: x => x.CommitteesCommitteeID,
                        principalTable: "Committees",
                        principalColumn: "CommitteeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommitteesUserInfoes_UserInfoes_UserInfoesUserID",
                        column: x => x.UserInfoesUserID,
                        principalTable: "UserInfoes",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommitteesUserInfoes_UserInfoesUserID",
                table: "CommitteesUserInfoes",
                column: "UserInfoesUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_Committees_CommitteeID1",
                table: "Meetings",
                column: "CommitteeID1",
                principalTable: "Committees",
                principalColumn: "CommitteeID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
