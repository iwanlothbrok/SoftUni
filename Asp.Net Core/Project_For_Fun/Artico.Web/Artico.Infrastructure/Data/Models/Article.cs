namespace Artico.Infrastrucutre.Data.Models
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using static Artico.Infrastrucutre.Data.DataConstants;

	public class Article
	{
		public int Id { get; set; }

		[StringLength(TitleMaxLength)]
		public string Title { get; set; } = null!;

		public string Body { get; set; } = null!;

		public string? Tags { get; set; }

		public int Order { get; set; }

		[StringLength(JobMaxLength)]
		public string? Job { get; set; }

		[StringLength(PositionMaxLength)]
		public string? Position { get; set; }

		public string CreatorOfArticleId { get; set; } = null!;

		[ForeignKey(nameof(CreatorOfArticleId))]
		public ApplicationUser? User { get; set; }

		public bool IsVisibleUsers { get; set; }

		public bool IsVisibleGuests { get; set; }
	}
}
