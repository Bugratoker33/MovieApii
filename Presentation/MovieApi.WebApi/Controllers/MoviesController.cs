using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviAppi.Application.Features.CQRSDesingPatern.Commands.MovieCommand;
using MoviAppi.Application.Features.CQRSDesingPatern.Handlers.MovieHandlers;
using MoviAppi.Application.Features.CQRSDesingPatern.Queries.MovieQueries;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly GetMovieByIdQueryHandler _getMovieByIdQueryHandler;
        private readonly GetMovieQueryHandler _getMovieQueryHandler;

        private readonly CreateMovieCommandHandeler _createMovieCommandHandeler;
        private readonly UpdateMovieCommandHnadler _updateMovieCommandHnadler;
        private readonly RemoveMovieCommandHandler _removeMovieCommandHandler;

        public MoviesController(GetMovieByIdQueryHandler getMovieByIdQueryHandler, GetMovieQueryHandler getMovieQueryHandler, CreateMovieCommandHandeler createMovieCommandHandeler, UpdateMovieCommandHnadler updateMovieCommandHnadler, RemoveMovieCommandHandler removeMovieCommandHandler)
        {
            _getMovieByIdQueryHandler = getMovieByIdQueryHandler;
            _getMovieQueryHandler = getMovieQueryHandler;
            _createMovieCommandHandeler = createMovieCommandHandeler;
            _updateMovieCommandHnadler = updateMovieCommandHnadler;
            _removeMovieCommandHandler = removeMovieCommandHandler;
        }



        [HttpGet]
        public async Task<IActionResult> MovieList()
        {
            var value = await _getMovieQueryHandler.Handle();
            return Ok(value);
        }
        [HttpPost]

        public async Task<IActionResult> CreateMovie(CreateMoviCommand command)
        {
            await _createMovieCommandHandeler.Handler(command);
            return Ok("film eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            await _removeMovieCommandHandler.Handle(new RemoveMovieCommand(id));
            return Ok("silndi");
        }
        [HttpGet("GetMovie")] 
        public async Task<IActionResult> GetMovie(int id)
        {
            var value = await _getMovieByIdQueryHandler.Handler(new GetMovieByIdQuery(id));
            return Ok(value);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateMovie(UpdateMovieCommand command)
        {
            await _updateMovieCommandHnadler.Handler(command);
            return Ok("Başarıyla güncelleştirildi");


        }
    }
}
