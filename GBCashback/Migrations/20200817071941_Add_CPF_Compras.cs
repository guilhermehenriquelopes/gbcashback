using Microsoft.EntityFrameworkCore.Migrations;

namespace GBCashback.Migrations
{
    public partial class Add_CPF_Compras : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Revendedores_revendedorId",
                table: "Compras");

            migrationBuilder.DropIndex(
                name: "IX_Compras_revendedorId",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "revendedorId",
                table: "Compras");

            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "Compras",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Cashback",
                table: "Compras",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CPF",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "Cashback",
                table: "Compras");

            migrationBuilder.AddColumn<long>(
                name: "revendedorId",
                table: "Compras",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Compras_revendedorId",
                table: "Compras",
                column: "revendedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Revendedores_revendedorId",
                table: "Compras",
                column: "revendedorId",
                principalTable: "Revendedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
