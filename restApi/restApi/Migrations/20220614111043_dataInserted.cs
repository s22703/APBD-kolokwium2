using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace restApi.Migrations
{
    public partial class dataInserted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "IdAlbum", "AlbumName", "IdMusicLabel", "PublishDate" },
                values: new object[] { 2, "costamdwa", 2, new DateTime(2022, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Musicians",
                columns: new[] { "IdMusician", "FirstName", "LastName", "NickName" },
                values: new object[,]
                {
                    { 1, "Filip", "Wozniak", "filip123" },
                    { 2, "Patrycja", "Filipo", "patrycja123" }
                });

            migrationBuilder.InsertData(
                table: "MusicsLabels",
                columns: new[] { "IdMusicLabel", "Name" },
                values: new object[] { 1, "SBM" });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "IdAlbum", "AlbumName", "IdMusicLabel", "PublishDate" },
                values: new object[] { 1, "costam", 1, new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Tracks",
                columns: new[] { "IdTrack", "Duration", "IdMusicAlbum", "TrackName" },
                values: new object[] { 1, 3f, 1, "kawalek" });

            migrationBuilder.InsertData(
                table: "MusiciansTracks",
                columns: new[] { "IdMusician", "IdTrack" },
                values: new object[] { 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "IdAlbum",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Musicians",
                keyColumn: "IdMusician",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MusiciansTracks",
                keyColumns: new[] { "IdMusician", "IdTrack" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Musicians",
                keyColumn: "IdMusician",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tracks",
                keyColumn: "IdTrack",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "IdAlbum",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MusicsLabels",
                keyColumn: "IdMusicLabel",
                keyValue: 1);
        }
    }
}
