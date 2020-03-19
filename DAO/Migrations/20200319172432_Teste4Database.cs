using Microsoft.EntityFrameworkCore.Migrations;

namespace DAO.Migrations
{
    public partial class Teste4Database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pontuacao",
                table: "JOGOS");

            migrationBuilder.AddColumn<int>(
                name: "PontuacaoTime1",
                table: "JOGOS",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PontuacaoTime2",
                table: "JOGOS",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PontuacaoTime1",
                table: "JOGOS");

            migrationBuilder.DropColumn(
                name: "PontuacaoTime2",
                table: "JOGOS");

            migrationBuilder.AddColumn<int>(
                name: "Pontuacao",
                table: "JOGOS",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
