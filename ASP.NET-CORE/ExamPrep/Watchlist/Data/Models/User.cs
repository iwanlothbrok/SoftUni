namespace Watchlist.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        public List<UserMovie> WatchedMovies { get; init; }
    }
}
