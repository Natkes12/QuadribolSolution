using Microsoft.EntityFrameworkCore.Migrations;

namespace DAO.Migrations
{
    public partial class FourthDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeCompetidor_COMPETIDORES_CompetidorID",
                table: "TimeCompetidor");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeCompetidor_TIMES_TimeID",
                table: "TimeCompetidor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeCompetidor",
                table: "TimeCompetidor");

            migrationBuilder.RenameTable(
                name: "TimeCompetidor",
                newName: "TIME_COMPETIDOR");

            migrationBuilder.RenameIndex(
                name: "IX_TimeCompetidor_CompetidorID",
                table: "TIME_COMPETIDOR",
                newName: "IX_TIME_COMPETIDOR_CompetidorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TIME_COMPETIDOR",
                table: "TIME_COMPETIDOR",
                columns: new[] { "TimeID", "CompetidorID" });

            migrationBuilder.AddForeignKey(
                name: "FK_TIME_COMPETIDOR_COMPETIDORES_CompetidorID",
                table: "TIME_COMPETIDOR",
                column: "CompetidorID",
                principalTable: "COMPETIDORES",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TIME_COMPETIDOR_TIMES_TimeID",
                table: "TIME_COMPETIDOR",
                column: "TimeID",
                principalTable: "TIMES",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TIME_COMPETIDOR_COMPETIDORES_CompetidorID",
                table: "TIME_COMPETIDOR");

            migrationBuilder.DropForeignKey(
                name: "FK_TIME_COMPETIDOR_TIMES_TimeID",
                table: "TIME_COMPETIDOR");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TIME_COMPETIDOR",
                table: "TIME_COMPETIDOR");

            migrationBuilder.RenameTable(
                name: "TIME_COMPETIDOR",
                newName: "TimeCompetidor");

            migrationBuilder.RenameIndex(
                name: "IX_TIME_COMPETIDOR_CompetidorID",
                table: "TimeCompetidor",
                newName: "IX_TimeCompetidor_CompetidorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeCompetidor",
                table: "TimeCompetidor",
                columns: new[] { "TimeID", "CompetidorID" });

            migrationBuilder.AddForeignKey(
                name: "FK_TimeCompetidor_COMPETIDORES_CompetidorID",
                table: "TimeCompetidor",
                column: "CompetidorID",
                principalTable: "COMPETIDORES",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeCompetidor_TIMES_TimeID",
                table: "TimeCompetidor",
                column: "TimeID",
                principalTable: "TIMES",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
