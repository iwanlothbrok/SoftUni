namespace Artico.Core.Models
{
	using System.ComponentModel.DataAnnotations;
	using static Artico.Infrastrucutre.Data.DataConstants;

	public class ArticleFormModel
	{
		public int Id { get; set; }
		[StringLength(TitleMaxLength)]
		public string Title { get; set; } = null!;

		[Display(Name = "Description")]
		public string Body { get; set; } = null!;

		[Display(Name = "Tag of the article")]
		public string Tags { get; set; }

		[Display(Name = "Is it important?")]
		public int Order { get; set; }

		[StringLength(JobMaxLength)]
		[Display(Name = "For what job is the article?")]
		public string? Job { get; set; }

		public string? UserId { get; set; }

		[StringLength(PositionMaxLength)]
		[Display(Name = "For what job is the position?")]
		public string? Position { get; set; }

		[Display(Name = "Is it visible for every user?")]
		public bool IsVisibleUsers { get; set; }

		[Display(Name = "Is it visible for the guests?")]
		public bool IsVisibleGuests { get; set; }
	}
}
