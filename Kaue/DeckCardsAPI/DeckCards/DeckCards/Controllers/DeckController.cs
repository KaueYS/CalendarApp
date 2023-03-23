using DeckCards.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeckCards.Controllers;

[ApiController]
[Route("/api/[controller]/[action]")]
public class DeckController : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetCards()
    {
        string uri = "https://deckofcardsapi.com/";
        string url = "api/deck/new/shuffle/?deck_count=1";
        string urlDeckId = "api/deck/{0}/draw/?count={1}";


        using (HttpClient httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri(uri);
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string content = await httpResponseMessage.Content.ReadAsStringAsync();
                DeckCard deck = Newtonsoft.Json.JsonConvert.DeserializeObject<DeckCard>(content);

                urlDeckId = string.Format(urlDeckId, deck.DeckId, 2);

                httpResponseMessage = await httpClient.GetAsync(urlDeckId);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    content = await httpResponseMessage.Content.ReadAsStringAsync();
                    DeckCard deckCard = Newtonsoft.Json.JsonConvert.DeserializeObject<DeckCard>(content);
                }

            }
        }
        return Ok();
    }
}
