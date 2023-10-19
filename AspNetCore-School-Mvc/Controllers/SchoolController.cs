using AspNetCore_School_Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Reflection;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AspNetCore_School_Mvc.Controllers
{

    public class SchoolController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SchoolController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var http = _httpClientFactory.CreateClient();  //HttpClient döndürür
                var response = await http.GetAsync("https://localhost:7092/api/Schools");  //API adresi ve get isteği 
                response.EnsureSuccessStatusCode();
                var jsonData = await response.Content.ReadAsStringAsync();  //gelen datanın içindeki veriler çıkarılır
                var data = JsonConvert.DeserializeObject<List<SchoolViewModel>>(jsonData);  //gelen Json Tipindeki data view modele deserilize edilir
                return View(data);

            }
            catch (HttpRequestException)
            {
                return RedirectToAction("Login", "Account");
            }
            catch (Exception)
            {

                return RedirectToAction("Login", "Account");
            }

        }

     
        [HttpGet]
        public IActionResult CreateSchool()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSchool(SchoolViewModel model)
        {
            try
            {
                var jsonData = JsonConvert.SerializeObject(model);
                var http = _httpClientFactory.CreateClient();
                var content = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
                var response = await http.PostAsync("https://localhost:7092/api/Schools", content);
                response.EnsureSuccessStatusCode();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);

            }
  
        }
        [HttpGet]
        public async Task<IActionResult> EditSchool(int id)
        {
            try
            {
                var http = _httpClientFactory.CreateClient();
                var response = await http.GetAsync("https://localhost:7092/api/Schools/" + id);
                response.EnsureSuccessStatusCode();
                var jsonData = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<SchoolViewModel>(jsonData);
                return View(data);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(new SchoolViewModel());
            }
        
        }
        [HttpPost]
        public async Task<IActionResult> EditSchool(SchoolViewModel model)
        {
            try
            {
                var jsonData=JsonConvert.SerializeObject(model);
                var http = _httpClientFactory.CreateClient();
                var content = new StringContent(jsonData,encoding:Encoding.UTF8,"application/json");
                var response = await http.PutAsync("https://localhost:7092/api/Schools", content);
                response.EnsureSuccessStatusCode();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }
        [HttpGet]
        public async Task<IActionResult> DeleteSchool(int id)
        {
            try
            {
                var http = _httpClientFactory.CreateClient();
                var response = await http.DeleteAsync("https://localhost:7092/api/Schools/" + id);
                response.EnsureSuccessStatusCode();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return RedirectToAction("Index");
            }
           

        }
    }
}



