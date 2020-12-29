using Microsoft.EntityFrameworkCore.Migrations;

namespace ChinaSoftRCW.Migrations
{
    public partial class seedDataForProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "Id", "ProjectName" },
                values: new object[,]
                {
                    { 1, "Microsoft-BingFeedBack" },
                    { 2, "Microsoft-WrapStar" },
                    { 3, "Microsoft-Insider" },
                    { 4, "Microsoft-AD" },
                    { 5, "Microsoft-Azure" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
