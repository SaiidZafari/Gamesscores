using Microsoft.EntityFrameworkCore.Migrations;

namespace Gamesscores.Migrations
{
    public partial class ChangeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Game",
                table: "Highscores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Fullname",
                table: "Highscores",
                type: "nvarchar(22)",
                maxLength: 22,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GameListId",
                table: "Highscores",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "gameLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Releaseyear = table.Column<int>(type: "int", nullable: false),
                    Gamename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gameLists", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Highscores_GameListId",
                table: "Highscores",
                column: "GameListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Highscores_gameLists_GameListId",
                table: "Highscores",
                column: "GameListId",
                principalTable: "gameLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Highscores_gameLists_GameListId",
                table: "Highscores");

            migrationBuilder.DropTable(
                name: "gameLists");

            migrationBuilder.DropIndex(
                name: "IX_Highscores_GameListId",
                table: "Highscores");

            migrationBuilder.DropColumn(
                name: "GameListId",
                table: "Highscores");

            migrationBuilder.AlterColumn<string>(
                name: "Game",
                table: "Highscores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Fullname",
                table: "Highscores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(22)",
                oldMaxLength: 22);
        }
    }
}
