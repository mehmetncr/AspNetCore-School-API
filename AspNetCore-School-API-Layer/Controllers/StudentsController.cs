using AspNetCore_School_Entity_Layer.DTOs;
using AspNetCore_School_Entity_Layer.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore_School_API_Layer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)  //classId
        {
            return Ok(await _studentService.GetAll(id));
        }
        [HttpPost]
        public IActionResult Get([FromBody] StudentDto model)
        {
            return Created("", _studentService.Add(model));
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {           
            return Ok(_studentService.GetById(id));
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            string msg = _studentService.Delete(id);
            if (msg=="Ok")
            {
                return Ok();
            }
            else
            {
                return BadRequest(msg);
            }         

        }
        [HttpPut]
        public IActionResult Update([FromBody] StudentDto model)
        {
            string msg = _studentService.Update(model);
            if (msg=="Ok")
            {
                return Ok();
            }
            else
            {
                return BadRequest(msg);
            }
        }
    }
}
