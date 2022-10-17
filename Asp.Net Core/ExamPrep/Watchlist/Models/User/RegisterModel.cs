namespace Watchlist.Models.User
{
    using Microsoft.AspNetCore.Mvc;
    using System.ComponentModel.DataAnnotations;

    public class RegisterModel
    {
        [StringLength(20, MinimumLength = 5)]
        [Required]
        public string Username { get; set; }

        [StringLength(60, MinimumLength = 10)]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(20, MinimumLength = 5)]
        [HiddenInput]
        [Required]
        public string Password { get; set; }

        [StringLength(20, MinimumLength = 5)]
        [HiddenInput]
        [Required]
        public string ConfirmPassword { get; set; }
    }
}
