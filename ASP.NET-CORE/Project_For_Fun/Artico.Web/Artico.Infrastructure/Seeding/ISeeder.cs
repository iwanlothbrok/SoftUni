namespace Artico.Infrastrucutre.Data.Seeding
{
	using System;

	public interface ISeeder
	{
		void Seed(ApplicationDbContext data, IServiceProvider serviceProvider);
	}
}
