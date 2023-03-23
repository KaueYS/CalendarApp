using System.Text.Json.Serialization;

namespace ImobiliariaAPI.Model
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string ClienteNome { get; set; }
        public string Celular { get; set;}
        public string Email { get; set; }

        [JsonIgnore]
        public List<Imovel> Imoveis { get; set;}

    }
}
