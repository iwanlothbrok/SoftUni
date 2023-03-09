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
			// Get the current list of numbers from the ViewBag state, or create a new list if one does not exist
			List<int> numbers = ViewBag.Numbers as List<int> ?? new List<int>();

			// Generate a random number and add it to the list
			int newNumber = new Random().Next(1, 101);
			numbers.Add(newNumber);

			// Store the updated list back into the ViewBag state
			ViewBag.Numbers = numbers;

			// Return the new number as a JSON response
			return Json(newNumber);
		}
		public ActionResult SumNumbers()
		{
			// Get the current list of numbers from the ViewBag state, or create a new list if one does not exist
			List<int> numbers = ViewBag.Numbers as List<int> ?? new List<int>();

			// Calculate the sum of the numbers in the list
			int sum = numbers.Sum();

			// Store the sum in the ViewBag state
			ViewBag.Sum = sum;

			// Return the sum as a JSON response
			return Json(sum);
		}

		public ActionResult ClearNumbers()
		{
			// Clear the list of numbers in the ViewBag state
			ViewBag.Numbers = new List<int>();

			// Return a success message as a JSON response
			return Json(new { success = true });
		}
	}
}
