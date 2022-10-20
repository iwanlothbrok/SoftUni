namespace Watchlist.Services.Movies
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Threading.Tasks;
    using Watchlist.Data;
    using Watchlist.Data.Models;
    using Watchlist.Models.Movie;

    public class MovieService : IMovieService
    {
        public WatchlistDbContext data;

        public MovieService(WatchlistDbContext dbContext)
        {
            this.data = dbContext;
        }

        public IEnumerable<MoviesServiceModel> All()
        {
            var carsQuery = this.data
                .Movies
                .Include(g => g.Genre)
                .ToList();




            return carsQuery.Select(c => new MoviesServiceModel()
            {
                Director = c.Director,
                GenreName = c.Genre.Name,
                ImageUrl = c.ImageUrl,
                Id = c.Id,
                Rating = c.Rating,
                Title = c.Title
            });


        }
        public async Task<IEnumerable<MoviesServiceModel>> GetWatchedAsync(string userId)
        {
            var user = await data.Users
                .Where(u => u.Id == userId)
                .Include(u => u.WatchedMovies)
                .ThenInclude(um => um.Movie)
                .ThenInclude(m => m.Genre)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            return user.WatchedMovies
                .Select(m => new MoviesServiceModel()
                {
                    Director = m.Movie.Director,
                    GenreName = m.Movie.Genre?.Name,
                    Id = m.MovieId,
                    ImageUrl = m.Movie.ImageUrl,
                    Title = m.Movie.Title,
                    Rating = m.Movie.Rating,
                });
        }

        public async Task AddMovieToCollectionAsync(int movieId, string userId)
        {
            var user = await data.Users
                .Where(u => u.Id == userId)
                .Include(u => u.WatchedMovies)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            var movie = await data.Movies.FirstOrDefaultAsync(u => u.Id == movieId);

            if (movie == null)
            {
                throw new ArgumentException("Invalid Movie ID");
            }

            if (!user.WatchedMovies.Any(m => m.MovieId == movieId))
            {
                user.WatchedMovies.Add(new UserMovie()
                {
                    MovieId = movie.Id,
                    UserId = user.Id,
                    Movie = movie,
                    User = user
                });

                await data.SaveChangesAsync();
            }
        }

        public int Create(string title, string director, string imageUrl, decimal rating, int genreId)
        {

            var movieData = new Movie
            {
                Title = title,
                Director = director,
                ImageUrl = imageUrl,
                Rating = rating,
                GenreId = genreId
            };


            data.Movies.Add(movieData);
            data.SaveChanges();

            return movieData.Id;
        }

        public List<MovieGenreModel> AllGenres()
          => data
                .Genres
                .Select(c => new MovieGenreModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();


        public bool GenreExist(int genreId)
         => data
             .Genres
        .Any(c => c.Id == genreId);

        public IEnumerable<MoviesServiceModel> GetMovies(IQueryable<Movie> movie)
         => movie
             .Select(c => new MoviesServiceModel
             {
                 Id = c.Id,
                 Title = c.Title,
                 Director = c.Director,
                 GenreName = c.Genre.Name,
                 ImageUrl = c.ImageUrl,
                 Rating = c.Rating
             })
             .ToList();

        public async Task RemoveFromCollection(int movieId, string userId)
        {
            var user = await data.Users
                 .Where(u => u.Id == userId)
                 .Include(u => u.WatchedMovies)
                 .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            var movie = await data.UserMovies.FirstOrDefaultAsync(u => u.MovieId == movieId);

            if (movie == null)
            {
                throw new ArgumentException("Invalid Movie ID");
            }

            user.WatchedMovies.Remove(movie);

            await data.SaveChangesAsync();



        }
    }
}

