using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using MoviAppi.Application.Features.CQRSDesingPatern.Commands.CategoryCommand;
using MoviAppi.Application.Features.CQRSDesingPatern.Handlers.CategoryHandlers;
using MoviAppi.Application.Features.CQRSDesingPatern.Queries.CategoryQueries;

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
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreteCategoryCommand command)
        {
            await _createCategoryCommandHandler.Handle(command);
            return Ok("Kategory eklendi ");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _removeCategoryCommandHandler.Handle(new RemoveCategoryCommand(id));
            return Ok("silme başarılır");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            await _updateCategoryCommandHnadler.Handler(command);
            return Ok("Başarıyla günceleştiridli");

        }
        [HttpGet("GetCategory")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var value = await _categoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id));
            return Ok(value);
        }
    }
}
