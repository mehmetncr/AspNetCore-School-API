using AspNetCore_School_Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

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
        public async Task<IActionResult> Student(int id) //classId
        {
            try
            {
                var http = _httpClientFactory.CreateClient();
                var response = await http.GetAsync("https://localhost:7092/api/Students/Get/" + id);
                response.EnsureSuccessStatusCode();
                var jsonData = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<StudentViewModel>>(jsonData);
               if (data.Count() > 0)
                {
                    return View(data);
                }
                else
                {
                    List<StudentViewModel> model = new List<StudentViewModel>();

                    model.Add(new StudentViewModel() { ClassId = id });
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
        public IActionResult CreateStudent(int id)
        {
            StudentViewModel model = new StudentViewModel();
            model.ClassId = id;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> CreateStudent(StudentViewModel model)
        {
            try
            {
                model.Id = 0;
                var jsonData = JsonConvert.SerializeObject(model);
                var http = _httpClientFactory.CreateClient();
                var content = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
                var response = await http.PostAsync("https://localhost:7092/api/Students/Get", content);
                response.EnsureSuccessStatusCode();
                return RedirectToAction("Student", new {id=model.ClassId});
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);

            }
        }
        [HttpGet]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {
                var http = _httpClientFactory.CreateClient();
                var response = await http.DeleteAsync("https://localhost:7092/api/Students/Delete/" + id);
                response.EnsureSuccessStatusCode();
                return RedirectToAction("Index", "School");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return RedirectToAction("Index", "School");
            }


        }
        [HttpGet]
        public async Task<IActionResult> EditStudent(int id)
        {
            try
            {
                var http = _httpClientFactory.CreateClient();
                var response = await http.GetAsync("https://localhost:7092/api/Students/GetById/" + id);
                response.EnsureSuccessStatusCode();
                var jsonData = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<StudentViewModel>(jsonData);
                return View(data);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View();
            }


        }
        [HttpPost]
        public async Task<IActionResult> EditStudent(StudentViewModel model)
        {
            try
            {
                var jsonData = JsonConvert.SerializeObject(model);
                var http = _httpClientFactory.CreateClient();
                var content = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
                var response = await http.PutAsync("https://localhost:7092/api/Students/Update", content);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Student", new { id = model.ClassId });
                }
                else
                {
                    ModelState.AddModelError("", response.ToString());
                    return View(model);
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View(model);
            }


        }
    }
}
