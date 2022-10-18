namespace Watchlist.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Genre
    {
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 5)]
        [Required]
        public string Name { get; set; }
    }
}
