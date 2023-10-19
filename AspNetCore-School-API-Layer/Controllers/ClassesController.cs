using AspNetCore_School_Entity_Layer.DTOs;
using AspNetCore_School_Entity_Layer.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore_School_API_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClassesController : ControllerBase
    {
        private readonly IClassService _classService;

        public ClassesController(IClassService classService)
        {
            _classService = classService;
        }
        //school id
        [HttpGet("{id}")]  
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _classService.GetAll(id));
        }
        [HttpPost]
        public IActionResult Get([FromBody] ClassDto model)
        {            
            return Created("",_classService.Add(model));
        }
        //[HttpGet("{id}")]
        //public IActionResult GetById(int id)
        //{
        //    return Ok(_classService.GetById(id));
        //}
    }
}
