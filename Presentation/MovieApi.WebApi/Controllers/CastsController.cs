﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviAppi.Application.Features.MediatorDesingPatern.Commands.CastCommand;
using MoviAppi.Application.Features.MediatorDesingPatern.Commands.TagCommand;
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
        public async Task< IActionResult> CastList()
        {
            var values = await _mediator.Send(new GetCastQuery());
            return Ok(values);
        }
        [HttpPost ]

        public async Task<IActionResult> CreatCast(CreateCastCommand command)
        {
           await _mediator.Send(command);
            return Ok("Ekleme Başarılı");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCast(int id)
        {
          await  _mediator.Send(new RemoveCastCommand(id));
            return Ok("Silme baarılı ");
        }
        [HttpGet("GetCastById")]
        public async Task<IActionResult> GetCastById(int id)
        {
            var value = _mediator.Send(new GetCastByIdQuery(id));
            return Ok(value);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCast(UpdateCastCommand command)
        {
            await _mediator.Send(command);
            return Ok("Güncelenme tamamlandı");
        }


    }
    
}
