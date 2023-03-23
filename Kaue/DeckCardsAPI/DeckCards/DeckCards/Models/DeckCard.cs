using Newtonsoft.Json;

namespace DeckCards.Models
{
    public class DeckCard
    {
        [JsonProperty("deck_id")]
        public string DeckId { get; set; }
        public int Remaining { get; set; }
        public List<Card> Cards { get; set;}
    }
}
