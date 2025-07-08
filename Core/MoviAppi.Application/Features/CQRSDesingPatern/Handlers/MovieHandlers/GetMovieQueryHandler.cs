using Microsoft.EntityFrameworkCore;
using MoviAppi.Application.Features.CQRSDesingPatern.Results.MovieResult;
using MovieApiPersistence.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviAppi.Application.Features.CQRSDesingPatern.Handlers.MovieHandlers
{
    public class GetMovieQueryHandler
    {
        private readonly MovieContext _context;

        public GetMovieQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<List<GetMovieQueryResult>> Handle()
        {
            var values = await _context.Movies.ToListAsync();
            return values.Select(x => new GetMovieQueryResult
            {
                MovieId = x.MovieId,
                CoverImageUrl = x.CoverImageUrl,
                CreatedYear = x.CreatedYear,
                Description = x.Description,
                Duration = x.Duration,
                Rating = x.Rating,
                ReleasDate = x.ReleasDate,
                Status = x.Status,
                Title = x.Title,
            }).ToList();

        }
    }
}
