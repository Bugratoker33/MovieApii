using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviAppi.Application.Features.MediatorDesingPatern.Commands.TagCommand;
using MoviAppi.Application.Features.MediatorDesingPatern.Queries.TagQueries;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task< IActionResult> TagLis()
        {

            var values = await _mediator.Send(new GetTagQuery());

            return Ok(values);

        }
        [HttpPost]
        public async Task<IActionResult> CreateTag(CreateTagCommand command)
        {

           await _mediator.Send(command);
            return Ok("Tag Başarıyla Eklendi");

        }

        [HttpGet("GetTag")]
        public async Task<IActionResult> GetTag(int id)
        {
            var value = await _mediator.Send(new GetTagByIdQuery(id));
            return Ok(value);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteTag(int id)
        {
           await _mediator.Send(new RemoveTagCommand(id));
            return Ok("Başarıyla silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTag(UpdateTagCommand command)
        {
          await  _mediator.Send(command);
            return Ok("Güncelenme tamamlandı");
        }




    }
}
