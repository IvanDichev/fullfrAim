using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FullFraim.Data.Migrations
{
    public partial class ChangeSeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "ContestPhases",
                keyColumns: new[] { "PhaseId", "ContestId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 6, 25, 11, 54, 33, 416, DateTimeKind.Utc).AddTicks(1451), new DateTime(2021, 5, 26, 11, 54, 33, 416, DateTimeKind.Utc).AddTicks(743) });

            migrationBuilder.UpdateData(
                table: "ContestPhases",
                keyColumns: new[] { "PhaseId", "ContestId" },
                keyValues: new object[] { 1, 2 },
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 5, 26, 11, 54, 33, 416, DateTimeKind.Utc).AddTicks(2243), new DateTime(2021, 4, 26, 11, 54, 33, 416, DateTimeKind.Utc).AddTicks(2241) });

            migrationBuilder.UpdateData(
                table: "ContestPhases",
                keyColumns: new[] { "PhaseId", "ContestId" },
                keyValues: new object[] { 1, 3 },
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 5, 25, 11, 54, 33, 416, DateTimeKind.Utc).AddTicks(2260), new DateTime(2021, 5, 24, 11, 54, 33, 416, DateTimeKind.Utc).AddTicks(2258) });

            migrationBuilder.UpdateData(
                table: "ContestPhases",
                keyColumns: new[] { "PhaseId", "ContestId" },
                keyValues: new object[] { 1, 4 },
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 6, 25, 11, 54, 33, 416, DateTimeKind.Utc).AddTicks(2273), new DateTime(2021, 5, 26, 11, 54, 33, 416, DateTimeKind.Utc).AddTicks(2271) });

            migrationBuilder.UpdateData(
                table: "ContestPhases",
                keyColumns: new[] { "PhaseId", "ContestId" },
                keyValues: new object[] { 2, 1 },
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 7, 25, 11, 54, 33, 416, DateTimeKind.Utc).AddTicks(2224), new DateTime(2021, 6, 25, 11, 54, 33, 416, DateTimeKind.Utc).AddTicks(2205) });

            migrationBuilder.UpdateData(
                table: "ContestPhases",
                keyColumns: new[] { "PhaseId", "ContestId" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 6, 25, 11, 54, 33, 416, DateTimeKind.Utc).AddTicks(2246), new DateTime(2021, 5, 26, 11, 54, 33, 416, DateTimeKind.Utc).AddTicks(2245) });

            migrationBuilder.UpdateData(
                table: "ContestPhases",
                keyColumns: new[] { "PhaseId", "ContestId" },
                keyValues: new object[] { 2, 3 },
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 5, 26, 11, 54, 33, 416, DateTimeKind.Utc).AddTicks(2264), new DateTime(2021, 5, 25, 11, 54, 33, 416, DateTimeKind.Utc).AddTicks(2262) });

            migrationBuilder.UpdateData(
                table: "ContestPhases",
                keyColumns: new[] { "PhaseId", "ContestId" },
                keyValues: new object[] { 2, 4 },
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 7, 25, 11, 54, 33, 416, DateTimeKind.Utc).AddTicks(2276), new DateTime(2021, 6, 25, 11, 54, 33, 416, DateTimeKind.Utc).AddTicks(2275) });

            migrationBuilder.UpdateData(
                table: "ContestPhases",
                keyColumns: new[] { "PhaseId", "ContestId" },
                keyValues: new object[] { 3, 1 },
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 11, 12, 11, 54, 33, 416, DateTimeKind.Utc).AddTicks(2239), new DateTime(2021, 7, 25, 11, 54, 33, 416, DateTimeKind.Utc).AddTicks(2237) });

            migrationBuilder.UpdateData(
                table: "ContestPhases",
                keyColumns: new[] { "PhaseId", "ContestId" },
                keyValues: new object[] { 3, 2 },
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 16, 11, 54, 33, 416, DateTimeKind.Utc).AddTicks(2256), new DateTime(2021, 6, 25, 11, 54, 33, 416, DateTimeKind.Utc).AddTicks(2254) });

            migrationBuilder.UpdateData(
                table: "ContestPhases",
                keyColumns: new[] { "PhaseId", "ContestId" },
                keyValues: new object[] { 3, 3 },
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 3, 22, 11, 54, 33, 416, DateTimeKind.Utc).AddTicks(2268), new DateTime(2021, 5, 26, 11, 54, 33, 416, DateTimeKind.Utc).AddTicks(2266) });

            migrationBuilder.UpdateData(
                table: "ContestPhases",
                keyColumns: new[] { "PhaseId", "ContestId" },
                keyValues: new object[] { 3, 4 },
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 3, 22, 11, 54, 33, 416, DateTimeKind.Utc).AddTicks(2280), new DateTime(2021, 7, 25, 11, 54, 33, 416, DateTimeKind.Utc).AddTicks(2279) });

            migrationBuilder.UpdateData(
                table: "Contests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 26, 11, 54, 33, 414, DateTimeKind.Utc).AddTicks(6029));

            migrationBuilder.UpdateData(
                table: "Contests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2021, 4, 26, 11, 54, 33, 414, DateTimeKind.Utc).AddTicks(7143));

            migrationBuilder.UpdateData(
                table: "Contests",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 24, 11, 54, 33, 414, DateTimeKind.Utc).AddTicks(7299));

            migrationBuilder.UpdateData(
                table: "Contests",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 26, 11, 54, 33, 414, DateTimeKind.Utc).AddTicks(7306));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "90afd873-e6fe-4623-9b67-0982fb892878", "Admin", "ADMIN" },
                    { 2, "3a230e9a-6d5a-43f6-a2d3-bc06a5c02f4e", "Organizer", "ORGANIZER" },
                    { 3, "cfa7636b-85bc-4e51-8ef9-e6ff721c8869", "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "ContestPhases",
                keyColumns: new[] { "PhaseId", "ContestId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 6, 24, 22, 13, 36, 548, DateTimeKind.Utc).AddTicks(1491), new DateTime(2021, 5, 25, 22, 13, 36, 548, DateTimeKind.Utc).AddTicks(106) });

            migrationBuilder.UpdateData(
                table: "ContestPhases",
                keyColumns: new[] { "PhaseId", "ContestId" },
                keyValues: new object[] { 1, 2 },
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 5, 25, 22, 13, 36, 548, DateTimeKind.Utc).AddTicks(3123), new DateTime(2021, 4, 25, 22, 13, 36, 548, DateTimeKind.Utc).AddTicks(3120) });

            migrationBuilder.UpdateData(
                table: "ContestPhases",
                keyColumns: new[] { "PhaseId", "ContestId" },
                keyValues: new object[] { 1, 3 },
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 5, 24, 22, 13, 36, 548, DateTimeKind.Utc).AddTicks(3150), new DateTime(2021, 5, 23, 22, 13, 36, 548, DateTimeKind.Utc).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "ContestPhases",
                keyColumns: new[] { "PhaseId", "ContestId" },
                keyValues: new object[] { 1, 4 },
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 6, 24, 22, 13, 36, 548, DateTimeKind.Utc).AddTicks(3173), new DateTime(2021, 5, 25, 22, 13, 36, 548, DateTimeKind.Utc).AddTicks(3170) });

            migrationBuilder.UpdateData(
                table: "ContestPhases",
                keyColumns: new[] { "PhaseId", "ContestId" },
                keyValues: new object[] { 2, 1 },
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 7, 24, 22, 13, 36, 548, DateTimeKind.Utc).AddTicks(3090), new DateTime(2021, 6, 24, 22, 13, 36, 548, DateTimeKind.Utc).AddTicks(3058) });

            migrationBuilder.UpdateData(
                table: "ContestPhases",
                keyColumns: new[] { "PhaseId", "ContestId" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 6, 24, 22, 13, 36, 548, DateTimeKind.Utc).AddTicks(3128), new DateTime(2021, 5, 25, 22, 13, 36, 548, DateTimeKind.Utc).AddTicks(3126) });

            migrationBuilder.UpdateData(
                table: "ContestPhases",
                keyColumns: new[] { "PhaseId", "ContestId" },
                keyValues: new object[] { 2, 3 },
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 5, 25, 22, 13, 36, 548, DateTimeKind.Utc).AddTicks(3156), new DateTime(2021, 5, 24, 22, 13, 36, 548, DateTimeKind.Utc).AddTicks(3154) });

            migrationBuilder.UpdateData(
                table: "ContestPhases",
                keyColumns: new[] { "PhaseId", "ContestId" },
                keyValues: new object[] { 2, 4 },
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 7, 24, 22, 13, 36, 548, DateTimeKind.Utc).AddTicks(3180), new DateTime(2021, 6, 24, 22, 13, 36, 548, DateTimeKind.Utc).AddTicks(3177) });

            migrationBuilder.UpdateData(
                table: "ContestPhases",
                keyColumns: new[] { "PhaseId", "ContestId" },
                keyValues: new object[] { 3, 1 },
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 11, 11, 22, 13, 36, 548, DateTimeKind.Utc).AddTicks(3116), new DateTime(2021, 7, 24, 22, 13, 36, 548, DateTimeKind.Utc).AddTicks(3113) });

            migrationBuilder.UpdateData(
                table: "ContestPhases",
                keyColumns: new[] { "PhaseId", "ContestId" },
                keyValues: new object[] { 3, 2 },
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 15, 22, 13, 36, 548, DateTimeKind.Utc).AddTicks(3143), new DateTime(2021, 6, 24, 22, 13, 36, 548, DateTimeKind.Utc).AddTicks(3141) });

            migrationBuilder.UpdateData(
                table: "ContestPhases",
                keyColumns: new[] { "PhaseId", "ContestId" },
                keyValues: new object[] { 3, 3 },
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 3, 21, 22, 13, 36, 548, DateTimeKind.Utc).AddTicks(3162), new DateTime(2021, 5, 25, 22, 13, 36, 548, DateTimeKind.Utc).AddTicks(3160) });

            migrationBuilder.UpdateData(
                table: "ContestPhases",
                keyColumns: new[] { "PhaseId", "ContestId" },
                keyValues: new object[] { 3, 4 },
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 3, 21, 22, 13, 36, 548, DateTimeKind.Utc).AddTicks(3186), new DateTime(2021, 7, 24, 22, 13, 36, 548, DateTimeKind.Utc).AddTicks(3184) });

            migrationBuilder.UpdateData(
                table: "Contests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 25, 22, 13, 36, 545, DateTimeKind.Utc).AddTicks(4237));

            migrationBuilder.UpdateData(
                table: "Contests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2021, 4, 25, 22, 13, 36, 545, DateTimeKind.Utc).AddTicks(5679));

            migrationBuilder.UpdateData(
                table: "Contests",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 23, 22, 13, 36, 545, DateTimeKind.Utc).AddTicks(5876));

            migrationBuilder.UpdateData(
                table: "Contests",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 25, 22, 13, 36, 545, DateTimeKind.Utc).AddTicks(5885));
        }
    }
}
