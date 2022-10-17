namespace Watchlist.Models.User
{
    using Microsoft.AspNetCore.Mvc;
    using System.ComponentModel.DataAnnotations;
    using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

    public class LogInModel
    {
        [StringLength(20, MinimumLength = 5)]
        [Required]
        public string Username { get; set; }

        [StringLength(20, MinimumLength = 5)]
        [HiddenInput]
        [Required]
        public string Password { get; set; }

    }
}
