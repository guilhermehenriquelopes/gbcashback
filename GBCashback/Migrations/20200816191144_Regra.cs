using Microsoft.EntityFrameworkCore.Migrations;

namespace GBCashback.Migrations
{
    public partial class Regra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Regras",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValorInicial = table.Column<decimal>(nullable: false),
                    ValorFinal = table.Column<decimal>(nullable: false),
                    Porcentagem = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regras", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Regras");
        }
    }
}
