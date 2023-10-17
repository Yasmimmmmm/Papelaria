﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Papelaria.Data;

#nullable disable

namespace Papelaria.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Papelaria.Models.CadCompra", b =>
                {
                    b.Property<Guid>("CadCompraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("FornecedorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("NotaCompra")
                        .HasColumnType("int");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("ProdutoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("CadCompraId");

                    b.HasIndex("FornecedorId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("tbCadCompras", (string)null);
                });

            modelBuilder.Entity("Papelaria.Models.CadVenda", b =>
                {
                    b.Property<Guid>("CadVendaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("datetime2");

                    b.Property<int>("NotaVenda")
                        .HasColumnType("int");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("ProdutoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("CadVendaId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("tbCadVendas", (string)null);
                });

            modelBuilder.Entity("Papelaria.Models.CategoriaProd", b =>
                {
                    b.Property<Guid>("CategoriaProdId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoriaProdName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoriaProdId");

                    b.ToTable("tbCategoriaProds", (string)null);
                });

            modelBuilder.Entity("Papelaria.Models.Cliente", b =>
                {
                    b.Property<Guid>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereço")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Nascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClienteId");

                    b.ToTable("tbCliente", (string)null);
                });

            modelBuilder.Entity("Papelaria.Models.Fornecedor", b =>
                {
                    b.Property<Guid>("FornecedorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FornecedorNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FornecedorId");

                    b.ToTable("tbFornecedor", (string)null);
                });

            modelBuilder.Entity("Papelaria.Models.Produto", b =>
                {
                    b.Property<Guid>("ProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CategoriaProdId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FornecedorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProdutoNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("ProdutoId");

                    b.HasIndex("CategoriaProdId");

                    b.HasIndex("FornecedorId");

                    b.ToTable("tbProdutos", (string)null);
                });

            modelBuilder.Entity("Papelaria.Models.CadCompra", b =>
                {
                    b.HasOne("Papelaria.Models.Fornecedor", "Fornecedor")
                        .WithMany()
                        .HasForeignKey("FornecedorId");

                    b.HasOne("Papelaria.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId");

                    b.Navigation("Fornecedor");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("Papelaria.Models.CadVenda", b =>
                {
                    b.HasOne("Papelaria.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.HasOne("Papelaria.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId");

                    b.Navigation("Cliente");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("Papelaria.Models.Produto", b =>
                {
                    b.HasOne("Papelaria.Models.CategoriaProd", "CategoriaProd")
                        .WithMany()
                        .HasForeignKey("CategoriaProdId");

                    b.HasOne("Papelaria.Models.Fornecedor", "Fornecedor")
                        .WithMany()
                        .HasForeignKey("FornecedorId");

                    b.Navigation("CategoriaProd");

                    b.Navigation("Fornecedor");
                });
#pragma warning restore 612, 618
        }
    }
}
