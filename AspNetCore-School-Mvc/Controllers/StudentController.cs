using AspNetCore_School_Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AspNetCore_School_Mvc.Controllers
{
    public class StudentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StudentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Student(int id)
        {
            try
            {
                var http = _httpClientFactory.CreateClient();
                var response = await http.GetAsync("https://localhost:7092/api/Students/" + id);
                response.EnsureSuccessStatusCode();
                var jsonData = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<StudentViewModel>>(jsonData);
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
    }
}
