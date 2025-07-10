using MediatR;
using Microsoft.EntityFrameworkCore;
using MoviAppi.Application.Features.MediatorDesingPatern.Queries.TagQueries;

using MoviAppi.Application.Features.MediatorDesingPatern.Result.TagResults;
using MovieApiPersistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviAppi.Application.Features.MediatorDesingPatern.Handlers.TagHandlers
{
    public class GetTagQueryHandler : IRequestHandler<GetTagQuery, List<GetTagQuertResult>>
    {
        private readonly MovieContext _context;

        public GetTagQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<List<GetTagQuertResult>> Handle(GetTagQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.Tags.ToListAsync();
            return values.Select(x => new GetTagQuertResult
            {
                TagId = x.TagId,
                Title= x.Title,
        
             
            }).ToList();
        }


    }
}
