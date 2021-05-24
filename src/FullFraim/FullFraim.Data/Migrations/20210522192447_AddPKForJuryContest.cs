using Microsoft.EntityFrameworkCore.Migrations;

namespace FullFraim.Data.Migrations
{
    public partial class AddPKForJuryContest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhotoReviews_JuryContests_JuryContestContestId_JuryContestUserId",
                table: "PhotoReviews");

            migrationBuilder.DropIndex(
                name: "IX_PhotoReviews_PhotoId",
                table: "PhotoReviews");

            migrationBuilder.DropIndex(
                name: "IX_PhotoReviews_JuryContestContestId_JuryContestUserId",
                table: "PhotoReviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JuryContests",
                table: "JuryContests");

            migrationBuilder.DropColumn(
                name: "JuryContestContestId",
                table: "PhotoReviews");

            migrationBuilder.DropColumn(
                name: "JuryContestUserId",
                table: "PhotoReviews");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "JuryContests",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JuryContests",
                table: "JuryContests",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "0c925893-c563-4137-bdf3-35932bd83f5f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "9e8aed99-1cd2-49a2-8dc1-c2d24a4694fd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "bc998671-e823-4f1e-8f63-735b9863faf9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "004f58e2-1918-44d9-8c0c-f90e69262eac");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "23845565-6646-4c90-8530-66d4659007be");

            migrationBuilder.CreateIndex(
                name: "IX_PhotoReviews_JuryContestId",
                table: "PhotoReviews",
                column: "JuryContestId");

            migrationBuilder.CreateIndex(
                name: "IX_PhotoReviews_PhotoId_JuryContestId",
                table: "PhotoReviews",
                columns: new[] { "PhotoId", "JuryContestId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JuryContests_ContestId_UserId",
                table: "JuryContests",
                columns: new[] { "ContestId", "UserId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoReviews_JuryContests_JuryContestId",
                table: "PhotoReviews",
                column: "JuryContestId",
                principalTable: "JuryContests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhotoReviews_JuryContests_JuryContestId",
                table: "PhotoReviews");

            migrationBuilder.DropIndex(
                name: "IX_PhotoReviews_JuryContestId",
                table: "PhotoReviews");

            migrationBuilder.DropIndex(
                name: "IX_PhotoReviews_PhotoId_JuryContestId",
                table: "PhotoReviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JuryContests",
                table: "JuryContests");

            migrationBuilder.DropIndex(
                name: "IX_JuryContests_ContestId_UserId",
                table: "JuryContests");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "JuryContests");

            migrationBuilder.AddColumn<int>(
                name: "JuryContestContestId",
                table: "PhotoReviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "JuryContestUserId",
                table: "PhotoReviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_JuryContests",
                table: "JuryContests",
                columns: new[] { "ContestId", "UserId" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "042d5f47-8caa-46ee-8a95-52a432beb76e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "a115cc00-039a-4923-a146-6d995a2ffa94");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "e0c9f138-8803-4387-85e8-1876895b53b1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "1f43dfc4-09a9-4995-8021-930ffd8049c2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "cafcaac6-bc87-4c29-96b4-9c754cba132e");

            migrationBuilder.CreateIndex(
                name: "IX_PhotoReviews_PhotoId",
                table: "PhotoReviews",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_PhotoReviews_JuryContestContestId_JuryContestUserId",
                table: "PhotoReviews",
                columns: new[] { "JuryContestContestId", "JuryContestUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoReviews_JuryContests_JuryContestContestId_JuryContestUserId",
                table: "PhotoReviews",
                columns: new[] { "JuryContestContestId", "JuryContestUserId" },
                principalTable: "JuryContests",
                principalColumns: new[] { "ContestId", "UserId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
