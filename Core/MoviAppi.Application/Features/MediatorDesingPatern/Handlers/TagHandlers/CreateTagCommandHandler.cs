using MediatR;
using MoviAppi.Application.Features.MediatorDesingPatern.Commands.TagCommand;
using MovieApiPersistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviAppi.Application.Features.MediatorDesingPatern.Handlers.TagHandlers
{
    public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand>
    {
        private readonly MovieContext _context;

        public CreateTagCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            _context.Tags.Add(new MovieApi.Domain.Entities.Tag
            {
                Title = request.Title,
            });
            await _context.SaveChangesAsync();  
        }
    }
}
