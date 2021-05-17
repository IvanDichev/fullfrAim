using Microsoft.EntityFrameworkCore.Migrations;

namespace FullFraim.Data.Migrations
{
    public partial class FixOneToOneRelationParticipantPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ParticipantContests_PhotoId",
                table: "ParticipantContests");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "ff3fb9e7-4c0f-482a-97db-e4ff922dede4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "8280e00f-461f-48f4-86c1-141d56806592");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "18d7c3ee-5cc0-40a6-a850-e83bdf8288bf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "6d7766f1-5d03-4320-96d3-4950233f0244");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "9a503fa8-4eb5-449d-b0b1-cb683850fb97");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantContests_PhotoId",
                table: "ParticipantContests",
                column: "PhotoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ParticipantContests_PhotoId",
                table: "ParticipantContests");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "afdc9bc9-8a43-4b80-946d-1fd661979a79");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "4f175d68-fccd-4b1b-b822-baf1f6c54bcc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "2ffb8ef8-2a72-4b44-a733-182eafe9db2e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "bfd22c87-58bc-4573-8698-76fa8c1aaeb6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "e33c6129-9ae1-451a-89fe-c187a1a69d1f");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantContests_PhotoId",
                table: "ParticipantContests",
                column: "PhotoId");
        }
    }
}
