using Movies.Core.Domain.Entities;

namespace Movies.Core.Application.Interfaces.Persistence
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetAllMovies();
        Task<Movie?> GetMovieById(int id);
    }
}
