using Microsoft.EntityFrameworkCore.Migrations;

namespace DAO.Migrations
{
    public partial class SecondDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COMPETIDORES_Times_TimeID",
                table: "COMPETIDORES");

            migrationBuilder.DropForeignKey(
                name: "FK_JogoTime_JOGOS_JogoID",
                table: "JogoTime");

            migrationBuilder.DropForeignKey(
                name: "FK_JogoTime_Times_TimeID",
                table: "JogoTime");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Times",
                table: "Times");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JogoTime",
                table: "JogoTime");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "USUARIOS");

            migrationBuilder.RenameTable(
                name: "Times",
                newName: "TIMES");

            migrationBuilder.RenameTable(
                name: "JogoTime",
                newName: "JOGO_TIME");

            migrationBuilder.RenameIndex(
                name: "IX_Usuarios_Email",
                table: "USUARIOS",
                newName: "IX_USUARIOS_Email");

            migrationBuilder.RenameIndex(
                name: "IX_JogoTime_JogoID",
                table: "JOGO_TIME",
                newName: "IX_JOGO_TIME_JogoID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_USUARIOS",
                table: "USUARIOS",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TIMES",
                table: "TIMES",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JOGO_TIME",
                table: "JOGO_TIME",
                columns: new[] { "TimeID", "JogoID" });

            migrationBuilder.AddForeignKey(
                name: "FK_COMPETIDORES_TIMES_TimeID",
                table: "COMPETIDORES",
                column: "TimeID",
                principalTable: "TIMES",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JOGO_TIME_JOGOS_JogoID",
                table: "JOGO_TIME",
                column: "JogoID",
                principalTable: "JOGOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JOGO_TIME_TIMES_TimeID",
                table: "JOGO_TIME",
                column: "TimeID",
                principalTable: "TIMES",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COMPETIDORES_TIMES_TimeID",
                table: "COMPETIDORES");

            migrationBuilder.DropForeignKey(
                name: "FK_JOGO_TIME_JOGOS_JogoID",
                table: "JOGO_TIME");

            migrationBuilder.DropForeignKey(
                name: "FK_JOGO_TIME_TIMES_TimeID",
                table: "JOGO_TIME");

            migrationBuilder.DropPrimaryKey(
                name: "PK_USUARIOS",
                table: "USUARIOS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TIMES",
                table: "TIMES");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JOGO_TIME",
                table: "JOGO_TIME");

            migrationBuilder.RenameTable(
                name: "USUARIOS",
                newName: "Usuarios");

            migrationBuilder.RenameTable(
                name: "TIMES",
                newName: "Times");

            migrationBuilder.RenameTable(
                name: "JOGO_TIME",
                newName: "JogoTime");

            migrationBuilder.RenameIndex(
                name: "IX_USUARIOS_Email",
                table: "Usuarios",
                newName: "IX_Usuarios_Email");

            migrationBuilder.RenameIndex(
                name: "IX_JOGO_TIME_JogoID",
                table: "JogoTime",
                newName: "IX_JogoTime_JogoID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Times",
                table: "Times",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JogoTime",
                table: "JogoTime",
                columns: new[] { "TimeID", "JogoID" });

            migrationBuilder.AddForeignKey(
                name: "FK_COMPETIDORES_Times_TimeID",
                table: "COMPETIDORES",
                column: "TimeID",
                principalTable: "Times",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JogoTime_JOGOS_JogoID",
                table: "JogoTime",
                column: "JogoID",
                principalTable: "JOGOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JogoTime_Times_TimeID",
                table: "JogoTime",
                column: "TimeID",
                principalTable: "Times",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
