namespace Artico.Infrastrucutre.Seeding
{
	using Artico.Infrastrucutre.Data;
	using Artico.Infrastrucutre.Data.Seeding;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.Extensions.DependencyInjection;
	using System;
	using System.Threading.Tasks;
	using static Artico.Infrastrucutre.Data.Seeding.Constants.SeedingConstants;

	public class RoleSeeder : ISeeder
	{
		public void Seed(ApplicationDbContext data, IServiceProvider serviceProvider)
		{
			var roleManager =
				serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

			Task
				.Run(async () =>
				{
					if (await roleManager.RoleExistsAsync(AdminRole))
						return;

					var adminRole = new IdentityRole { Name = AdminRole };

					await roleManager.CreateAsync(adminRole);

				})
				.GetAwaiter()
				.GetResult();
		}
	}
}
