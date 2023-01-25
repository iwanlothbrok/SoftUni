namespace Artico.Infrastrucutre.Data.Seeding
{
	using Artico.Infrastrucutre.Seeding;

	public class Seeder : ISeeder
	{
		public void Seed(ApplicationDbContext data, IServiceProvider serviceProvider)
		{
			List<ISeeder> seeders = new List<ISeeder>()
			{
			new RoleSeeder(),
			new UsersSeeder(),
			new AdminSeeding(),
			};

			foreach (var seeder in seeders)
			{
				seeder.Seed(data, serviceProvider);
			}
		}
	}
}