
using Watchlist.Models.Movie;

namespace Watchlist.Controllers
{

    using Microsoft.AspNetCore.Mvc;
    using Watchlist.Data;
    using System.Linq;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private WatchlistDbContext data;


        public HomeController(ILogger<HomeController> logger, WatchlistDbContext data)
        {
            _logger = logger;
            this.data = data;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Add() => View(new MovieFormModel()
        {
            Genres = AllGenres()
        });


        



        public List<MovieGenreModel> AllGenres()
                 => data
                       .Genres
                       .Select(c => new MovieGenreModel
                       {
                           Id = c.Id,
                           Name = c.Name
                       })
                       .ToList();
    }
}


