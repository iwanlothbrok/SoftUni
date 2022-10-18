namespace Watchlist.Models.User
{
    using Microsoft.AspNetCore.Mvc;
    using System.ComponentModel.DataAnnotations;

    public class RegisterViewModel
    {
        [StringLength(20, MinimumLength = 5)]
        [Required]
        public string UserName { get; set; }

        [StringLength(60, MinimumLength = 10)]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(20, MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        [Required]
        public string ConfirmPassword { get; set; }
    }
}
