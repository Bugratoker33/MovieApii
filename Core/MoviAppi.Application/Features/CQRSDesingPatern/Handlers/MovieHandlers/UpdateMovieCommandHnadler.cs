using MoviAppi.Application.Features.CQRSDesingPatern.Commands.MovieCommand;
using MovieApiPersistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MoviAppi.Application.Features.CQRSDesingPatern.Handlers.MovieHandlers
{
    public class UpdateMovieCommandHnadler
    {
        private readonly MovieContext _context;

        public UpdateMovieCommandHnadler(MovieContext context)
        {
            _context = context;
        }
        public async Task Handler(UpdateMovieCommand command)
        {
            var value = await _context.Movies.FindAsync(command.MovieId);
            value.Rating = command.Rating;
            value.Title = command.Title;
            value.Status = command.Status;
            value.Description = command.Description;
            value.Duration = command.Duration;
            value.CoverImageUrl = command.CoverImageUrl;
            value.CreatedYear = command.CreatedYear;
            value.ReleasDate = command.ReleasDate;

            await _context.SaveChangesAsync();
        }
    }
}
