namespace Watchlist.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;

    public class Movie
    {
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 10)]
        [Required]
        public string Title { get; set; }

        [StringLength(50, MinimumLength = 5)]
        [Required]
        public string Director { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public decimal Rating { get; set; }

        public int GenreId { get; set; }

        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }

        public List<UserMovie> UserMovies { get; set; }
    }
}
