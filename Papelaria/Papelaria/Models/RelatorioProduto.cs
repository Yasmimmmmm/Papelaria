namespace Papelaria.Models
{
    public class RelatorioProduto
    {
        public Guid RelatorioProdutoId { get; set; }
        public string ProdNome { get; set; }
        public int Quanti { get; set; }
        public Guid? CategoriaProdId { get; set; }
        public CategoriaProd? CategoriaProd { get; set; }
        public decimal Preco { get; set; }

    }
}
