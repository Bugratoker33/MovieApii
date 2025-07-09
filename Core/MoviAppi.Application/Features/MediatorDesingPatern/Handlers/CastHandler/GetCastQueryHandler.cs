using MediatR;
using Microsoft.EntityFrameworkCore;
using MoviAppi.Application.Features.MediatorDesingPatern.Queries.CastQueries;
using MoviAppi.Application.Features.MediatorDesingPatern.Result.CastResult;
using MovieApiPersistence.Context;

namespace MoviAppi.Application.Features.MediatorDesingPatern.Handlers.CastHandler
{
    public class GetCastQueryHandler : IRequestHandler<GetCastQuery, List<GetCastQueryResult>>
    {
        private readonly MovieContext _context;

        public GetCastQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<List<GetCastQueryResult>> Handle(GetCastQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.Casts.ToListAsync();
            return values.Select(x => new GetCastQueryResult
            {
                CastId = x.CastId,
                Biograpy = x.Biograpy,
                ImageUrl = x.ImageUrl,
                Name = x.Name,
                Overview = x.Overview,
                Surname = x.Surname,
                Title = x.Title
            }).ToList();
        }
    }
}

