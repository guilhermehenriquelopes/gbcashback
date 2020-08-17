using Microsoft.EntityFrameworkCore.Migrations;

namespace GBCashback.Migrations
{
    public partial class Add_CPFIsUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Revendedores",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Revendedores",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Revendedores_CPF",
                table: "Revendedores",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Revendedores_Email",
                table: "Revendedores",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Revendedores_CPF",
                table: "Revendedores");

            migrationBuilder.DropIndex(
                name: "IX_Revendedores_Email",
                table: "Revendedores");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Revendedores",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Revendedores",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
