using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRProject_BackEnd.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Committees",
                columns: table => new
                {
                    CommitteeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommitteeTitle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ChairmanID = table.Column<int>(type: "int", nullable: false),
                    SecretaryID = table.Column<int>(type: "int", nullable: false),
                    CommitteeStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CommitteeEndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Committees", x => x.CommitteeID);
                });

            migrationBuilder.CreateTable(
                name: "UserInfoes",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsEmployee = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfoes", x => x.UserID);
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommitteesUserInfoes");

            migrationBuilder.DropTable(
                name: "Committees");

            migrationBuilder.DropTable(
                name: "UserInfoes");
        }
    }
}
