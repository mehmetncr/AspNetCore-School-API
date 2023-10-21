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
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_classService.GetById(id));
        }
        [HttpPut]
        public IActionResult GetUpdate([FromBody] ClassDto model)
        {
            string msg = _classService.Update(model);
            if (msg == "Ok")
            {
                return Ok();
            }
            else
            {
                return BadRequest(msg);
            }
 
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            string msg =  _classService.Delete(id);
            if (msg=="Ok")
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
