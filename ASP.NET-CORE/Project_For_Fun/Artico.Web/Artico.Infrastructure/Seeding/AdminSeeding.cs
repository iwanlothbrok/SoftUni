namespace Artico.Infrastrucutre.Seeding
{
	using Artico.Infrastrucutre.Data;
	using Artico.Infrastrucutre.Data.Models;
	using Artico.Infrastrucutre.Data.Seeding;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.Extensions.DependencyInjection;
	using System;
	using static Artico.Infrastrucutre.Data.Seeding.Constants.SeedingConstants;


	public class AdminSeeding : ISeeder
	{
		public void Seed(ApplicationDbContext data, IServiceProvider serviceProvider)
		{

			if (!data.Users.Any(e => e.Email == adminEmail))
			{
				var userManager =
					serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

				Task
					.Run(async () =>
					{
						var admin = new ApplicationUser() { Email = adminEmail, UserName = adminEmail };
						await userManager.CreateAsync(admin, adminPassword);
						await userManager.AddToRoleAsync(admin, AdminRole);
					})
					.GetAwaiter()
					.GetResult();
			}
		}
	}
}
