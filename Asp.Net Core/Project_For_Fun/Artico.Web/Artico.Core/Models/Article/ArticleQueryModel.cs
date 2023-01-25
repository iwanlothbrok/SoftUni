namespace Artico.Core.Models.Article
{
	public class ArticleQueryModel
	{
		public int CurrentPage { get; init; }

		public int ArticlesPerPage { get; init; }

		public int TotalArticles { get; init; }

		public IEnumerable<ArticleFormModel>? Articles { get; init; }
	}
}
