using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Core.Constants;

namespace Warehouse.Controllers
{
	[Authorize]
	public class HomeController : BaseController
    {
		private readonly ILogger<HomeController> _logger;


		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		// GET: HomeController
		public ActionResult Index()
		{
			ViewData[MessageConstant.SuccsessMessage] = "Welcome to the Warehouse!";

			return View();
		}

		// GET: HomeController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		// GET: HomeController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: HomeController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: HomeController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: HomeController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: HomeController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: HomeController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		
		
	}
}
