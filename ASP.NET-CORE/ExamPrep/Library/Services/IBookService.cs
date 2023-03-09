namespace Library.Services;

using Library.Models.Books;

public interface IBookService
{
    int Create(
          string title,
          string author,
          string description,
          string imageUrl,
          decimal rating,
          int categoryId
          );
    Task<IEnumerable<BookServiceViewModel>> GetAddedBooks(string userId);
    Task AddBookToCollectionAsync(int bookId, string userId);
    Task RemoveFromCollection(int booId, string userId);
    IEnumerable<BookServiceViewModel> All();
    List<BookCategoryViewModel> AllCategories();
    bool CategoryExist(int categoryId);
}

