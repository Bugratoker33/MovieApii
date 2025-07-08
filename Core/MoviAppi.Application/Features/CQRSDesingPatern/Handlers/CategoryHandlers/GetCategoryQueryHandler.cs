using Microsoft.EntityFrameworkCore;
using MoviAppi.Application.Features.CQRSDesingPatern.Results.CategoryResult;
using MovieApiPersistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviAppi.Application.Features.CQRSDesingPatern.Handlers.CategoryHandlers
{
    public class GetCategoryQueryHandler
    {
        private readonly MovieContext _context;

        public GetCategoryQueryHandler(MovieContext context)
        {
            _context = context;
        }
        public async Task<List<GetCategoryQueryResults>> Handler()
        {
            var values = await _context.Categories.ToListAsync();
            return values.Select(x => new GetCategoryQueryResults
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName,
            }).ToList();
        }
    }
}
