using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreMusic.Data.Migrations
{
  public partial class SeedMusicsAndArtistsTable : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder
            .Sql("INSERT INTO Artist (Name) Values ('Linkin Park')");
      migrationBuilder
            .Sql("INSERT INTO Artist (Name) Values ('Iron Maiden')");
      migrationBuilder
            .Sql("INSERT INTO Artist (Name) Values ('Flogging Molly')");
      migrationBuilder
            .Sql("INSERT INTO Artist (Name) Values ('Red Hot Chilli Peppers')");

      migrationBuilder
            .Sql("INSERT INTO Music (Name, ArtistId) Values ('In The End', (SELECT Id FROM Artist WHERE Name = 'Linkin Park'))");
      migrationBuilder
            .Sql("INSERT INTO Music (Name, ArtistId) Values ('Numb', (SELECT Id FROM Artist WHERE Name = 'Linkin Park'))");
      migrationBuilder
            .Sql("INSERT INTO Music (Name, ArtistId) Values ('Breaking The Habit', (SELECT Id FROM Artist WHERE Name = 'Linkin Park'))");
      migrationBuilder
            .Sql("INSERT INTO Music (Name, ArtistId) Values ('Fear of the dark', (SELECT Id FROM Artist WHERE Name = 'Iron Maiden'))");
      migrationBuilder
            .Sql("INSERT INTO Music (Name, ArtistId) Values ('Number of the beast', (SELECT Id FROM Artist WHERE Name = 'Iron Maiden'))");
      migrationBuilder
            .Sql("INSERT INTO Music (Name, ArtistId) Values ('The Trooper', (SELECT Id FROM Artist WHERE Name = 'Iron Maiden'))");
      migrationBuilder
            .Sql("INSERT INTO Music (Name, ArtistId) Values ('What''s left of the flag', (SELECT Id FROM Artist WHERE Name = 'Flogging Molly'))");
      migrationBuilder
            .Sql("INSERT INTO Music (Name, ArtistId) Values ('Drunken Lullabies', (SELECT Id FROM Artist WHERE Name = 'Flogging Molly'))");
      migrationBuilder
            .Sql("INSERT INTO Music (Name, ArtistId) Values ('If I Ever Leave this World Alive', (SELECT Id FROM Artist WHERE Name = 'Flogging Molly'))");
      migrationBuilder
            .Sql("INSERT INTO Music (Name, ArtistId) Values ('Californication', (SELECT Id FROM Artist WHERE Name = 'Red Hot Chilli Peppers'))");
      migrationBuilder
            .Sql("INSERT INTO Music (Name, ArtistId) Values ('Tell Me Baby', (SELECT Id FROM Artist WHERE Name = 'Red Hot Chilli Peppers'))");
      migrationBuilder
            .Sql("INSERT INTO Music (Name, ArtistId) Values ('Parallel Universe', (SELECT Id FROM Artist WHERE Name = 'Red Hot Chilli Peppers'))");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder
            .Sql("DELETE FROM Music");

      migrationBuilder
            .Sql("DELETE FROM Artist");
    }
  }
}
