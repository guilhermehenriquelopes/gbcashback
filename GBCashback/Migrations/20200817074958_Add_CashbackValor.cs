using Microsoft.EntityFrameworkCore.Migrations;

namespace GBCashback.Migrations
{
    public partial class Add_CashbackValor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cashback",
                table: "Compras",
                newName: "CashbackValor");

            migrationBuilder.AddColumn<decimal>(
                name: "CashbackPorcentagem",
                table: "Compras",
                type: "decimal(3,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CashbackPorcentagem",
                table: "Compras");

            migrationBuilder.RenameColumn(
                name: "CashbackValor",
                table: "Compras",
                newName: "Cashback");
        }
    }
}
