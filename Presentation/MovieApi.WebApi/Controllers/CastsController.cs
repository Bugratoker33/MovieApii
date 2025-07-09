using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviAppi.Application.Features.MediatorDesingPatern.Commands.CastCommand;
using MoviAppi.Application.Features.MediatorDesingPatern.Queries.CastQueries;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CastsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CastsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult CastList()
        {
            var values = _mediator.Send(new GetCastQuery());
            return Ok(values);
        }
        [HttpPost ]
        
        public IActionResult CreatCast(CreateCastCommand command)
        {
            _mediator.Send(command);
            return Ok("Ekleme Başarılı");
        }
        [HttpDelete]
        public IActionResult DeleteCast(int id)
        {
            _mediator.Send(new RemoveCastCommand(id));
            return Ok("Silme baarılı ");
        }
        [HttpGet("GetCastById")]
        public IActionResult GetCastById(UpdateCastCommand command)
        {
            _mediator.Send(command);
            return Ok("Günceleme başarılı ");
        }
    
    
    }
    
}
