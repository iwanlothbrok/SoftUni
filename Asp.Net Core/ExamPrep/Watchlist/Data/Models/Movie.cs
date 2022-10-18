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

        [StringLength(5000, MinimumLength = 5)]
        [Required]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Range(18,1)]
        public decimal Rating { get; set; }

        public int GenreId { get; set; }

        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }
    }
}
