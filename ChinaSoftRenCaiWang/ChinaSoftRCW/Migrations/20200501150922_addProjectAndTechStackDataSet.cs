using Microsoft.EntityFrameworkCore.Migrations;

namespace ChinaSoftRCW.Migrations
{
    public partial class addProjectAndTechStackDataSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_Project_ProjectId",
                table: "Candidates");

            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_TechStack_TechStackId",
                table: "Candidates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TechStack",
                table: "TechStack");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Project",
                table: "Project");

            migrationBuilder.RenameTable(
                name: "TechStack",
                newName: "TechStacks");

            migrationBuilder.RenameTable(
                name: "Project",
                newName: "Projects");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TechStacks",
                table: "TechStacks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projects",
                table: "Projects",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_Projects_ProjectId",
                table: "Candidates",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_TechStacks_TechStackId",
                table: "Candidates",
                column: "TechStackId",
                principalTable: "TechStacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_Projects_ProjectId",
                table: "Candidates");

            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_TechStacks_TechStackId",
                table: "Candidates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TechStacks",
                table: "TechStacks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projects",
                table: "Projects");

            migrationBuilder.RenameTable(
                name: "TechStacks",
                newName: "TechStack");

            migrationBuilder.RenameTable(
                name: "Projects",
                newName: "Project");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TechStack",
                table: "TechStack",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Project",
                table: "Project",
                column: "Id");

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
    }
}
