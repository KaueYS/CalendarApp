using Newtonsoft.Json;

namespace DeckCards.Models
{
    public class Images
    {
        [JsonProperty("svg")]
        public Uri Svg { get; set; }

        [JsonProperty("png")]
        public Uri Png { get; set; }
    }
}
