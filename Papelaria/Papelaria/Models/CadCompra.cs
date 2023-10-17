namespace Papelaria.Models
{
    public class CadCompra
    {
        public Guid CadCompraId { get; set; }
        public int NotaCompra { get; set; }
        public DateTime DataHora { get; set; }
        public Guid? FornecedorId { get; set; }
        public Fornecedor? Fornecedor { get; set; }
        public Guid? ProdutoId { get; set; }
        public Produto? Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
    }
}
