using Newtonsoft.Json;

namespace DeckCards.Models
{
    public class Card
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("image")]
        public Uri Image { get; set; }

        [JsonProperty("images")]
        public Images Images { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("suit")]
        public string Suit { get; set; }
    }
}
