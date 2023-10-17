using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Papelaria.Data;
using Papelaria.Models;

namespace Papelaria.Controllers
{
    public class RelatorioProdutoController : Controller
    {
        private readonly Context _context;

        public RelatorioProdutoController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var tbProdutos = _context.Produtos.Include(c => c.CategoriaProd);
            var tbCategorias = _context.CategoriaProds;

            List<RelatorioProduto> ListaProdutos = new List<RelatorioProduto>();

            foreach (var produto in tbProdutos)
            {
                var modelo = new RelatorioProduto();

                modelo.RelatorioProdutoId = Guid.NewGuid();
                modelo.Quanti = produto.Quantidade;
                modelo.ProdNome = produto.ProdutoNome;
                modelo.Preco = produto.Preco;
                modelo.CategoriaProdId = produto.CategoriaProdId;
                modelo.CategoriaProd = produto.CategoriaProd;


                ListaProdutos.Add(modelo);

            }

            return View(ListaProdutos);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string? inFiltroProd, string? inFiltroCat)
        {

            var tbProdutos = _context.Produtos.Include(c => c.CategoriaProd);
            var tbCategorias = _context.CategoriaProds;

            List<RelatorioProduto> ListaFiltro = new List<RelatorioProduto>();

            foreach (var produto in tbProdutos)
            {
                var modelo = new RelatorioProduto();

                modelo.RelatorioProdutoId = Guid.NewGuid();
                modelo.Quanti = produto.Quantidade;
                modelo.ProdNome = produto.ProdutoNome;
                modelo.Preco = produto.Preco;
                modelo.CategoriaProdId = produto.CategoriaProdId;
                modelo.CategoriaProd = produto.CategoriaProd;

                if (inFiltroProd != null)
                {
                    if (modelo.ProdNome.ToLower().Contains(inFiltroProd.ToLower()))
                    {
                        ListaFiltro.Add(modelo);
                    }
                }

                if (inFiltroCat != null)
                {
                    if (modelo.CategoriaProd.CategoriaProdName.ToLower().Contains(inFiltroCat.ToLower()))
                    {
                        ListaFiltro.Add(modelo);
                    }
                }

                if((inFiltroCat == null) && (inFiltroProd == null))
                {
                    ListaFiltro.Add(modelo);
                }
            }

            return View( ListaFiltro);

        }
    }
}