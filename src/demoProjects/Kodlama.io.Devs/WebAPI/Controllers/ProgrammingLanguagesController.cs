using Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguagesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProgrammingLanguageCommand command)
        {
            CreatedProgrammingLanguageDto result = await MediatoR.Send(command);
            return Created("", result);
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            DeleteProgrammingLanguageCommand command = new() { Id = id };
            DeletedProgrammingLanguageDto result = await MediatoR.Send(command);
            return Ok(result);
        }
    }
}
