namespace Papelaria.Models
{
    public class Produto
    {
        public Guid ProdutoId { get; set; }
        public string ProdutoNome { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        public Guid? CategoriaProdId { get; set; }
        public CategoriaProd? CategoriaProd { get; set; }
        public Guid? FornecedorId { get; set; }
        public Fornecedor? Fornecedor { get; set; }
    }
}
