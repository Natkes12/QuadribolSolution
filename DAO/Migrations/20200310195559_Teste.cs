using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAO.Migrations
{
    public partial class Teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Narradores",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    EhAtivo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Narradores", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Times",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Casa = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Times", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true),
                    Permissao = table.Column<int>(nullable: false),
                    EhAtivo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Competidores",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Casa = table.Column<int>(nullable: false),
                    Escolaridade = table.Column<int>(nullable: false),
                    Funcao = table.Column<int>(nullable: false),
                    Disponivel = table.Column<bool>(nullable: false),
                    EhAtivo = table.Column<bool>(nullable: false),
                    TimeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competidores", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Competidores_Times_TimeID",
                        column: x => x.TimeID,
                        principalTable: "Times",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Jogos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time1ID = table.Column<int>(nullable: false),
                    Time2ID = table.Column<int>(nullable: false),
                    DataJogo = table.Column<DateTime>(nullable: false),
                    Pontuacao = table.Column<int>(nullable: false),
                    NarradorID = table.Column<int>(nullable: false),
                    Encerrado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Jogos_Narradores_NarradorID",
                        column: x => x.NarradorID,
                        principalTable: "Narradores",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jogos_Times_Time1ID",
                        column: x => x.Time1ID,
                        principalTable: "Times",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jogos_Times_Time2ID",
                        column: x => x.Time2ID,
                        principalTable: "Times",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Competidores_TimeID",
                table: "Competidores",
                column: "TimeID");

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_NarradorID",
                table: "Jogos",
                column: "NarradorID");

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_Time1ID",
                table: "Jogos",
                column: "Time1ID");

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_Time2ID",
                table: "Jogos",
                column: "Time2ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Competidores");

            migrationBuilder.DropTable(
                name: "Jogos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Narradores");

            migrationBuilder.DropTable(
                name: "Times");
        }
    }
}
