namespace Watchlist.Models.Movie
{
    using System.ComponentModel.DataAnnotations;

    public class MovieFormModel
    {
        [StringLength(50, MinimumLength = 10)]
        [Required]
        public string Title { get; set; }

        [StringLength(50, MinimumLength = 5)]
        [Required]
        public string Director { get; set; }

        
        [Required]
        [Display(Name = "Photo url")]
        public string ImageUrl { get; set; }

        [Required]
        [Range(typeof(decimal), "0", "10.0")]
        public decimal Rating { get; set; }

        
        public List<MovieGenreModel>? Genres { get; set; } 

        public int GenreId { get; set; }
    }
}
