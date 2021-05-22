using Microsoft.EntityFrameworkCore.Migrations;

namespace FullFraim.Data.Migrations
{
    public partial class FixJunctionTablesIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ContestPhases",
                table: "ContestPhases");

            migrationBuilder.DropIndex(
                name: "IX_ContestPhases_PhaseId",
                table: "ContestPhases");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ParticipantContests");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "JuryContests");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ContestPhases");

            migrationBuilder.AddColumn<string>(
                name: "Story",
                table: "Photos",
                maxLength: 2000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Photos",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContestPhases",
                table: "ContestPhases",
                columns: new[] { "PhaseId", "ContestId" });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ContestPhases",
                table: "ContestPhases");

            migrationBuilder.DropColumn(
                name: "Story",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Photos");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Photos",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ParticipantContests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "JuryContests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ContestPhases",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContestPhases",
                table: "ContestPhases",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "f9731bc3-2ae3-4ae8-b8bd-352a3d9b8838");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "6dffe131-0101-4073-b459-efd8a75f92f6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "87f79a4c-58d7-4d4f-90fb-4f9d8af23b68");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "e33c2c3d-6bdd-4f9d-8de5-bf8c87954956");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "13ed03e8-bbcf-4c0b-8ad0-873ed7460e05");

            migrationBuilder.CreateIndex(
                name: "IX_ContestPhases_PhaseId",
                table: "ContestPhases",
                column: "PhaseId");
        }
    }
}
