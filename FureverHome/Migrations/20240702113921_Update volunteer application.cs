using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FureverHome.Migrations
{
    /// <inheritdoc />
    public partial class Updatevolunteerapplication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VolunteerApplicationNoVotes");

            migrationBuilder.DropTable(
                name: "VolunteerApplicationYesVotes");

            migrationBuilder.DropTable(
                name: "VolunteerApplications");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VolunteerApplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AuthorId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VolunteerApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VolunteerApplications_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VolunteerApplications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VolunteerApplicationNoVotes",
                columns: table => new
                {
                    NoVotesId = table.Column<int>(type: "integer", nullable: false),
                    NoVotesId1 = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VolunteerApplicationNoVotes", x => new { x.NoVotesId, x.NoVotesId1 });
                    table.ForeignKey(
                        name: "FK_VolunteerApplicationNoVotes_Users_NoVotesId1",
                        column: x => x.NoVotesId1,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VolunteerApplicationNoVotes_VolunteerApplications_NoVotesId",
                        column: x => x.NoVotesId,
                        principalTable: "VolunteerApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VolunteerApplicationYesVotes",
                columns: table => new
                {
                    YesVotesId = table.Column<int>(type: "integer", nullable: false),
                    YesVotesId1 = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VolunteerApplicationYesVotes", x => new { x.YesVotesId, x.YesVotesId1 });
                    table.ForeignKey(
                        name: "FK_VolunteerApplicationYesVotes_Users_YesVotesId1",
                        column: x => x.YesVotesId1,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VolunteerApplicationYesVotes_VolunteerApplications_YesVotes~",
                        column: x => x.YesVotesId,
                        principalTable: "VolunteerApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VolunteerApplicationNoVotes_NoVotesId1",
                table: "VolunteerApplicationNoVotes",
                column: "NoVotesId1");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteerApplications_AuthorId",
                table: "VolunteerApplications",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteerApplications_UserId",
                table: "VolunteerApplications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteerApplicationYesVotes_YesVotesId1",
                table: "VolunteerApplicationYesVotes",
                column: "YesVotesId1");
        }
    }
}
