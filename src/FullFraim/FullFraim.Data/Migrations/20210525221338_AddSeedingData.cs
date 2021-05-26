﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FullFraim.Data.Migrations
{
    public partial class AddSeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "90afd873-e6fe-4623-9b67-0982fb892878");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "3a230e9a-6d5a-43f6-a2d3-bc06a5c02f4e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cfa7636b-85bc-4e51-8ef9-e6ff721c8869", "User", "USER" });

            migrationBuilder.UpdateData(
                table: "ContestCategories",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Boudoir");

            migrationBuilder.InsertData(
                table: "Contests",
                columns: new[] { "Id", "ContestCategoryId", "ContestTypeId", "Cover_Url", "CreatedOn", "DeletedOn", "Description", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, 12, 1, "https://res.cloudinary.com/fullfraim/image/upload/v1621963776/y37iclssc2ozv18fnioo.jpg", new DateTime(2021, 5, 25, 22, 13, 36, 545, DateTimeKind.Utc).AddTicks(4237), null, "PhaseOne", false, null, "WildlifePhaseOne" },
                    { 2, 12, 1, "https://res.cloudinary.com/fullfraim/image/upload/v1621963776/y37iclssc2ozv18fnioo.jpg", new DateTime(2021, 4, 25, 22, 13, 36, 545, DateTimeKind.Utc).AddTicks(5679), null, "PhaseTwo", false, null, "WildlifePhaseTwo" },
                    { 3, 12, 1, "https://res.cloudinary.com/fullfraim/image/upload/v1621963776/y37iclssc2ozv18fnioo.jpg", new DateTime(2021, 5, 23, 22, 13, 36, 545, DateTimeKind.Utc).AddTicks(5876), null, "PhaseThree", false, null, "WildlifePhaseThree" },
                    { 4, 10, 2, "https://res.cloudinary.com/fullfraim/image/upload/v1621962983/ska4ybfpaaioa4flg0bo.jpg", new DateTime(2021, 5, 25, 22, 13, 36, 545, DateTimeKind.Utc).AddTicks(5885), null, "Portrait contest - PhaseOne", false, null, "Portrait" }
                });

            migrationBuilder.InsertData(
                table: "Ranks",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Junkie" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Enthusiast" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Master" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Wise and Benevolent Photo Dictator" }
                });

            migrationBuilder.InsertData(
                table: "ContestPhases",
                columns: new[] { "PhaseId", "ContestId", "CreatedOn", "DeletedOn", "EndDate", "IsDeleted", "ModifiedOn", "StartDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 6, 24, 22, 13, 36, 548, DateTimeKind.Utc).AddTicks(1491), false, null, new DateTime(2021, 5, 25, 22, 13, 36, 548, DateTimeKind.Utc).AddTicks(106) },
                    { 2, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 5, 25, 22, 13, 36, 548, DateTimeKind.Utc).AddTicks(3156), false, null, new DateTime(2021, 5, 24, 22, 13, 36, 548, DateTimeKind.Utc).AddTicks(3154) },
                    { 1, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 5, 24, 22, 13, 36, 548, DateTimeKind.Utc).AddTicks(3150), false, null, new DateTime(2021, 5, 23, 22, 13, 36, 548, DateTimeKind.Utc).AddTicks(3148) },
                    { 3, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 1, 15, 22, 13, 36, 548, DateTimeKind.Utc).AddTicks(3143), false, null, new DateTime(2021, 6, 24, 22, 13, 36, 548, DateTimeKind.Utc).AddTicks(3141) },
                    { 3, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2022, 3, 21, 22, 13, 36, 548, DateTimeKind.Utc).AddTicks(3162), false, null, new DateTime(2021, 5, 25, 22, 13, 36, 548, DateTimeKind.Utc).AddTicks(3160) },
                    { 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 5, 25, 22, 13, 36, 548, DateTimeKind.Utc).AddTicks(3123), false, null, new DateTime(2021, 4, 25, 22, 13, 36, 548, DateTimeKind.Utc).AddTicks(3120) },
                    { 2, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 6, 24, 22, 13, 36, 548, DateTimeKind.Utc).AddTicks(3128), false, null, new DateTime(2021, 5, 25, 22, 13, 36, 548, DateTimeKind.Utc).AddTicks(3126) },
                    { 2, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 7, 24, 22, 13, 36, 548, DateTimeKind.Utc).AddTicks(3180), false, null, new DateTime(2021, 6, 24, 22, 13, 36, 548, DateTimeKind.Utc).AddTicks(3177) },
                    { 3, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2022, 3, 21, 22, 13, 36, 548, DateTimeKind.Utc).AddTicks(3186), false, null, new DateTime(2021, 7, 24, 22, 13, 36, 548, DateTimeKind.Utc).AddTicks(3184) },
                    { 3, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 11, 11, 22, 13, 36, 548, DateTimeKind.Utc).AddTicks(3116), false, null, new DateTime(2021, 7, 24, 22, 13, 36, 548, DateTimeKind.Utc).AddTicks(3113) },
                    { 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 7, 24, 22, 13, 36, 548, DateTimeKind.Utc).AddTicks(3090), false, null, new DateTime(2021, 6, 24, 22, 13, 36, 548, DateTimeKind.Utc).AddTicks(3058) },
                    { 1, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 6, 24, 22, 13, 36, 548, DateTimeKind.Utc).AddTicks(3173), false, null, new DateTime(2021, 5, 25, 22, 13, 36, 548, DateTimeKind.Utc).AddTicks(3170) }
                });

            migrationBuilder.InsertData(
                table: "JuryContests",
                columns: new[] { "Id", "ContestId", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 1 },
                    { 2, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 1 },
                    { 4, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 1 },
                    { 3, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "Id", "ContestId", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Story", "Title", "Url" },
                values: new object[,]
                {
                    { 16, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Not a long way, we can climb it", "I can climb it", "https://res.cloudinary.com/fullfraim/image/upload/v1621963134/kdgxq6iorhwjwpphlppn.jpg" },
                    { 15, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Subway fighters", "Fight in the night", "https://res.cloudinary.com/fullfraim/image/upload/v1621963121/lfmos6aoxpblo8b5cksr.jpg" },
                    { 14, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "On my way", "Bath time", "https://res.cloudinary.com/fullfraim/image/upload/v1621963016/voyi4dpg8wtoscgb07ut.png" },
                    { 13, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Looking down", "Squirrel", "https://res.cloudinary.com/fullfraim/image/upload/v1621962999/oq8rxujmom66tvv95jdp.jpg" },
                    { 11, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Hungry birds", "Can I have some?", "https://res.cloudinary.com/fullfraim/image/upload/v1621963145/r6hussj1vnw7etwjlwc1.jpg" },
                    { 10, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Not a long way, we can climb it", "I can climb it", "https://res.cloudinary.com/fullfraim/image/upload/v1621963134/kdgxq6iorhwjwpphlppn.jpg" },
                    { 9, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Subway fighters", "Fight in the night", "https://res.cloudinary.com/fullfraim/image/upload/v1621963121/lfmos6aoxpblo8b5cksr.jpg" },
                    { 4, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Not a long way, we can climb it", "I can climb it", "https://res.cloudinary.com/fullfraim/image/upload/v1621963134/kdgxq6iorhwjwpphlppn.jpg" },
                    { 3, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Subway fighters", "Fight in the night", "https://res.cloudinary.com/fullfraim/image/upload/v1621963121/lfmos6aoxpblo8b5cksr.jpg" },
                    { 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "On my way", "Bath time", "https://res.cloudinary.com/fullfraim/image/upload/v1621963016/voyi4dpg8wtoscgb07ut.png" },
                    { 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Looking down", "Squirrel", "https://res.cloudinary.com/fullfraim/image/upload/v1621962999/oq8rxujmom66tvv95jdp.jpg" },
                    { 12, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Got it!", "Git It!", "https://res.cloudinary.com/fullfraim/image/upload/v1621963217/rw0eyykyktcyb1ihqdkn.jpg" },
                    { 19, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Just a nice picture", "Smile", "https://res.cloudinary.com/fullfraim/image/upload/v1621962983/ska4ybfpaaioa4flg0bo.jpg" }
                });

            migrationBuilder.InsertData(
                table: "ParticipantContests",
                columns: new[] { "UserId", "ContestId", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "PhotoId" },
                values: new object[,]
                {
                    { 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 1 },
                    { 4, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 15 },
                    { 2, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 13 },
                    { 5, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 16 },
                    { 4, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 11 },
                    { 5, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 12 },
                    { 2, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 9 },
                    { 5, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 4 },
                    { 4, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 3 }
                });

            migrationBuilder.InsertData(
                table: "PhotoReviews",
                columns: new[] { "Id", "Checkbox", "Comment", "CreatedOn", "DeletedOn", "IsDeleted", "JuryContestId", "ModifiedOn", "PhotoId", "Score" },
                values: new object[,]
                {
                    { 1, false, "nice", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1, null, 9, 4L },
                    { 3, false, "nice", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1, null, 11, 6L },
                    { 4, false, "nice", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1, null, 12, 6L },
                    { 5, false, "nice", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1, null, 13, 8L },
                    { 6, false, "nice", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1, null, 14, 4L },
                    { 7, false, "nice", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1, null, 15, 8L },
                    { 2, false, "Extraordinary", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1, null, 10, 10L },
                    { 8, false, "nice", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1, null, 16, 5L }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContestPhases",
                keyColumns: new[] { "PhaseId", "ContestId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ContestPhases",
                keyColumns: new[] { "PhaseId", "ContestId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "ContestPhases",
                keyColumns: new[] { "PhaseId", "ContestId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "ContestPhases",
                keyColumns: new[] { "PhaseId", "ContestId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "ContestPhases",
                keyColumns: new[] { "PhaseId", "ContestId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "ContestPhases",
                keyColumns: new[] { "PhaseId", "ContestId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "ContestPhases",
                keyColumns: new[] { "PhaseId", "ContestId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "ContestPhases",
                keyColumns: new[] { "PhaseId", "ContestId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "ContestPhases",
                keyColumns: new[] { "PhaseId", "ContestId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "ContestPhases",
                keyColumns: new[] { "PhaseId", "ContestId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "ContestPhases",
                keyColumns: new[] { "PhaseId", "ContestId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "ContestPhases",
                keyColumns: new[] { "PhaseId", "ContestId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "JuryContests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "JuryContests",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "JuryContests",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ParticipantContests",
                keyColumns: new[] { "UserId", "ContestId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "ParticipantContests",
                keyColumns: new[] { "UserId", "ContestId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "ParticipantContests",
                keyColumns: new[] { "UserId", "ContestId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "ParticipantContests",
                keyColumns: new[] { "UserId", "ContestId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "ParticipantContests",
                keyColumns: new[] { "UserId", "ContestId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "ParticipantContests",
                keyColumns: new[] { "UserId", "ContestId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "ParticipantContests",
                keyColumns: new[] { "UserId", "ContestId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "ParticipantContests",
                keyColumns: new[] { "UserId", "ContestId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "ParticipantContests",
                keyColumns: new[] { "UserId", "ContestId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "PhotoReviews",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PhotoReviews",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PhotoReviews",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PhotoReviews",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PhotoReviews",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PhotoReviews",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PhotoReviews",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PhotoReviews",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Contests",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "JuryContests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Contests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Contests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Contests",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "8f311559-f7b2-4827-bdd0-bdd3e577dc62");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "b3a909f6-1050-42d5-bafe-f0a7fe77b33e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4104a2f2-3906-4bed-ab15-07191927ea57", "Jury", "JURY" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 4, "936b597e-760b-4ab5-aca7-26360b7bfacd", "Participant", "PARTICIPANT" },
                    { 5, "f0182390-a4ad-4b72-a5d9-9d11292fcdcb", "PhotoMaster", "PHOTOMASTER" }
                });

            migrationBuilder.UpdateData(
                table: "ContestCategories",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Nude");
        }
    }
}
