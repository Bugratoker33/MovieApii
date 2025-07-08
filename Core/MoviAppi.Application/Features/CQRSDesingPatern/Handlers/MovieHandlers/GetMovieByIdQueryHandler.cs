using MoviAppi.Application.Features.CQRSDesingPatern.Queries.MovieQueries;
using MoviAppi.Application.Features.CQRSDesingPatern.Results.MovieResult;
using MovieApiPersistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviAppi.Application.Features.CQRSDesingPatern.Handlers.MovieHandlers
{
    public class GetMovieByIdQueryHandler
    {
        private readonly MovieContext _context;

        public GetMovieByIdQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<GetMovieByIdQueryResult> Handler(GetMovieByIdQuery query)
        {
            var value = await _context.Movies.FindAsync(query.MovieId);
            return new GetMovieByIdQueryResult
            {
               
              CoverImageUrl=value.CoverImageUrl,
              CreatedYear=value.CreatedYear,
              Description=value.Description,
              Duration=value.Duration,
              Rating=value.Rating,
              ReleaseDate=value.ReleasDate,
              Status=value.Status,
              Title=value.Title,


            };
        }
    }

}
