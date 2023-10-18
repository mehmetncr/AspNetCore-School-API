using AspNetCore_School_Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AspNetCore_School_Mvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AccountController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var jsonData = JsonConvert.SerializeObject(model);
            var http = _httpClientFactory.CreateClient();
            var content = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
            var result = await http.PostAsync("https://localhost:7092/api/Accounts", content);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Login");
            }
            else
            {
                ModelState.AddModelError("", result.IsSuccessStatusCode.ToString());
                
            }
            return View(model);

        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            return View();
        }
    }
}
