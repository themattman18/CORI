using Microsoft.EntityFrameworkCore.Migrations;

namespace CORI.Data.Migrations
{
    public partial class Testingmigrationdeletion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SurveyResults_Questions_QuestionId1QuestionId",
                table: "SurveyResults");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyResults_Questions_QuestionId2QuestionId",
                table: "SurveyResults");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyResults_Questions_QuestionId3QuestionId",
                table: "SurveyResults");

            migrationBuilder.DropIndex(
                name: "IX_SurveyResults_QuestionId1QuestionId",
                table: "SurveyResults");

            migrationBuilder.DropIndex(
                name: "IX_SurveyResults_QuestionId2QuestionId",
                table: "SurveyResults");

            migrationBuilder.DropColumn(
                name: "QuestionId1QuestionId",
                table: "SurveyResults");

            migrationBuilder.DropColumn(
                name: "QuestionId2QuestionId",
                table: "SurveyResults");

            migrationBuilder.RenameColumn(
                name: "QuestionId3QuestionId",
                table: "SurveyResults",
                newName: "QuestionId1");

            migrationBuilder.RenameIndex(
                name: "IX_SurveyResults_QuestionId3QuestionId",
                table: "SurveyResults",
                newName: "IX_SurveyResults_QuestionId1");

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyResults_Questions_QuestionId1",
                table: "SurveyResults",
                column: "QuestionId1",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SurveyResults_Questions_QuestionId1",
                table: "SurveyResults");

            migrationBuilder.RenameColumn(
                name: "QuestionId1",
                table: "SurveyResults",
                newName: "QuestionId3QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_SurveyResults_QuestionId1",
                table: "SurveyResults",
                newName: "IX_SurveyResults_QuestionId3QuestionId");

            migrationBuilder.AddColumn<int>(
                name: "QuestionId1QuestionId",
                table: "SurveyResults",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuestionId2QuestionId",
                table: "SurveyResults",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SurveyResults_QuestionId1QuestionId",
                table: "SurveyResults",
                column: "QuestionId1QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyResults_QuestionId2QuestionId",
                table: "SurveyResults",
                column: "QuestionId2QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyResults_Questions_QuestionId1QuestionId",
                table: "SurveyResults",
                column: "QuestionId1QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyResults_Questions_QuestionId2QuestionId",
                table: "SurveyResults",
                column: "QuestionId2QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyResults_Questions_QuestionId3QuestionId",
                table: "SurveyResults",
                column: "QuestionId3QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
