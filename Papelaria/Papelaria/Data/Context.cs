using Microsoft.EntityFrameworkCore;
using Papelaria.Models;

namespace Papelaria.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<CategoriaProd> CategoriaProds { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<CadVenda> CadVendas { get; set; }
        public DbSet<CadCompra> CadCompras { get; set; }


        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Cliente>().ToTable("tbCliente");
            modelbuilder.Entity<Fornecedor>().ToTable("tbFornecedor");
            modelbuilder.Entity<CategoriaProd>().ToTable("tbCategoriaProds");
            modelbuilder.Entity<Produto>().ToTable("tbProdutos");
            modelbuilder.Entity<CadVenda>().ToTable("tbCadVendas");
            modelbuilder.Entity<CadCompra>().ToTable("tbCadCompras");
        }
    }
}
