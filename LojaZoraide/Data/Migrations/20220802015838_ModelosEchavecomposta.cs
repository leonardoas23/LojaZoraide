using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LojaZoraide.Data.Migrations
{
    public partial class ModelosEchavecomposta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Clientes_ClienteModelId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Produtos");

            migrationBuilder.RenameColumn(
                name: "ClienteModelId",
                table: "Produtos",
                newName: "CategoriaModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Produtos_ClienteModelId",
                table: "Produtos",
                newName: "IX_Produtos_CategoriaModelId");

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataVenda = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalVenda = table.Column<double>(type: "float", nullable: false),
                    ClienteModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendas_Clientes_ClienteModelId",
                        column: x => x.ClienteModelId,
                        principalTable: "Clientes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ItemVendas",
                columns: table => new
                {
                    ProdutoModelId = table.Column<int>(type: "int", nullable: false),
                    VendaModelId = table.Column<int>(type: "int", nullable: false),
                    MetodoPagamento = table.Column<int>(type: "int", nullable: false),
                    ValorProduto = table.Column<double>(type: "float", nullable: false),
                    Desconto = table.Column<double>(type: "float", nullable: false),
                    QuantidadeProduto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemVendas", x => new { x.VendaModelId, x.ProdutoModelId });
                    table.ForeignKey(
                        name: "FK_ItemVendas_Produtos_ProdutoModelId",
                        column: x => x.ProdutoModelId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemVendas_Vendas_VendaModelId",
                        column: x => x.VendaModelId,
                        principalTable: "Vendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemVendas_ProdutoModelId",
                table: "ItemVendas",
                column: "ProdutoModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_ClienteModelId",
                table: "Vendas",
                column: "ClienteModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Categorias_CategoriaModelId",
                table: "Produtos",
                column: "CategoriaModelId",
                principalTable: "Categorias",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Categorias_CategoriaModelId",
                table: "Produtos");

            migrationBuilder.DropTable(
                name: "ItemVendas");

            migrationBuilder.DropTable(
                name: "Vendas");

            migrationBuilder.RenameColumn(
                name: "CategoriaModelId",
                table: "Produtos",
                newName: "ClienteModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Produtos_CategoriaModelId",
                table: "Produtos",
                newName: "IX_Produtos_ClienteModelId");

            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Produtos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Clientes_ClienteModelId",
                table: "Produtos",
                column: "ClienteModelId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
