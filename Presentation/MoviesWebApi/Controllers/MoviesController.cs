using Microsoft.AspNetCore.Mvc;
using Movies.Core.Application.Dtos;
using Movies.Core.Application.Interfaces.Services;

namespace MoviesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<List<MovieDto>> Get()
        {
            return await _movieService.GetAllMovies();
        }

        [HttpGet("{id}")]
        public async Task<MovieDto?> Get(int id)
        {
            return await _movieService.GetMovieById(id);
        }
    }
}
