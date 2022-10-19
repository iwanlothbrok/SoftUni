namespace Watchlist.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;
    using Watchlist.Data;
    using Watchlist.Extension;
    using Watchlist.Models.Movie;
    using Watchlist.Services.Movies;

    [Authorize]
    public class MoviesController : Controller
    {

        public IMovieService movieService;
        public WatchlistDbContext data;
        public MoviesController(IMovieService movieService, WatchlistDbContext data)
        {
            this.movieService = movieService;
            this.data = data;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new MovieFormModel
            {
                Genres = this.movieService.AllGenres()
            });
        }

        [HttpPost]
        public IActionResult Add(MovieFormModel movie)
        {
            var userId = User.GetId();

            if (movieService.GenreExist(movie.GenreId) == false)
            {
                ModelState.AddModelError(nameof(movie.GenreId), "Genre does not exist.");
            }

            if (ModelState.IsValid == false)
            {
                movie.Genres = this.movieService.AllGenres();

                return View(movie);
            }

            this.movieService.Create(movie.Title, movie.Director, movie.ImageUrl, movie.Rating, movie.GenreId);

            return View(nameof(All));

        }
        
        public IActionResult All()
        {
            var movies = movieService.All();

            if (movies.Movies.Count() == 0)
            {
                ModelState.AddModelError(nameof(movies), "There is no film with this criteria!");
            }
            return View(movies);
        }
        public async Task<IActionResult> Watched()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var model = await movieService.GetWatchedAsync(userId);

            return View("Mine", model);
        }
        public async Task<IActionResult> AddToCollection(int movieId)
        {
            try
            {
            var userId = User.GetId();

                await movieService.AddMovieToCollectionAsync(movieId, userId);
            }
            catch (Exception)
            {

                throw;
            }

            return View(nameof(All));
        }
    }
}
