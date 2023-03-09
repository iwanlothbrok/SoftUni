using Microsoft.AspNetCore.Mvc;

namespace NumbersExer.Controllers
{
	public class NumbersController : Controller
	{
		public IActionResult Numbers()
		{
			return View();
		}

		public ActionResult AddNumber()
		{
			// взимаме числата, ако няма правим нов ма

			List<int> numbers = ViewData["Numbers"] as List<int> ?? new List<int>();

			// рандом
			int newNumber = new Random().Next(1, 101);
			numbers.Add(newNumber);

			// адваме го
			//ViewData["Numbers"] = numbers;

			// връщаме json
			return Json(newNumber);
		}

		public ActionResult SumNumbers()
		{
			// числата, ако не нов лист
			List<int> numbers = ViewData["Numbers"] as List<int>;

			if (numbers == null || numbers.Count == 0)
			{
				return Json(0);
			}
			
			//взимаме сумата 
			int sum = numbers.Sum();

			ViewData["Sum"] = sum;

			return Json(sum);
		}

		public ActionResult ClearNumbers()
		{
			// махаме числата
			ViewData["Numbers"] = new List<int>();

			return Json(new { success = true });
		}
	}
}
