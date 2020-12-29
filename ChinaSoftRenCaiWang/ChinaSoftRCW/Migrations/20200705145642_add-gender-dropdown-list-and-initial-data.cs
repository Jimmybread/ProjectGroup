using Microsoft.EntityFrameworkCore.Migrations;

namespace ChinaSoftRCW.Migrations
{
    public partial class addgenderdropdownlistandinitialdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Candidates");

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "Candidates",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Gender",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "男" });

            migrationBuilder.InsertData(
                table: "Gender",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "女" });

            migrationBuilder.InsertData(
                table: "Gender",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "保密" });

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_GenderId",
                table: "Candidates",
                column: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_Gender_GenderId",
                table: "Candidates",
                column: "GenderId",
                principalTable: "Gender",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_Gender_GenderId",
                table: "Candidates");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropIndex(
                name: "IX_Candidates_GenderId",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "Candidates");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Candidates",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: true);
        }
    }
}
