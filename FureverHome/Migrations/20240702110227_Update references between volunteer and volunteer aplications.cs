using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FureverHome.Migrations
{
    /// <inheritdoc />
    public partial class Updatereferencesbetweenvolunteerandvolunteeraplications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_AuthorId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_UserId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_VolunteerApplicationId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_VolunteerApplicationId1",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_AuthorId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_VolunteerApplicationId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_VolunteerApplicationId1",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "VolunteerApplicationId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "VolunteerApplicationId1",
                table: "Users");

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
                name: "VolunteerVolunteerApplication",
                columns: table => new
                {
                    YesVotesId = table.Column<int>(type: "integer", nullable: false),
                    YesVotesId1 = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VolunteerVolunteerApplication", x => new { x.YesVotesId, x.YesVotesId1 });
                    table.ForeignKey(
                        name: "FK_VolunteerVolunteerApplication_Users_YesVotesId1",
                        column: x => x.YesVotesId1,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VolunteerVolunteerApplication_VolunteerApplications_YesVote~",
                        column: x => x.YesVotesId,
                        principalTable: "VolunteerApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VolunteerVolunteerApplication1",
                columns: table => new
                {
                    NoVotesId = table.Column<int>(type: "integer", nullable: false),
                    NoVotesId1 = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VolunteerVolunteerApplication1", x => new { x.NoVotesId, x.NoVotesId1 });
                    table.ForeignKey(
                        name: "FK_VolunteerVolunteerApplication1_Users_NoVotesId1",
                        column: x => x.NoVotesId1,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VolunteerVolunteerApplication1_VolunteerApplications_NoVote~",
                        column: x => x.NoVotesId,
                        principalTable: "VolunteerApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VolunteerApplications_AuthorId",
                table: "VolunteerApplications",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteerApplications_UserId",
                table: "VolunteerApplications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteerVolunteerApplication_YesVotesId1",
                table: "VolunteerVolunteerApplication",
                column: "YesVotesId1");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteerVolunteerApplication1_NoVotesId1",
                table: "VolunteerVolunteerApplication1",
                column: "NoVotesId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VolunteerVolunteerApplication");

            migrationBuilder.DropTable(
                name: "VolunteerVolunteerApplication1");

            migrationBuilder.DropTable(
                name: "VolunteerApplications");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VolunteerApplicationId",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VolunteerApplicationId1",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_AuthorId",
                table: "Users",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserId",
                table: "Users",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_VolunteerApplicationId",
                table: "Users",
                column: "VolunteerApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_VolunteerApplicationId1",
                table: "Users",
                column: "VolunteerApplicationId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_AuthorId",
                table: "Users",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_UserId",
                table: "Users",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_VolunteerApplicationId",
                table: "Users",
                column: "VolunteerApplicationId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_VolunteerApplicationId1",
                table: "Users",
                column: "VolunteerApplicationId1",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
