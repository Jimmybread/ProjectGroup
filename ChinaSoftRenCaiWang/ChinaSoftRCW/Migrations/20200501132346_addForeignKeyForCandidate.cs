using Microsoft.EntityFrameworkCore.Migrations;

namespace ChinaSoftRCW.Migrations
{
    public partial class addForeignKeyForCandidate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Candidates",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TechStackId",
                table: "Candidates",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TechStack",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TechName = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechStack", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_ProjectId",
                table: "Candidates",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_TechStackId",
                table: "Candidates",
                column: "TechStackId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_Project_ProjectId",
                table: "Candidates",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_TechStack_TechStackId",
                table: "Candidates",
                column: "TechStackId",
                principalTable: "TechStack",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_Project_ProjectId",
                table: "Candidates");

            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_TechStack_TechStackId",
                table: "Candidates");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "TechStack");

            migrationBuilder.DropIndex(
                name: "IX_Candidates_ProjectId",
                table: "Candidates");

            migrationBuilder.DropIndex(
                name: "IX_Candidates_TechStackId",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "TechStackId",
                table: "Candidates");
        }
    }
}
