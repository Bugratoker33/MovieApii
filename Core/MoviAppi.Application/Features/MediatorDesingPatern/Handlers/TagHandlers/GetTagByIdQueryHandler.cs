using MediatR;
using MoviAppi.Application.Features.MediatorDesingPatern.Queries.TagQueries;
using MoviAppi.Application.Features.MediatorDesingPatern.Result.CastResult;
using MoviAppi.Application.Features.MediatorDesingPatern.Result.TagResults;
using MovieApiPersistence.Context;

namespace MoviAppi.Application.Features.MediatorDesingPatern.Handlers.TagHandlers
{
    public class GetTagByIdQueryHandler : IRequestHandler<GetTagByIdQuery, GetTagByIdQueryResult>
    {
        private readonly MovieContext _context;

        public GetTagByIdQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<GetTagByIdQueryResult> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.Casts.FindAsync(request.TagId);
            return new GetTagByIdQueryResult
            {
               
                Title = values.Title,

            };
        }
    }
}
