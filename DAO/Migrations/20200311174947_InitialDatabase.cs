using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAO.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NARRADORES",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    EhAtivo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NARRADORES", x => x.ID);
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
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(type: "VARCHAR(15)", nullable: false),
                    Permissao = table.Column<int>(nullable: false),
                    EhAtivo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "JOGOS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataJogo = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    Pontuacao = table.Column<int>(nullable: false),
                    NarradorID = table.Column<int>(nullable: false),
                    Encerrado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JOGOS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_JOGOS_NARRADORES_NarradorID",
                        column: x => x.NarradorID,
                        principalTable: "NARRADORES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "COMPETIDORES",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Casa = table.Column<int>(nullable: false),
                    Escolaridade = table.Column<int>(nullable: false),
                    Funcao = table.Column<int>(nullable: false),
                    Disponivel = table.Column<bool>(nullable: false),
                    EhAtivo = table.Column<bool>(nullable: false),
                    TimeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMPETIDORES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_COMPETIDORES_Times_TimeID",
                        column: x => x.TimeID,
                        principalTable: "Times",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JogoTime",
                columns: table => new
                {
                    TimeID = table.Column<int>(nullable: false),
                    JogoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JogoTime", x => new { x.TimeID, x.JogoID });
                    table.ForeignKey(
                        name: "FK_JogoTime_JOGOS_JogoID",
                        column: x => x.JogoID,
                        principalTable: "JOGOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JogoTime_Times_TimeID",
                        column: x => x.TimeID,
                        principalTable: "Times",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_COMPETIDORES_TimeID",
                table: "COMPETIDORES",
                column: "TimeID");

            migrationBuilder.CreateIndex(
                name: "IX_JOGOS_DataJogo",
                table: "JOGOS",
                column: "DataJogo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JOGOS_NarradorID",
                table: "JOGOS",
                column: "NarradorID");

            migrationBuilder.CreateIndex(
                name: "IX_JogoTime_JogoID",
                table: "JogoTime",
                column: "JogoID");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "COMPETIDORES");

            migrationBuilder.DropTable(
                name: "JogoTime");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "JOGOS");

            migrationBuilder.DropTable(
                name: "Times");

            migrationBuilder.DropTable(
                name: "NARRADORES");
        }
    }
}
