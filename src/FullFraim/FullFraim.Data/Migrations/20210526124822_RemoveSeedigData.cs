using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FullFraim.Data.Migrations
{
    public partial class RemoveSeedigData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContestCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ContestCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ContestCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ContestCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ContestCategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ContestCategories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ContestCategories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ContestCategories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ContestCategories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ContestCategories",
                keyColumn: "Id",
                keyValue: 11);

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
                table: "Phases",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Phases",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Phases",
                keyColumn: "Id",
                keyValue: 3);

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
                table: "ContestCategories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ContestTypes",
                keyColumn: "Id",
                keyValue: 2);

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

            migrationBuilder.DeleteData(
                table: "ContestCategories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ContestTypes",
                keyColumn: "Id",
                keyValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ContestCategories",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Abstract" },
                    { 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Wildlife" },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Portrait" },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Photojournalism" },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Boudoir" },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Natrue" },
                    { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Street" },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Fine Art" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Fashion/Beauty" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Conceptual" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Architecture" },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Landscapes" }
                });

            migrationBuilder.InsertData(
                table: "ContestTypes",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Open" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Invitational" }
                });

            migrationBuilder.InsertData(
                table: "Phases",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "PhaseI" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "PhaseII" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Finished" }
                });

            migrationBuilder.InsertData(
                table: "Ranks",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Master" },
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Junkie" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Enthusiast" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Wise and Benevolent Photo Dictator" }
                });

            migrationBuilder.InsertData(
                table: "Contests",
                columns: new[] { "Id", "ContestCategoryId", "ContestTypeId", "Cover_Url", "CreatedOn", "DeletedOn", "Description", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, 12, 1, "https://res.cloudinary.com/fullfraim/image/upload/v1621963776/y37iclssc2ozv18fnioo.jpg", new DateTime(2021, 5, 26, 12, 23, 25, 900, DateTimeKind.Utc).AddTicks(8482), null, "PhaseOne", false, null, "WildlifePhaseOne" },
                    { 2, 12, 1, "https://res.cloudinary.com/fullfraim/image/upload/v1621963776/y37iclssc2ozv18fnioo.jpg", new DateTime(2021, 4, 26, 12, 23, 25, 900, DateTimeKind.Utc).AddTicks(9226), null, "PhaseTwo", false, null, "WildlifePhaseTwo" },
                    { 3, 12, 1, "https://res.cloudinary.com/fullfraim/image/upload/v1621963776/y37iclssc2ozv18fnioo.jpg", new DateTime(2021, 5, 24, 12, 23, 25, 900, DateTimeKind.Utc).AddTicks(9354), null, "PhaseThree", false, null, "WildlifePhaseThree" },
                    { 4, 10, 2, "https://res.cloudinary.com/fullfraim/image/upload/v1621962983/ska4ybfpaaioa4flg0bo.jpg", new DateTime(2021, 5, 26, 12, 23, 25, 900, DateTimeKind.Utc).AddTicks(9359), null, "Portrait contest - PhaseOne", false, null, "Portrait" }
                });

            migrationBuilder.InsertData(
                table: "ContestPhases",
                columns: new[] { "PhaseId", "ContestId", "CreatedOn", "DeletedOn", "EndDate", "IsDeleted", "ModifiedOn", "StartDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 6, 25, 12, 23, 25, 901, DateTimeKind.Utc).AddTicks(9541), false, null, new DateTime(2021, 5, 26, 12, 23, 25, 901, DateTimeKind.Utc).AddTicks(8999) },
                    { 2, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 5, 26, 12, 23, 25, 902, DateTimeKind.Utc).AddTicks(313), false, null, new DateTime(2021, 5, 25, 12, 23, 25, 902, DateTimeKind.Utc).AddTicks(311) },
                    { 1, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 5, 25, 12, 23, 25, 902, DateTimeKind.Utc).AddTicks(249), false, null, new DateTime(2021, 5, 24, 12, 23, 25, 902, DateTimeKind.Utc).AddTicks(247) },
                    { 3, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 1, 16, 12, 23, 25, 902, DateTimeKind.Utc).AddTicks(246), false, null, new DateTime(2021, 6, 25, 12, 23, 25, 902, DateTimeKind.Utc).AddTicks(244) },
                    { 3, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2022, 3, 22, 12, 23, 25, 902, DateTimeKind.Utc).AddTicks(316), false, null, new DateTime(2021, 5, 26, 12, 23, 25, 902, DateTimeKind.Utc).AddTicks(315) },
                    { 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 5, 26, 12, 23, 25, 902, DateTimeKind.Utc).AddTicks(237), false, null, new DateTime(2021, 4, 26, 12, 23, 25, 902, DateTimeKind.Utc).AddTicks(235) },
                    { 2, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 6, 25, 12, 23, 25, 902, DateTimeKind.Utc).AddTicks(239), false, null, new DateTime(2021, 5, 26, 12, 23, 25, 902, DateTimeKind.Utc).AddTicks(238) },
                    { 2, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 7, 25, 12, 23, 25, 902, DateTimeKind.Utc).AddTicks(324), false, null, new DateTime(2021, 6, 25, 12, 23, 25, 902, DateTimeKind.Utc).AddTicks(323) },
                    { 3, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2022, 3, 22, 12, 23, 25, 902, DateTimeKind.Utc).AddTicks(327), false, null, new DateTime(2021, 7, 25, 12, 23, 25, 902, DateTimeKind.Utc).AddTicks(326) },
                    { 3, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 11, 12, 12, 23, 25, 902, DateTimeKind.Utc).AddTicks(233), false, null, new DateTime(2021, 7, 25, 12, 23, 25, 902, DateTimeKind.Utc).AddTicks(232) },
                    { 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 7, 25, 12, 23, 25, 902, DateTimeKind.Utc).AddTicks(220), false, null, new DateTime(2021, 6, 25, 12, 23, 25, 902, DateTimeKind.Utc).AddTicks(203) },
                    { 1, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 6, 25, 12, 23, 25, 902, DateTimeKind.Utc).AddTicks(321), false, null, new DateTime(2021, 5, 26, 12, 23, 25, 902, DateTimeKind.Utc).AddTicks(320) }
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
    }
}
