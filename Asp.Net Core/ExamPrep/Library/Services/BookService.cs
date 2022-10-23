namespace Library.Services
{
    using Library.Data;
    using Library.Data.Models;
    using Library.Models.Books;
    using Microsoft.EntityFrameworkCore;

    public class BookService : IBookService
    {
        public LibraryDbContext data;

        public BookService(LibraryDbContext dbContext)
        {
            this.data = dbContext;
        }
        
        public IEnumerable<BookServiceViewModel> All()
        {
            var carsQuery = this.data
                .Books
                .Include(g => g.Category)
                .ToList();

            return carsQuery.Select(c => new BookServiceViewModel()
            {
                Id = c.Id,
                Author = c.Author,
                CategoryName = c.Category.Name,
                ImageUrl = c.ImageUrl,
                Description = c.Description,
                Rating = c.Rating,
                Title = c.Title
            });
        }
        public async Task<IEnumerable<BookServiceViewModel>> GetAddedBooks(string userId)
        {
            var user = await data.Users
                .Where(u => u.Id == userId)
                .Include(u => u.ApplicationUsersBooks)
                .ThenInclude(um => um.Book)
                .ThenInclude(m => m.Category)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            return user.ApplicationUsersBooks
                .Select(m => new BookServiceViewModel()
                {
                    Author = m.Book.Author,
                    CategoryName = m.Book.Category?.Name,
                    Id = m.BookId,
                    ImageUrl = m.Book.ImageUrl,
                    Title = m.Book.Title,
                    Rating = m.Book.Rating,
                });
        }

        public async Task AddBookToCollectionAsync(int bookId, string userId)
        {
            var user = await data.Users
                .Where(u => u.Id == userId)
                .Include(u => u.ApplicationUsersBooks)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            var book = await data.Books.FirstOrDefaultAsync(u => u.Id == bookId);

            if (book == null)
            {
                throw new ArgumentException("Invalid Book ID");
            }

            if (!user.ApplicationUsersBooks.Any(m => m.BookId == bookId))
            {
                user.ApplicationUsersBooks.Add(new ApplicationUserBook()
                {
                    Book = book,
                    BookId = bookId,
                    ApplicationUserId = userId,
                    ApplicationUser = user
                });

                await data.SaveChangesAsync();
            }
        }

        public int Create(string title, string author, string description, string imageUrl, decimal rating, int categoryId)
        {

            var bookData = new Book
            {
                Title = title,
                Author = author,
                Description = description,
                ImageUrl = imageUrl,
                Rating = rating,
                CategoryId = categoryId,

            };


            data.Books.Add(bookData);
            data.SaveChanges();

            return bookData.Id;
        }

        public List<BookCategoryViewModel> AllCategories()
          => data
                .Categories
                .Select(c => new BookCategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();


        public bool CategoryExist(int categoryId)
         => data
             .Categories
        .Any(c => c.Id == categoryId);

        
        public async Task RemoveFromCollection(int bookId, string userId)
        {
            var user = await data.Users
                 .Where(u => u.Id == userId)
                 .Include(u => u.ApplicationUsersBooks)
                 .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            var book =  user.ApplicationUsersBooks.FirstOrDefault(u => u.BookId == bookId);

            if (book == null)
            {
                throw new ArgumentException("Invalid Movie ID");
            }

            user.ApplicationUsersBooks.Remove(book);

            await data.SaveChangesAsync();

        }
    }
}
