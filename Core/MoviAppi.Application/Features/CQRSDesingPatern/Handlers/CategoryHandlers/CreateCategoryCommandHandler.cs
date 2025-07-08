using MoviAppi.Application.Features.CQRSDesingPatern.Commands.CategoryCommand;
using MovieApi.Domain.Entities;
using MovieApiPersistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace MoviAppi.Application.Features.CQRSDesingPatern.Handlers.CategoryHandlers
{
    public class CreateCategoryCommandHandler
    {
        private readonly MovieContext _context;

        public CreateCategoryCommandHandler(MovieContext context)
        {
            _context = context;
        }
        public async Task Handle (CreteCategoryCommand commandd)
        {
            _context.Categories.Add(new Category
            { 
                  CategoryName = commandd.CategoryName
            });
            await _context.SaveChangesAsync();

        }
    }
}
