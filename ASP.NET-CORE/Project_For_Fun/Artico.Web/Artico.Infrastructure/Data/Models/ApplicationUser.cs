namespace Artico.Infrastrucutre.Data.Models
{
	using Microsoft.AspNetCore.Identity;
	using System;

	public class ApplicationUser : IdentityUser
	{
		public string? Job { get; set; }
		public string? Position { get; set; }

		public static implicit operator ApplicationUser(IdentityResult v)
		{
			throw new NotImplementedException();
		}
	}
}
