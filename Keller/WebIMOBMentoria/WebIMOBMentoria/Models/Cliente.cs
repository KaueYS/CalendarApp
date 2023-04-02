namespace WebIMOBMentoria.Models
{
    public class Cliente
    {
        

        public int ClienteId { get; private set; }
        public string ClienteNome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public ICollection<Imovel> Imoveis { get; set;} = new List<Imovel>();
        
    }
}
