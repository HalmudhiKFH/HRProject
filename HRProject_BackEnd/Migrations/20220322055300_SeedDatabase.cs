using Microsoft.EntityFrameworkCore.Migrations;

namespace HRProject_BackEnd.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into UserInfoes ([UserID], [Email], [UserName], IsEmployee) values (9226, '9226@kfh.com', 'Mahmoud Alha', 1)");
            migrationBuilder.Sql("insert into UserInfoes ([UserID], [Email], [UserName], IsEmployee) values (9227, '9227@kfh.com', 'Ali Alosaimi', 1)");
            migrationBuilder.Sql("insert into UserInfoes ([UserID], [Email], [UserName], IsEmployee) values (9225, '9225@kfh.com', 'Bader alj', 1)");

            migrationBuilder.Sql("insert into Committees (CommitteeTitle, ChairmanID, SecretaryID, CommitteeStartDate, CommitteeEndDate) values ('IT committee', 9227, 9226, '2020-02-01', '2022-04-01')");
            migrationBuilder.Sql("insert into Committees (CommitteeTitle, ChairmanID, SecretaryID, CommitteeStartDate, CommitteeEndDate) values ('Audit committee', 9225, 9227, '2020-03-04', '2022-12-11')");
            migrationBuilder.Sql("insert into Committees (CommitteeTitle, ChairmanID, SecretaryID, CommitteeStartDate, CommitteeEndDate) values ('HR committee', 9226, 9225, '2020-01-05', '2022-11-02')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from committees");
            migrationBuilder.Sql("delete from UserInfoes");
        }
    }
}
