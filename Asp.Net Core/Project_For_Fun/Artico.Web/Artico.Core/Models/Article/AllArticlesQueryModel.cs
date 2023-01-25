namespace Artico.Core.Models.Article
{
	using Artico.Core.Extensions;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;

	public class AllArticlesQueryModel
	{
		public const int ArticlesPerPage = 3;

		public string Title { get; init; }

		[Display(Name = "Search by text")]
		public string SearchTerm { get; init; }

		public ArticleSorting Sorting { get; init; }

		public int CurrentPage { get; init; } = 1;

		public int TotalArticles { get; set; }

		public IEnumerable<string> Titles { get; set; }

		public IEnumerable<ArticleFormModel>? Articles { get; set; }
	}
}
