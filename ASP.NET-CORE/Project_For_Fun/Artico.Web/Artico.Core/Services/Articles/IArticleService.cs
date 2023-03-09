namespace Artico.Core.Services.Articles
{
	using Artico.Core.Extensions;
	using Artico.Core.Models;
	using Artico.Core.Models.Article;
	using Artico.Infrastrucutre.Data.Models;

	public interface IArticleService
	{
		bool Delete(int id);
		IEnumerable<string> AllTitles();
		Article? GetArticleDetails(int id);
		IEnumerable<ArticleFormModel> GetArticles(IQueryable<Article> articleQuery);
		ArticleQueryModel All(string title, string searchTerm, ArticleSorting sorting, int currentPage, int articlePerPage);
		Task<int> Create(string title, string body, string tag, int order, string job, string position, string userId, bool isVisibleForUsers, bool isVisibleForGuests);
		Task<int> Edit(int id, string title, string body, string tag, int order, string job, string position, string userId, bool isVisibleForUsers, bool isVisibleForGuests);
	}
}
