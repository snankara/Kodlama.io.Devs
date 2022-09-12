using Application.Features.LanguageTechnologies.Commands.CreateLanguageTechnology;
using Application.Features.LanguageTechnologies.Commands.DeleteLanguageTechnology;
using Application.Features.LanguageTechnologies.Commands.UpdateLanguageTechnology;
using Application.Features.LanguageTechnologies.Dtos;
using Application.Features.LanguageTechnologies.Models;
using Application.Features.LanguageTechnologies.Queries.GetListLanguageTechnology;
using Application.Features.ProgrammingLanguages.Models;
using Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageTechnologiesController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateLanguageTechnologyCommand createLanguageTechnologyCommand)
        {
            CreatedLanguageTechnologyDto result = await Mediator.Send(createLanguageTechnologyCommand);
            return Created("", result);
        }

        [HttpPost("delete/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteLanguageTechnologyCommand deleteLanguageTechnologyCommand)
        {
            DeletedLanguageTechnologyDto result = await Mediator.Send(deleteLanguageTechnologyCommand);
            return Ok(result);
        }

        [HttpPatch("update")]
        public async Task<IActionResult> Update([FromBody] UpdateLanguageTechnologyCommand updateLanguageTechnologyCommand)
        {
            UpdatedLanguageTechnologyDto result = await Mediator.Send(updateLanguageTechnologyCommand);
            return Ok(result);
        }

        [HttpGet("getList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListLanguageTechnologyQuery getListLanguageTechnologyQuery = new() { PageRequest = pageRequest };
            LanguageTechnologyListModel languageTechnologyListModel = await Mediator.Send(getListLanguageTechnologyQuery);

            return Ok(languageTechnologyListModel);
        }

    }
}
