using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Module.DevFlow.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Repo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    RepoLink = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    GithubName = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RepoEntityUserEntity",
                columns: table => new
                {
                    RepoEntitiesId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserEntitiesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepoEntityUserEntity", x => new { x.RepoEntitiesId, x.UserEntitiesId });
                    table.ForeignKey(
                        name: "FK_RepoEntityUserEntity_Repo_RepoEntitiesId",
                        column: x => x.RepoEntitiesId,
                        principalTable: "Repo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RepoEntityUserEntity_User_UserEntitiesId",
                        column: x => x.UserEntitiesId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RepoEntityUserEntity_UserEntitiesId",
                table: "RepoEntityUserEntity",
                column: "UserEntitiesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RepoEntityUserEntity");

            migrationBuilder.DropTable(
                name: "Repo");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
