using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviAppi.Application.Features.CQRSDesingPatern.Commands.CategoryCommand;
using MoviAppi.Application.Features.CQRSDesingPatern.Handlers.CategoryHandlers;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly GetCategoryQueryHandler _categoryQueryHandler;
        private readonly GetCategoryByIdQueryHandler _categoryByIdQueryHandler;
        private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
        private readonly UpdateCategoryCommandHnadler _updateCategoryCommandHnadler;
        private readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler;

        public CategoriesController(GetCategoryQueryHandler categoryQueryHandler, GetCategoryByIdQueryHandler categoryByIdQueryHandler, CreateCategoryCommandHandler createCategoryCommandHandler, UpdateCategoryCommandHnadler updateCategoryCommandHnadler, RemoveCategoryCommandHandler removeCategoryCommandHandler)
        {
            _categoryQueryHandler = categoryQueryHandler;
            _categoryByIdQueryHandler = categoryByIdQueryHandler;
            _createCategoryCommandHandler = createCategoryCommandHandler;
            _updateCategoryCommandHnadler = updateCategoryCommandHnadler;
            _removeCategoryCommandHandler = removeCategoryCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var value = await _categoryQueryHandler.Handler();
            return Ok(value);
        }
        //[HttpPost]
        //public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        //{
        //    await _createCategoryCommandHandler.Handle(command);
        //    return Ok("Kategory eklendi ");
        //}

    }
}
