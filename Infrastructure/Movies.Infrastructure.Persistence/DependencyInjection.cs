using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Movies.Core.Application.Interfaces.Persistence;
using Movies.Infrastructure.Persistence.Contexts;
using Movies.Infrastructure.Persistence.Repositories;

namespace Movies.Infrastructure.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MoviesDbContext>(options => 
                    options.UseSqlServer(configuration.GetConnectionString("ConnectionString"))
                );

            services.AddScoped<IMovieRepository, MovieRepository>();

            return services;
        }
    }
}
