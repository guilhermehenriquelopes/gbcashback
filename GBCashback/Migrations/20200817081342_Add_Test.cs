using Microsoft.EntityFrameworkCore.Migrations;

namespace GBCashback.Migrations
{
    public partial class Add_Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Regras_regraId",
                table: "Compras");

            migrationBuilder.RenameColumn(
                name: "regraId",
                table: "Compras",
                newName: "RegraId");

            migrationBuilder.RenameIndex(
                name: "IX_Compras_regraId",
                table: "Compras",
                newName: "IX_Compras_RegraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Regras_RegraId",
                table: "Compras",
                column: "RegraId",
                principalTable: "Regras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Regras_RegraId",
                table: "Compras");

            migrationBuilder.RenameColumn(
                name: "RegraId",
                table: "Compras",
                newName: "regraId");

            migrationBuilder.RenameIndex(
                name: "IX_Compras_RegraId",
                table: "Compras",
                newName: "IX_Compras_regraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Regras_regraId",
                table: "Compras",
                column: "regraId",
                principalTable: "Regras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
