namespace Watchlist.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        public List<Movie> WatchedMovies { get; set; }
    }
}
//· Has an Id – a string, Primary Key

//· Has a Username – a string with min length 5 and max length 20 (required)

//· Has an Email – a string with min length 10 and max length 60 (required)

//· Has a Password – a string with min length 5 and max length 20 (before hashed) – no max length required for a hashed password in the database (required)

//· Has WatchedMovies – a collection of Movies
        //public string Id { get; set; }

        //[StringLength(20, MinimumLength = 5)]
        //[Required]
        //public string Username { get; set; }

        //[StringLength(60, MinimumLength = 10)]
        //[Required]
        //[EmailAddress]
        //public string Email { get; set; }

        //[StringLength(20, MinimumLength = 5)]
        //[Required]
        //public string Password { get; set; }