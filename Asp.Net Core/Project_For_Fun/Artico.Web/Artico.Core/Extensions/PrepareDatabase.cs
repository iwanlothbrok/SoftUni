﻿namespace Artico.Core.Extensions
{
	using Artico.Infrastrucutre.Data;
	using Artico.Infrastrucutre.Data.Seeding;
	using Microsoft.AspNetCore.Builder;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.Extensions.DependencyInjection;

	public static class ApplicationBuilderExtensions
	{
		public static IApplicationBuilder PrepareDatabase(
		   this IApplicationBuilder app)
		{
			using var scopedServices = app.ApplicationServices.CreateScope();
			var services = scopedServices.ServiceProvider;
			var data = scopedServices.ServiceProvider
				.GetService<ApplicationDbContext>();

			data.Database.Migrate();

			var seeder = new Seeder();
			seeder.Seed(data, services);

			data.Database.Migrate();

			return app;
		}
	}
}
