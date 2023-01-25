namespace Artico.Infrastrucutre.Data
{
	using Artico.Infrastrucutre.Data.Models;
	using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore;

	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		protected override void OnModelCreating(ModelBuilder builder)
		{
			//for now

			base.OnModelCreating(builder);
		}

		public DbSet<Article> Articles { get; set; }
	}
}