using AspNetCore_School_Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace AspNetCore_School_Mvc.Controllers
{
    public class ClassController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ClassController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Class(int id)
        {
            try
            {
                var http = _httpClientFactory.CreateClient();
                var response = await http.GetAsync("https://localhost:7092/api/Classes/Get/" + id);

                response.EnsureSuccessStatusCode(); // Bu satır, başarılı yanıt durumlarını kontrol eder.

                var jsonData = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<ClassViewModel>>(jsonData);
                if (data.Count()>0)
                {
                    return View(data);
                }
                else
                {
                    List<ClassViewModel> model = new List<ClassViewModel>();

                    model.Add(new ClassViewModel() { SchoolId = id });
                    return View(model);

                }
                
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
        public IActionResult CreateClass(int id)
        {
            ClassViewModel model = new ClassViewModel()
            {
                SchoolId = id
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> CreateClass(ClassViewModel model)
        {
            try
            {
                model.Id = 0;
                var jsonData = JsonConvert.SerializeObject(model);
                var http = _httpClientFactory.CreateClient();
                var content = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
                var response = await http.PostAsync("https://localhost:7092/api/Classes/Get", content);
                response.EnsureSuccessStatusCode();
                return RedirectToAction("Class", new { id = model.SchoolId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
       
        }
        [HttpGet]
        public async Task<IActionResult> EditClass(int id)
        {
            try
            {
                var http = _httpClientFactory.CreateClient();
                var response = await http.GetAsync("https://localhost:7092/api/Classes/GetById/" + id);
                response.EnsureSuccessStatusCode();
                var jsonData = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<ClassViewModel>(jsonData);
                return View(data);
            }   
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }

           
            
        }
        [HttpPost]
        public async Task<IActionResult> EditClass(ClassViewModel model)
        {
            try
            {
                var jsonData = JsonConvert.SerializeObject(model);
                var http = _httpClientFactory.CreateClient();
                var content = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
                var response = await http.PutAsync("https://localhost:7092/api/Classes/GetUpdate", content);
                response.EnsureSuccessStatusCode();
                return RedirectToAction("Class", new { id = model.SchoolId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }



        }
        //[HttpGet]
        //public async Task<IActionResult> DeleteClass(int id)
        //{
        //    try
        //    {
        //        var http = _httpClientFactory.CreateClient();
        //        var response = await http.GetAsync("https://localhost:7092/api/Classes/" + id);
        //        response.EnsureSuccessStatusCode();
        //        return View(data);
        //    }
        //    catch (Exception ex)
        //    {
        //        ModelState.AddModelError("", ex.Message);
        //        return View();
        //    }



        //}
    }
}
