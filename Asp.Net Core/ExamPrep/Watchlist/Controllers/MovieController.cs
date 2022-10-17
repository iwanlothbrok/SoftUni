namespace Watchlist.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Watchlist.Data;

    public class MovieController
    {

        public WatchlistDbContext data;

        public MovieController(WatchlistDbContext data)
        {
            this.data = data;
        }


        //public IActionResult Add() => View();
    }
}
