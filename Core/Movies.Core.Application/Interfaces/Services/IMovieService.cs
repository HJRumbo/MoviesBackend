using Movies.Core.Application.Dtos;
using Movies.Core.Domain.Entities;

namespace Movies.Core.Application.Interfaces.Services
{
    public interface IMovieService
    {
        Task<List<MovieDto>> GetAllMovies();
        Task<MovieDto?> GetMovieById(int movieId);
    }
}
