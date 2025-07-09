using MediatR;
using MoviAppi.Application.Features.MediatorDesingPatern.Commands.CastCommand;
using MovieApi.Domain.Entities;
using MovieApiPersistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviAppi.Application.Features.MediatorDesingPatern.Handlers.CastHandler
{
    //request                              //response 
    public class CreateCastComandHandler : IRequestHandler<CreateCastCommand>
    {
        private readonly MovieContext _context;

        public CreateCastComandHandler(MovieContext context)
        {
            _context = context;
        }


        public async Task Handle(CreateCastCommand request, CancellationToken cancellationToken)
        {
            _context.Casts.Add(new Cast
            {
                Biograpy = request.Biograpy,
                ImageUrl = request.ImageUrl,
                Name = request.Name,
                Overview = request.Overview,
                Surname = request.Surname,
                Title = request.Title,
            });
            await _context.SaveChangesAsync();


        }
    }
}

