using MoviAppi.Application.Features.CQRSDesingPatern.Queries.CategoryQueries;
using MoviAppi.Application.Features.CQRSDesingPatern.Results.CategoryResult;
using MovieApiPersistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace MoviAppi.Application.Features.CQRSDesingPatern.Handlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler
    {
        private readonly MovieContext _context;

        public GetCategoryByIdQueryHandler(MovieContext movieContext)
        {
            _context = movieContext;
        }

        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery query)
        {
            var value = await _context.Categories.FindAsync(query.CategoryId);
            return new GetCategoryByIdQueryResult
            {
                CategoryId = query.CategoryId,
                CategoryName = value.CategoryName,
               
            };
        }
    }
}
