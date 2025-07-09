using MediatR;
using MoviAppi.Application.Features.MediatorDesingPatern.Queries.CastQueries;
using MoviAppi.Application.Features.MediatorDesingPatern.Result.CastResult;
using MovieApiPersistence.Context;

namespace MoviAppi.Application.Features.MediatorDesingPatern.Handlers.CastHandler
{                                   //önce istek yapılacak yer sonra karşılık bulacağı yer 
    public class GetCastByIdQueryHandler : IRequestHandler<GetCastByIdQuery, GetCastByIdQueryResult>
    {
        private readonly MovieContext _context;

        public GetCastByIdQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<GetCastByIdQueryResult> Handle(GetCastByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.Casts.FindAsync(request.CastId);
            return new GetCastByIdQueryResult
            {
                Biograpy = values.Biograpy,
                CastId = values.CastId,
                ImageUrl = values.ImageUrl,
                Name = values.Name,
                Overview = values.Overview,
                Surname = values.Surname,
                Title = values.Title,

            };

        }
    }

}

