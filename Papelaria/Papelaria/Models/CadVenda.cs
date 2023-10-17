namespace Papelaria.Models
{
    public class CadVenda
    {
        public Guid CadVendaId { get; set; }
        public int NotaVenda { get; set; }
        public DateTime DataHora { get; set; }
        public Guid? ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
        public Guid? ProdutoId { get; set; }
        public Produto? Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
    }
}
