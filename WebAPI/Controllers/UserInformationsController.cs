using Application.Features.UserInformations.Commands.CreateUserInformation;
using Application.Features.UserInformations.Commands.DeleteUserInformation;
using Application.Features.UserInformations.Commands.UpdateUserInformation;
using Application.Features.UserInformations.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInformationsController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateUserInformationCommand createUserInformationCommand)
        {
            CreatedUserInformationDto result = await Mediator.Send(createUserInformationCommand);
            return Created("", result);
        }

        [HttpPatch("update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserInformationCommand updateUserInformationCommand)
        {
            UpdatedUserInformationDto result = await Mediator.Send(updateUserInformationCommand);
            return Ok(result);
        }

        [HttpPost("delete/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteUserInformationCommand deleteUserInformationCommand)
        {
            DeletedUserInformationDto result = await Mediator.Send(deleteUserInformationCommand);
            return Ok(result);
        }
    }
}
