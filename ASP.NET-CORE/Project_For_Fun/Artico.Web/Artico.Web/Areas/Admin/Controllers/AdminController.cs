namespace Artico.Web.Areas.Admin.Controller
{
    using Artico.Core.Extensions;
    using Artico.Core.Models;
    using Artico.Core.Services.Articles;
    using Artico.Infrastrucutre.Data.Models;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using static Artico.Web.Areas.Constants;

    [Area(Admin)]
    public class AdminController : Controller
    {
        private readonly IArticleService articleService;
        private readonly IMapper mapper;

        public AdminController(IArticleService articleService, IMapper mapper)
        {
            this.articleService = articleService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Home()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new ArticleFormModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(ArticleFormModel article)
        {
            if (this.ModelState.IsValid == false)
            {

                return View(article);
            }

            int id = await this.articleService.Create(article.Title, article.Body, article.Tags, article.Order, article.Job, article.Position, User.GetId(), article.IsVisibleUsers, article.IsVisibleGuests);

            if (id == 0)
            {
                //return errror 
                return BadRequest();
            }
            TempData[GlobalMessageKey] = "Thank you for adding this article!";

            return RedirectToAction("Home", "Admin");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Article? article = this.articleService.GetArticleDetails(id);
            string userId = User.GetId();

            if (article.CreatorOfArticleId != userId)
            {
                return BadRequest();
            }
            if (article == null)
            {
                return BadRequest();
            }

            ArticleFormModel articleOutput = this.mapper.Map<ArticleFormModel>(article);

            return View(articleOutput);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ArticleFormModel article)
        {

            if (this.ModelState.IsValid == false)
            {

                return View(article);
            }

            await this.articleService.Edit(id, article.Title, article.Body, article.Tags, article.Order, article.Job, article.Position, User.GetId(), article.IsVisibleUsers, article.IsVisibleGuests);


            TempData[GlobalMessageKey] = "You edit this article successfully!";

            return RedirectToAction("Home", "Admin");
        }

        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            this.articleService.Delete(id);

            TempData[GlobalMessageKey] = "You delete your article!";

            return RedirectToAction("Home", "Admin");
        }
    }
}
