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
//Has Id – a unique integer, Primary Key

//· Has Title – a string with min length 10 and max length 50 (required)

//· Has Director – a string with min length 5 and max length 50 (required)

//· Has Description – a string with min length 5 and max length 5000 (required)

//· Has ImageUrl – a string (required)

//· Has Rating – a decimal with min value 0.00 and max value 10.00 (required)

//· Has GenreId – an integer

//· Has Genre – a Genre