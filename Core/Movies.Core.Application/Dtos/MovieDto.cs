using Movies.Core.Domain.Entities;

namespace Movies.Core.Application.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Rating { get; set; }
        public int Minutes { get; set; }
        public CategoryDto? Category { get; set; }
    }
}
