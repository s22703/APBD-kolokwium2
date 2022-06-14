using Microsoft.EntityFrameworkCore.Migrations;

namespace restApi.Migrations
{
    public partial class dataInserted3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MusicsLabels",
                columns: new[] { "IdMusicLabel", "Name" },
                values: new object[] { 2, "QQ" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MusicsLabels",
                keyColumn: "IdMusicLabel",
                keyValue: 2);
        }
    }
}
