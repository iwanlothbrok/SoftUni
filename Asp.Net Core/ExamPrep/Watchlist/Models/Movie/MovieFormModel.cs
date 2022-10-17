namespace Watchlist.Models.Movie
{
    using Watchlist.Data.Models;

    public class MovieFormModel
    {
        public string Title { get; set; }

        public string Director { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public decimal Rating { get; set; }

        public List<MovieGenreModel>? Genres { get; set; }

        public int GenreId { get; set; }
    }
}
