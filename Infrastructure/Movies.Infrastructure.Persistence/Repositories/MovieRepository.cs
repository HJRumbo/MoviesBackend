using Microsoft.EntityFrameworkCore;
using Movies.Core.Application.Interfaces.Persistence;
using Movies.Core.Domain.Entities;
using Movies.Infrastructure.Persistence.Contexts;

namespace Movies.Infrastructure.Persistence.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MoviesDbContext _context;

        public MovieRepository(MoviesDbContext context) 
        {
            _context = context;
        }

        public async Task<List<Movie>> GetAllMovies()
        {
            return await _context.Movies.Include(m => m.Category).ToListAsync();
        }

        public async Task<Movie?> GetMovieById(int id)
        {
            var movie = await _context.Movies.Include(m => m.Category).FirstOrDefaultAsync(m => m.Id == id);

            return movie;
        }
    }
}
