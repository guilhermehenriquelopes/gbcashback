using Microsoft.EntityFrameworkCore.Migrations;

namespace GBCashback.Migrations
{
    public partial class Add_RegraXCompra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "regraId",
                table: "Compras",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Compras_regraId",
                table: "Compras",
                column: "regraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Regras_regraId",
                table: "Compras",
                column: "regraId",
                principalTable: "Regras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Regras_regraId",
                table: "Compras");

            migrationBuilder.DropIndex(
                name: "IX_Compras_regraId",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "regraId",
                table: "Compras");
        }
    }
}
