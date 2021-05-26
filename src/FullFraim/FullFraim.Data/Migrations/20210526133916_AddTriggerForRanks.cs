using Microsoft.EntityFrameworkCore.Migrations;

namespace FullFraim.Data.Migrations
{
    public partial class AddTriggerForRanks : Migration
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

		}

		protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql(@"DROP TRIGGER TR_AspNetUsers_UpdateRanks_AU_AI");
		}
    }
}
