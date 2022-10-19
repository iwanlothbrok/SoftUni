namespace Watchlist.Services.Movies
{
    using Watchlist.Data.Models;
    using Watchlist.Models.Movie;

    public interface IMovieService
    {
        int Create(
             string title,
             string director,
             string imageUrl,
             decimal rating,
             int genreId
             );
        Task<IEnumerable<MoviesServiceModel>> GetWatchedAsync(string userId);
        Task AddMovieToCollectionAsync(int movieId, string userId);
        AllMoviesForm All();
        IEnumerable<MoviesServiceModel> GetMovies(IQueryable<Movie> movie);
        List<MovieGenreModel> AllGenres();

        bool GenreExist(int categoryId);
    }
}
