using MoviAppi.Application.Features.CQRSDesingPatern.Commands.MovieCommand;
using MovieApi.Domain.Entities;
using MovieApiPersistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviAppi.Application.Features.CQRSDesingPatern.Handlers.MovieHandlers
{
    public class CreateMovieCommandHandeler
    {
        private readonly MovieContext _context;

        public CreateMovieCommandHandeler(MovieContext context)
        {
            _context = context;
        }

        public async Task Handler(CreateMoviCommand command)
        {
            _context.Movies.Add(new Movie
            {
                CoverImageUrl = command.CoverImageUrl,
                CreatedYear = command.CreatedYear,
                Description = command.Description,
                Duration = command.Duration,
                Rating = command.Rating,
                ReleasDate = command.ReleasDate,
                Status = command.Status,
                Title = command.Title,

            });
            await _context.SaveChangesAsync();
        }
    }
}
