using Microsoft.Extensions.DependencyInjection;
using Movies.Core.Application.Interfaces.Services;
using Movies.Core.Application.Services;

namespace Movies.Core.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddScoped<IMovieService, MovieService>();

            return services;
        }
    }
}
