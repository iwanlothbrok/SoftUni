namespace Artico.Core.Services.Articles
{
    using Artico.Core.Extensions;
    using Artico.Core.Models;
    using Artico.Core.Models.Article;
    using Artico.Infrastrucutre.Data;
    using Artico.Infrastrucutre.Data.Models;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    public class ArticleService : IArticleService
    {
        private readonly ApplicationDbContext data;
        private readonly IMapper mapper;

        public ArticleService(ApplicationDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }

        public async Task<int> Create(string title, string body, string tag, int order, string job, string position, string userId, bool isVisibleForUsers, bool isVisibleForGuests)
        {
            // add check 

            Article article = new Article
            {
                Title = title,
                Body = body,
                Tags = tag,
                Order = order,
                Job = job,
                Position = position,
                CreatorOfArticleId = userId,
                IsVisibleUsers = isVisibleForUsers,
                IsVisibleGuests = isVisibleForGuests
            };

            await this.data.Articles.AddAsync(article);
            await this.data.SaveChangesAsync();

            return article.Id;
        }

        public async Task<int> Edit(int id, string title, string body, string tag, int order, string job, string position, string userId, bool isVisibleForUsers, bool isVisibleForGuests)
        {
            Article? article = await this.data.Articles.FindAsync(id);

            if (article == null)
            {
                return 0;
            }
            article.Id = id;
            article.Title = title;
            article.Body = body;
            article.Tags = tag;
            article.Order = order;
            article.Job = job;
            article.Position = position;
            article.CreatorOfArticleId = userId;
            article.IsVisibleGuests = isVisibleForGuests;
            article.IsVisibleUsers = isVisibleForUsers;

            await this.data.SaveChangesAsync();

            return article.Id;
        }


        public Article? GetArticleDetails(int id)
       => this.data
         .Articles
         .Where(i => i.Id == id)
         .FirstOrDefault();


        public bool Delete(int id)
        {
            Article? article = this.data.Articles.Find(id);

            if (article == null)
            {
                return false;
            }

            this.data.Articles.Remove(article);
            this.data.SaveChanges();


            return true;
        }
        public ArticleQueryModel All(string title, string searchTerm, ArticleSorting sorting, int currentPage, int articlePerPage)
        {
            var articleQuery = this.data.Articles
                                             .Where(p => p.User != null || p.User == null);

            if (!string.IsNullOrWhiteSpace(title))
            {
                articleQuery = articleQuery.Where(c => c.Title == title);
            }

            articleQuery = sorting switch
            {
                ArticleSorting.Order => articleQuery.OrderByDescending(c => c.Order),
                ArticleSorting.Title => articleQuery.OrderByDescending(c => c.Title),
                ArticleSorting.Position => articleQuery.Where(c => c.Position == searchTerm),
                ArticleSorting.Job => articleQuery.Where(c => c.Job == searchTerm),
                ArticleSorting.isOnlyForGuests => articleQuery.Where(c => c.IsVisibleGuests == true),
                ArticleSorting.isOnlyForUsers => articleQuery.Where(c => c.IsVisibleGuests == true),
            };

            int totalArticles = articleQuery.Count();

            if (searchTerm != null)
            {
                articleQuery = articleQuery.Where(c => c.Title.Contains(searchTerm) || c.Job.Contains(searchTerm) || c.Position.Contains(searchTerm));
            }

            var articles = GetArticles(articleQuery
                 .Skip((currentPage - 1) * articlePerPage)
                 .Take(articlePerPage)
                 .AsQueryable());

            return new ArticleQueryModel
            {
                TotalArticles = totalArticles,
                CurrentPage = currentPage,
                ArticlesPerPage = articlePerPage,
                Articles = articles
            };
        }
        public IEnumerable<ArticleFormModel> GetArticles(IQueryable<Article> articleQuery)
      => articleQuery
          .ProjectTo<ArticleFormModel>(this.mapper.ConfigurationProvider)
          .ToList();

        public IEnumerable<string> AllTitles()
         => this.data
            .Articles
            .Select(c => c.Title)
            .Distinct()
            .OrderBy(br => br)
            .ToList();
    }
}
