namespace Papelaria.Models
{
    public class Cliente
    {
        public Guid ClienteId { get; set; }
        public string Nome { get; set; }
        public string Endereço { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public DateTime Nascimento { get; set; }
    }
}
