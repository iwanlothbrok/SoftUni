namespace Library.Controllers
{
    using Library.Data;
    using Library.Extension;
    using Library.Models.Books;
    using Library.Services;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class BooksController : Controller
    {
        public IBookService bookService;
        public LibraryDbContext data;
        public BooksController(IBookService bookService, LibraryDbContext data)
        {
            this.bookService = bookService;
            this.data = data;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new AddBookViewModel
            {
                Categories = this.bookService.AllCategories()
            });
        }

        [HttpPost]
        public IActionResult Add(AddBookViewModel book)
        {
            if (bookService.CategoryExist(book.CategoryId) == false)
            {
                ModelState.AddModelError(nameof(book.CategoryId), "Category does not exist.");
            }

            if (ModelState.IsValid == false)
            {
                book.Categories = this.bookService.AllCategories();

                return View(book);
            }

            this.bookService.Create(book.Title, book.Author, book.Description, book.ImageUrl, book.Rating, book.CategoryId);

            return RedirectToAction("All", "Books");

        }

        [HttpGet]
        public IActionResult All()
        {
            var books = bookService.All();

            if (books.Any() == false)
            {
                ModelState.AddModelError(nameof(books), "There is no book with this criteria!");
            }
            return View(books);
        }

        public async Task<IActionResult> AddToCollection(int bookId)
        {
            try
            {
                var userId = User.GetId();

                await bookService.AddBookToCollectionAsync(bookId, userId);


            }
            catch (Exception)
            {

                return Unauthorized("Something is wrong.");
            }

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Mine()
        {
            var userId = User.GetId();
            var model = await bookService.GetAddedBooks(userId);

            return View(model);
        }

        public async Task<IActionResult> RemoveFromCollection(int bookId)
        {
            try
            {
                var userId = User.GetId();

                await bookService.RemoveFromCollection(bookId, userId);


            }
            catch (Exception)
            {
                return Unauthorized("Something is wrong.");
            }

            return RedirectToAction(nameof(Mine));
        }
    }
}
