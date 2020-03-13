using Microsoft.EntityFrameworkCore.Migrations;

namespace DAO.Migrations
{
    public partial class ThirdDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COMPETIDORES_TIMES_TimeID",
                table: "COMPETIDORES");

            migrationBuilder.DropIndex(
                name: "IX_COMPETIDORES_TimeID",
                table: "COMPETIDORES");

            migrationBuilder.DropColumn(
                name: "TimeID",
                table: "COMPETIDORES");

            migrationBuilder.CreateTable(
                name: "TimeCompetidor",
                columns: table => new
                {
                    TimeID = table.Column<int>(nullable: false),
                    CompetidorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeCompetidor", x => new { x.TimeID, x.CompetidorID });
                    table.ForeignKey(
                        name: "FK_TimeCompetidor_COMPETIDORES_CompetidorID",
                        column: x => x.CompetidorID,
                        principalTable: "COMPETIDORES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeCompetidor_TIMES_TimeID",
                        column: x => x.TimeID,
                        principalTable: "TIMES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimeCompetidor_CompetidorID",
                table: "TimeCompetidor",
                column: "CompetidorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeCompetidor");

            migrationBuilder.AddColumn<int>(
                name: "TimeID",
                table: "COMPETIDORES",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_COMPETIDORES_TimeID",
                table: "COMPETIDORES",
                column: "TimeID");

            migrationBuilder.AddForeignKey(
                name: "FK_COMPETIDORES_TIMES_TimeID",
                table: "COMPETIDORES",
                column: "TimeID",
                principalTable: "TIMES",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
