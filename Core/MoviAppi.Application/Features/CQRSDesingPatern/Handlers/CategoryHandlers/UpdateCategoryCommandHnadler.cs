using MoviAppi.Application.Features.CQRSDesingPatern.Commands.CategoryCommand;
using MovieApi.Domain.Entities;
using MovieApiPersistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviAppi.Application.Features.CQRSDesingPatern.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHnadler
    {
        private readonly MovieContext _context;

        public UpdateCategoryCommandHnadler(MovieContext context)
        {
            _context = context;
        }
        public async Task Handler(UpdateCategoryCommand command)
        {
            var value = await _context.Categories.FindAsync(command.CategoryId);
            value.CategoryName = command.CategoryName;
            await _context.SaveChangesAsync();  
            
            
        }
    }
}
