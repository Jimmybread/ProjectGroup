using Microsoft.EntityFrameworkCore.Migrations;

namespace ChinaSoftRCW.Migrations
{
    public partial class addjobstatedropdownlist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobState",
                table: "Candidates");

            migrationBuilder.AddColumn<int>(
                name: "JobStateId",
                table: "Candidates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "JobStates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobStates", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "JobStates",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "在职" });

            migrationBuilder.InsertData(
                table: "JobStates",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "已离职" });

            migrationBuilder.InsertData(
                table: "JobStates",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "观望" });

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_JobStateId",
                table: "Candidates",
                column: "JobStateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_JobStates_JobStateId",
                table: "Candidates",
                column: "JobStateId",
                principalTable: "JobStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_JobStates_JobStateId",
                table: "Candidates");

            migrationBuilder.DropTable(
                name: "JobStates");

            migrationBuilder.DropIndex(
                name: "IX_Candidates_JobStateId",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "JobStateId",
                table: "Candidates");

            migrationBuilder.AddColumn<string>(
                name: "JobState",
                table: "Candidates",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }
    }
}
