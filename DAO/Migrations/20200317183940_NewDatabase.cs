using Microsoft.EntityFrameworkCore.Migrations;

namespace DAO.Migrations
{
    public partial class NewDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TIME_COMPETIDOR");

            migrationBuilder.AddColumn<int>(
                name: "TimeID",
                table: "COMPETIDORES",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "TIME_COMPETIDOR",
                columns: table => new
                {
                    TimeID = table.Column<int>(type: "int", nullable: false),
                    CompetidorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TIME_COMPETIDOR", x => new { x.TimeID, x.CompetidorID });
                    table.ForeignKey(
                        name: "FK_TIME_COMPETIDOR_COMPETIDORES_CompetidorID",
                        column: x => x.CompetidorID,
                        principalTable: "COMPETIDORES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TIME_COMPETIDOR_TIMES_TimeID",
                        column: x => x.TimeID,
                        principalTable: "TIMES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TIME_COMPETIDOR_CompetidorID",
                table: "TIME_COMPETIDOR",
                column: "CompetidorID");
        }
    }
}
