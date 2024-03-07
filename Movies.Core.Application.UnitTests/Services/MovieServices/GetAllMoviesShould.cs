using Moq;
using Movies.Core.Application.Interfaces.Persistence;
using Movies.Core.Application.Interfaces.Services;
using Movies.Core.Application.Services;
using Movies.Core.Domain.Entities;

namespace Movies.Core.Application.UnitTests.Services.MovieServices
{
    public class GetAllMoviesShould
    {
        [Fact]
        public async Task ReturnData_When_ThereAreMovies()
        {
            //Arrange
            var movieRepositoryMock = new Mock<IMovieRepository>();

            IMovieService movieService = new MovieService(movieRepositoryMock.Object);

            var moviesMock = new List<Movie>()
            {
                new Movie()
                {
                    Id = 1,
                    Name = "Movie 1",
                    Description = "description 1",
                    CategoryId = 1,
                    Minutes = 120,
                    Rating = 5,
                    Category = new Category
                    {
                        Id = 1,
                        Name = "Acción",
                        Description = "Género Acción"
                    }
                },
                new Movie()
                {
                    Id = 2,
                    Name = "Movie 2",
                    Description = "description 2",
                    CategoryId = 1,
                    Minutes = 120,
                    Rating = 5,
                    Category = new Category
                    {
                        Id = 1,
                        Name = "Acción",
                        Description = "Género Acción"
                    }
                }
            };

            //Act

            movieRepositoryMock.Setup(r => r.GetAllMovies()).ReturnsAsync(moviesMock);

            var movies = await movieService.GetAllMovies();

            //Assert

            Assert.NotEmpty(movies.ToList());
            Assert.Equal("Movie 1", movies.FirstOrDefault()!.Name);
            Assert.Equal(2, movies.Count);
        }

        [Fact]
        public async Task ReturnEmptyList_When_ThereAreNotMovies()
        {
            //Arrange
            var movieRepositoryMock = new Mock<IMovieRepository>();

            IMovieService movieService = new MovieService(movieRepositoryMock.Object);

            var moviesMock = new List<Movie>();

            //Act
            movieRepositoryMock.Setup(r => r.GetAllMovies()).ReturnsAsync(moviesMock);

            var movies = await movieService.GetAllMovies();

            //Assert
            Assert.Empty(movies);
            Assert.True(movies.Count <= 0);
        }
    }
}
