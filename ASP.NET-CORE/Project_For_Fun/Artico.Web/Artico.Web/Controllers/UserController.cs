namespace Artico.Web.Controllers
{
	using Artico.Core.Extensions;
	using Artico.Core.Models.Article;
	using Artico.Core.Services.Articles;
	using Artico.Core.Services.Users;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Mvc;
	using static Artico.Web.Areas.Constants;

	public class UserController : Controller
	{
		private readonly RoleManager<IdentityRole> roleManager;
		private readonly IApplicationUserService user;
		private readonly IArticleService articleService;

		public UserController(RoleManager<IdentityRole> roleManager, IApplicationUserService user, IArticleService articleService)
		{
			this.roleManager = roleManager;
			this.user = user;
			this.articleService = articleService;
		}

		public IActionResult Become()
		{
			this.user.SetUserRole(User.GetId());

			TempData[GlobalMessageKey] = "You become Admin!";

			return RedirectToAction("All", "User");
		}

		public async Task<IActionResult> CreateRole()
		{
			await roleManager.CreateAsync(new IdentityRole()
			{
				Name = "Administrator"
			});

			TempData[GlobalMessageKey] = "You create Admin role!";

			return RedirectToAction("All", "User");
		}

		[HttpGet]
		[AllowAnonymous]
		public IActionResult All([FromQuery] AllArticlesQueryModel query)
		{
			ArticleQueryModel queryResult = this.articleService.All(
				 query.Title,
				 query.SearchTerm,
				 query.Sorting,
				 query.CurrentPage,
				 AllArticlesQueryModel.ArticlesPerPage);

			IEnumerable<string>? bookTitles = this.articleService
				.AllTitles()
				.ToList();

			query.Titles = bookTitles;
			query.TotalArticles = queryResult.TotalArticles;
			query.Articles = queryResult.Articles;

			return View(query);
		}
	}
}

