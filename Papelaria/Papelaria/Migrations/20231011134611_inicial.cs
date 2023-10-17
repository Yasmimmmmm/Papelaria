using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Papelaria.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbCategoriaProds",
                columns: table => new
                {
                    CategoriaProdId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoriaProdName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCategoriaProds", x => x.CategoriaProdId);
                });

            migrationBuilder.CreateTable(
                name: "tbCliente",
                columns: table => new
                {
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereço = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nascimento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCliente", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "tbFornecedor",
                columns: table => new
                {
                    FornecedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FornecedorNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CNPJ = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbFornecedor", x => x.FornecedorId);
                });

            migrationBuilder.CreateTable(
                name: "tbProdutos",
                columns: table => new
                {
                    ProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProdutoNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoriaProdId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FornecedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbProdutos", x => x.ProdutoId);
                    table.ForeignKey(
                        name: "FK_tbProdutos_tbCategoriaProds_CategoriaProdId",
                        column: x => x.CategoriaProdId,
                        principalTable: "tbCategoriaProds",
                        principalColumn: "CategoriaProdId");
                    table.ForeignKey(
                        name: "FK_tbProdutos_tbFornecedor_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "tbFornecedor",
                        principalColumn: "FornecedorId");
                });

            migrationBuilder.CreateTable(
                name: "tbCadCompras",
                columns: table => new
                {
                    CadCompraId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NotaCompra = table.Column<int>(type: "int", nullable: false),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FornecedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCadCompras", x => x.CadCompraId);
                    table.ForeignKey(
                        name: "FK_tbCadCompras_tbFornecedor_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "tbFornecedor",
                        principalColumn: "FornecedorId");
                    table.ForeignKey(
                        name: "FK_tbCadCompras_tbProdutos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "tbProdutos",
                        principalColumn: "ProdutoId");
                });

            migrationBuilder.CreateTable(
                name: "tbCadVendas",
                columns: table => new
                {
                    CadVendaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NotaVenda = table.Column<int>(type: "int", nullable: false),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCadVendas", x => x.CadVendaId);
                    table.ForeignKey(
                        name: "FK_tbCadVendas_tbCliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "tbCliente",
                        principalColumn: "ClienteId");
                    table.ForeignKey(
                        name: "FK_tbCadVendas_tbProdutos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "tbProdutos",
                        principalColumn: "ProdutoId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbCadCompras_FornecedorId",
                table: "tbCadCompras",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_tbCadCompras_ProdutoId",
                table: "tbCadCompras",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_tbCadVendas_ClienteId",
                table: "tbCadVendas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_tbCadVendas_ProdutoId",
                table: "tbCadVendas",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_tbProdutos_CategoriaProdId",
                table: "tbProdutos",
                column: "CategoriaProdId");

            migrationBuilder.CreateIndex(
                name: "IX_tbProdutos_FornecedorId",
                table: "tbProdutos",
                column: "FornecedorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbCadCompras");

            migrationBuilder.DropTable(
                name: "tbCadVendas");

            migrationBuilder.DropTable(
                name: "tbCliente");

            migrationBuilder.DropTable(
                name: "tbProdutos");

            migrationBuilder.DropTable(
                name: "tbCategoriaProds");

            migrationBuilder.DropTable(
                name: "tbFornecedor");
        }
    }
}
