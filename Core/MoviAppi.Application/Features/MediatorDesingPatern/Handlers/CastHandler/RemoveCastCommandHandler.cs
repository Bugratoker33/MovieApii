using MediatR;
using MoviAppi.Application.Features.MediatorDesingPatern.Commands.CastCommand;
using MovieApiPersistence.Context;

namespace MoviAppi.Application.Features.MediatorDesingPatern.Handlers.CastHandler
{
    public class RemoveCastCommandHandler : IRequestHandler<RemoveCastCommand>
    {

        private readonly MovieContext _context;

        public RemoveCastCommandHandler(MovieContext context)
        {
            _context = context;
        }


        public async Task Handle(RemoveCastCommand request, CancellationToken cancellationToken)
        {
            var values= await _context.Casts.FindAsync(request.CastId);
            _context.Casts.Remove(values);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}

