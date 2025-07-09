using MediatR;
using MoviAppi.Application.Features.MediatorDesingPatern.Commands.CastCommand;
using MovieApiPersistence.Context;

namespace MoviAppi.Application.Features.MediatorDesingPatern.Handlers.CastHandler
{
    public class UpdateCastCommandHandler : IRequestHandler<UpdateCastCommand>
    {

        private readonly MovieContext _context;

        public UpdateCastCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateCastCommand request, CancellationToken cancellationToken)
        {
            var values = await _context.Casts.FindAsync(request.CastId);
            values.Surname = request.Surname;
            values.Overview = request.Overview;
            values.Name = request.Name;
            values.ImageUrl = request.ImageUrl; 
            values.Title = request.Title;
            values.Biograpy = request.Biography;
          
            await _context.SaveChangesAsync();

        }
    }
}

