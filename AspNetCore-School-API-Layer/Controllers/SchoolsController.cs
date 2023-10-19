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
    public class SchoolsController : ControllerBase
    {
        private readonly ISchoolService _schoolService;

        public SchoolsController(ISchoolService schoolService)
        {
            this._schoolService = schoolService;
        }

        [HttpGet]    
        public async Task<IActionResult> Get()
        {
            return Ok(await _schoolService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _schoolService.GetById(id));
        }
        [HttpPost]
        public IActionResult Get([FromBody] SchoolDto model)
        {
            
            return Created("",_schoolService.Add(model));
        }
        [HttpPut]
        public IActionResult GetPut([FromBody] SchoolDto model)
        {
           string msg= _schoolService.Update(model);
            if (msg=="Ok")
            {
                return Ok();
            }
            else
            {
                return BadRequest(msg);
            }
            
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            string msg = _schoolService.Delete(id);
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
