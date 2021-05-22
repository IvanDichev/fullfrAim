using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FullFraim.Data.Migrations
{
    public partial class AddStartDateToPhase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhaseEndDate",
                table: "ContestPhases");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "ContestPhases",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "ContestPhases",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "ContestPhases");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "ContestPhases");

            migrationBuilder.AddColumn<DateTime>(
                name: "PhaseEndDate",
                table: "ContestPhases",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "946e41ba-16b8-4ac8-97f3-aaeefbbe9d6f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "95154f89-7a62-4321-b195-b9e4fce9e264");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "a91fefc6-2c56-4fdd-a67b-c707362d7d03");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "7302f197-5bc8-4bdd-bfa3-a2fd76c9a327");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "785a522e-8349-46b2-b46c-af7fdf63fddd");
        }
    }
}
