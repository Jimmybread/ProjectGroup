using Microsoft.EntityFrameworkCore.Migrations;

namespace ChinaSoftRCW.Migrations
{
    public partial class seedDataForTechStack : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TechStack",
                columns: new[] { "Id", "TechName" },
                values: new object[] { 1, "C#" });

            migrationBuilder.InsertData(
                table: "TechStack",
                columns: new[] { "Id", "TechName" },
                values: new object[] { 2, ".NET" });

            migrationBuilder.InsertData(
                table: "TechStack",
                columns: new[] { "Id", "TechName" },
                values: new object[] { 3, "Java" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TechStack",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TechStack",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TechStack",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
