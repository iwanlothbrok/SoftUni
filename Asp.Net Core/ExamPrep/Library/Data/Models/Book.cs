namespace Library.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Book
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 10)]
        [Required]
        public string Title { get; set; }

        [StringLength(50, MinimumLength = 5)]
        [Required]
        public string Author { get; set; } 

        [StringLength(5000, MinimumLength = 5)]
        [Required]
        public string Description { get; set; } 

        [Required]
        [Url]
        public string ImageUrl { get; set; } 

        [Required]
        public decimal Rating { get; set; } 

        [Required]
        public int CategoryId { get; set; }
        [Required]
        public Category Category { get; set; }

        public List<ApplicationUserBook> ApplicationUsersBooks { get; set; } = new List<ApplicationUserBook>();

    }
}
