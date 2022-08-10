using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LojaZoraide.Data.Migrations
{
    public partial class produtosFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClienteModelId",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_ClienteModelId",
                table: "Produtos",
                column: "ClienteModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Clientes_ClienteModelId",
                table: "Produtos",
                column: "ClienteModelId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Clientes_ClienteModelId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_ClienteModelId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "ClienteModelId",
                table: "Produtos");
        }
    }
}
