namespace Artico.Core.Services.Users
{
	using Artico.Infrastrucutre.Data;
	using Artico.Infrastrucutre.Data.Models;
	using Microsoft.AspNetCore.Identity;
	using static Artico.Infrastrucutre.Data.Seeding.Constants.SeedingConstants;

	public class ApplicationUserService : IApplicationUserService
	{
		private readonly ApplicationDbContext data;
		private readonly UserManager<ApplicationUser> userManager;

		public ApplicationUserService(ApplicationDbContext data, UserManager<ApplicationUser> userManager)
		{
			this.data = data;
			this.userManager = userManager;
		}

		public bool SetUserRole(string userId)
		{
			if (data.Users.Any(e => e.Id == userId))
			{
				var user = this.data.Users.Find(userId);

				Task
					.Run(async () =>
					{
						await userManager.AddToRoleAsync(user, AdminRole);
					})
					.GetAwaiter()
					.GetResult();

				return true;
			}
			return false;
		}
	}
}
