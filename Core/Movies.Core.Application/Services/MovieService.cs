using Movies.Core.Application.Dtos;
using Movies.Core.Application.Interfaces.Persistence;
using Movies.Core.Application.Interfaces.Services;

namespace Movies.Core.Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repository;

        public MovieService(IMovieRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<MovieDto>> GetAllMovies()
        {
            var movies = await _repository.GetAllMovies();

            var moviesDto = movies.Select(m => new MovieDto
            {
                Id = m.Id,
                Name = m.Name,
                Description = m.Description,
                Minutes = m.Minutes,
                Rating = m.Rating,
                Category = new CategoryDto
                {
                    Id = m.Category!.Id,
                    Name = m.Category.Name,
                    Description = m.Category.Description
                }
                
            }).ToList();

            return moviesDto;
        }

        public async Task<MovieDto?> GetMovieById(int movieId)
        {
            var movie = await _repository.GetMovieById(movieId);

            return movie != null ? new MovieDto
            {
                Id= movie.Id,
                Name = movie.Name,
                Description = movie.Description,
                Minutes = movie.Minutes,
                Rating = movie.Rating,
                Category = new CategoryDto
                {
                    Id = movie.Category!.Id,
                    Name = movie.Category.Name,
                    Description = movie.Category.Description
                }
            } : null;
        }
    }
}
