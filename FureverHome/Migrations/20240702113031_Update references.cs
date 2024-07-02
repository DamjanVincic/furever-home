using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FureverHome.Migrations
{
    /// <inheritdoc />
    public partial class Updatereferences : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VolunteerVolunteerApplication_Users_YesVotesId1",
                table: "VolunteerVolunteerApplication");

            migrationBuilder.DropForeignKey(
                name: "FK_VolunteerVolunteerApplication_VolunteerApplications_YesVote~",
                table: "VolunteerVolunteerApplication");

            migrationBuilder.DropForeignKey(
                name: "FK_VolunteerVolunteerApplication1_Users_NoVotesId1",
                table: "VolunteerVolunteerApplication1");

            migrationBuilder.DropForeignKey(
                name: "FK_VolunteerVolunteerApplication1_VolunteerApplications_NoVote~",
                table: "VolunteerVolunteerApplication1");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VolunteerVolunteerApplication1",
                table: "VolunteerVolunteerApplication1");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VolunteerVolunteerApplication",
                table: "VolunteerVolunteerApplication");

            migrationBuilder.RenameTable(
                name: "VolunteerVolunteerApplication1",
                newName: "VolunteerApplicationNoVotes");

            migrationBuilder.RenameTable(
                name: "VolunteerVolunteerApplication",
                newName: "VolunteerApplicationYesVotes");

            migrationBuilder.RenameIndex(
                name: "IX_VolunteerVolunteerApplication1_NoVotesId1",
                table: "VolunteerApplicationNoVotes",
                newName: "IX_VolunteerApplicationNoVotes_NoVotesId1");

            migrationBuilder.RenameIndex(
                name: "IX_VolunteerVolunteerApplication_YesVotesId1",
                table: "VolunteerApplicationYesVotes",
                newName: "IX_VolunteerApplicationYesVotes_YesVotesId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VolunteerApplicationNoVotes",
                table: "VolunteerApplicationNoVotes",
                columns: new[] { "NoVotesId", "NoVotesId1" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_VolunteerApplicationYesVotes",
                table: "VolunteerApplicationYesVotes",
                columns: new[] { "YesVotesId", "YesVotesId1" });

            migrationBuilder.AddForeignKey(
                name: "FK_VolunteerApplicationNoVotes_Users_NoVotesId1",
                table: "VolunteerApplicationNoVotes",
                column: "NoVotesId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VolunteerApplicationNoVotes_VolunteerApplications_NoVotesId",
                table: "VolunteerApplicationNoVotes",
                column: "NoVotesId",
                principalTable: "VolunteerApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VolunteerApplicationYesVotes_Users_YesVotesId1",
                table: "VolunteerApplicationYesVotes",
                column: "YesVotesId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VolunteerApplicationYesVotes_VolunteerApplications_YesVotes~",
                table: "VolunteerApplicationYesVotes",
                column: "YesVotesId",
                principalTable: "VolunteerApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VolunteerApplicationNoVotes_Users_NoVotesId1",
                table: "VolunteerApplicationNoVotes");

            migrationBuilder.DropForeignKey(
                name: "FK_VolunteerApplicationNoVotes_VolunteerApplications_NoVotesId",
                table: "VolunteerApplicationNoVotes");

            migrationBuilder.DropForeignKey(
                name: "FK_VolunteerApplicationYesVotes_Users_YesVotesId1",
                table: "VolunteerApplicationYesVotes");

            migrationBuilder.DropForeignKey(
                name: "FK_VolunteerApplicationYesVotes_VolunteerApplications_YesVotes~",
                table: "VolunteerApplicationYesVotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VolunteerApplicationYesVotes",
                table: "VolunteerApplicationYesVotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VolunteerApplicationNoVotes",
                table: "VolunteerApplicationNoVotes");

            migrationBuilder.RenameTable(
                name: "VolunteerApplicationYesVotes",
                newName: "VolunteerVolunteerApplication");

            migrationBuilder.RenameTable(
                name: "VolunteerApplicationNoVotes",
                newName: "VolunteerVolunteerApplication1");

            migrationBuilder.RenameIndex(
                name: "IX_VolunteerApplicationYesVotes_YesVotesId1",
                table: "VolunteerVolunteerApplication",
                newName: "IX_VolunteerVolunteerApplication_YesVotesId1");

            migrationBuilder.RenameIndex(
                name: "IX_VolunteerApplicationNoVotes_NoVotesId1",
                table: "VolunteerVolunteerApplication1",
                newName: "IX_VolunteerVolunteerApplication1_NoVotesId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VolunteerVolunteerApplication",
                table: "VolunteerVolunteerApplication",
                columns: new[] { "YesVotesId", "YesVotesId1" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_VolunteerVolunteerApplication1",
                table: "VolunteerVolunteerApplication1",
                columns: new[] { "NoVotesId", "NoVotesId1" });

            migrationBuilder.AddForeignKey(
                name: "FK_VolunteerVolunteerApplication_Users_YesVotesId1",
                table: "VolunteerVolunteerApplication",
                column: "YesVotesId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VolunteerVolunteerApplication_VolunteerApplications_YesVote~",
                table: "VolunteerVolunteerApplication",
                column: "YesVotesId",
                principalTable: "VolunteerApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VolunteerVolunteerApplication1_Users_NoVotesId1",
                table: "VolunteerVolunteerApplication1",
                column: "NoVotesId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VolunteerVolunteerApplication1_VolunteerApplications_NoVote~",
                table: "VolunteerVolunteerApplication1",
                column: "NoVotesId",
                principalTable: "VolunteerApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
