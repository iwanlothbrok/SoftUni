namespace Watchlist.Models.Movie
{
    public class MoviesServiceModel
    {
        public int  Id{ get; set; }
        public string Title { get; set; }

        public string Director { get; set; }


        public string ImageUrl { get; set; }

        public decimal Rating { get; set; }

        public string GenreName { get; set; }

    }
}
