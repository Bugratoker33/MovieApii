using MoviAppi.Application.Features.CQRSDesingPatern.Commands.CategoryCommand;
using MovieApiPersistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviAppi.Application.Features.CQRSDesingPatern.Handlers.CategoryHandlers
{
    public class RemoveCategoryCommandHandler
    {
        private readonly MovieContext _context;

        public RemoveCategoryCommandHandler(MovieContext movieContext)
        {
            _context = movieContext;
        }

        public async Task Hnadler(RemoveCategoryCommand command)
        {
            var value = await _context.Categories.FindAsync(command.CategoryId);
            _context.Categories.Remove(value);
            await _context.SaveChangesAsync();
        }
    }
}
