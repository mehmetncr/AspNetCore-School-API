using AspNetCore_School_Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace AspNetCore_School_Mvc.Controllers
{
  
    public class SchoolController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SchoolController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var http = _httpClientFactory.CreateClient();  //HttpClient döndürür
            var respons = await http.GetAsync("https://localhost:7092/api/Schools");  //API adresi ve get isteği 
            if (respons.StatusCode == System.Net.HttpStatusCode.OK)  //gelen sonuç Ok ise  kodu ise
            {
                var jsonData = await respons.Content.ReadAsStringAsync();  //gelen datanın içindeki veriler çıkarılır
                var data = JsonConvert.DeserializeObject<List<SchoolViewModel>>(jsonData);  //gelen Json Tipindeki data view modele deserilize edilir
                return View(data);
            }
            return View();
        }
    }
}
