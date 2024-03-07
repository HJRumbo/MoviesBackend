namespace Movies.Core.Domain.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Rating { get; set; }
        public int Minutes { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } = new();
    }
}
