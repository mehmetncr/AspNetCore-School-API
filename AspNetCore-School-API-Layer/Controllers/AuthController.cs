using AspNetCore_School_Entity_Layer.DTOs;
using AspNetCore_School_Entity_Layer.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore_School_API_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AuthController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Get([FromBody] RegisterDto model) 
        {
             string msg =  await _accountService.RegisterAsync(model);
            return Created("",msg);

        }
        [HttpPost("Login")]
        public async Task<IActionResult> Get([FromBody] LoginDto model)
        {
            string msg = await _accountService.LoginAsync(model);
            if (msg=="not found" || msg== "wrong user")
            {
                return NotFound();
            }
            else
            {
                return Ok( msg);
            }

           

        }
    }
}
