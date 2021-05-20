using Microsoft.EntityFrameworkCore.Migrations;

namespace FullFraim.Data.Migrations
{
    public partial class AddTriggersForRanks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"CREATE TRIGGER TR_AspNetUsers_UpdateRanks_AU_AI ON dbo.AspNetUsers AFTER INSERT,UPDATE AS
BEGIN
		DECLARE TrigTempUpdate_Cursor CURSOR FOR
			SELECT Id FROM Inserted

		Declare @Id int;

		OPEN TrigTempUpdate_Cursor;
		FETCH NEXT FROM TrigTempUpdate_Cursor INTO @Id

		WHILE @@FETCH_STATUS = 0
		BEGIN
		UPDATE AspNetUsers SET RankId = (
			CASE 
				WHEN (SELECT Points FROM AspNetUsers WHERE Id = @Id) > 1000
					THEN (SELECT Id FROM Ranks WHERE [Name] = 'Wise and Benevolent Photo Dictator')
				WHEN (SELECT Points FROM AspNetUsers WHERE Id = @Id) > 150
					THEN (SELECT Id FROM Ranks WHERE [Name] = 'Master')
				WHEN (SELECT Points FROM AspNetUsers WHERE Id = @Id) > 50
					THEN (SELECT Id FROM Ranks WHERE [Name] = 'Enthusiast')
				ELSE (SELECT Id FROM Ranks WHERE [Name] = 'Junkie')
			END)
			WHERE id = @Id

		FETCH NEXT FROM TrigTempUpdate_Cursor INTO @Id
		END;

		CLOSE TrigTempUpdate_Cursor;
		DEALLOCATE TrigTempUpdate_Cursor;  
END;");
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "bd799765-8b37-4eb0-8385-484e57c67885");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "ad082f03-182f-4eea-9a8a-c3615d578274");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "cc623741-27e9-484c-907e-40460c925d7b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "24978b2b-fac0-4c92-921a-949da6d4210e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "4454efa5-7b24-45af-b9a9-37be0993c4b3");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP TRIGGER TR_AspNetUsers_UpdateRanks_AU_AI");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "c72a4875-5597-4ead-ba12-44d3675aae2d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "05d15190-3bbb-4284-8dbb-aed581bd7636");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "e434da91-ab1c-465e-a8e8-9ec7c73e6db0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "da7515f0-3463-43ce-a177-ede0d4cacd6b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "bba475ce-9027-450d-b678-b4f1cad34652");
        }
    }
}
