using ImobiliariaMVC.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace ImobiliariaMVC.Controllers
{
    public class ImovelController : Controller
    {
        private readonly IHttpClientFactory _ihttpClientFactory;

        public ImovelController(IHttpClientFactory ihttpClientFactory)
        {
            _ihttpClientFactory = ihttpClientFactory;
        }



        public async Task<IActionResult> Index()
        {
            string uri = "https://localhost:7001/";
            string url = "api/Imovel/BuscarAPI";

            List<ImoveisCompativeisViewModel> consulta = new List<ImoveisCompativeisViewModel>();
            HttpClient httpClient = _ihttpClientFactory.CreateClient("Imoveis");

                httpClient.BaseAddress = new Uri(uri);
                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    string content = await httpResponseMessage.Content.ReadAsStringAsync();
                    consulta = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ImoveisCompativeisViewModel>>(content);
                }

            return View(consulta);


            //public async Task<IActionResult> Index()
            //{
            //    string uri = "https://localhost:7001/";
            //    string url = "api/Imovel/BuscarAPI";

            //    List<ImoveisCompativeisViewModel> consulta = new List<ImoveisCompativeisViewModel>();

            //    using (HttpClient httpClient = new HttpClient())
            //    {
            //        httpClient.BaseAddress = new Uri(uri);
            //        HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);
            //        if (httpResponseMessage.IsSuccessStatusCode)
            //        {
            //            string content = await httpResponseMessage.Content.ReadAsStringAsync();
            //            consulta = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ImoveisCompativeisViewModel>>(content);
            //        }
            //    }
            //    return View(consulta);
        
        }
    }
}

