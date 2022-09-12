using Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.Users.Commands.UserLogin;
using Application.Features.Users.Commands.UserRegister;
using Application.Features.Users.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("register")]
        public async Task<IActionResult> Add([FromBody] UserRegisterCommand userRegisterCommand)
        {
            UserRegisteredDto result = await Mediator.Send(userRegisterCommand);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Add([FromBody] UserLoginCommand userLoginCommand)
        {
            UserLoggedInDto result = await Mediator.Send(userLoginCommand);
            return Ok(result);
        }
    }
}
