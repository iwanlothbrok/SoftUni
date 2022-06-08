namespace BookShop
{
    using Data;
    using Initializer;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //StringComparison.OrdinalIgnoreCase
            // DbInitializer.ResetDatabase(db);
            //#2 System.Console.WriteLine(GetBooksByAgeRestriction(db, "miNor"));
            //#3 System.Console.WriteLine(GetGoldenBooks(db));
            //#4 System.Console.WriteLine(GetBooksNotReleasedIn(db, 1998));
            //#5 System.Console.WriteLine(GetBooksByPrice(db));
            //#6 System.Console.WriteLine(GetBooksByCategory(db, "horror mystery drama")); 
            //#7 System.Console.WriteLine(GetBooksReleasedBefore(db, "12-04-1992")); 
            //#8 System.Console.WriteLine(GetAuthorNamesEndingIn(db, "e")); 
            //#9 System.Console.WriteLine(GetBookTitlesContaining(db, "WOR"));
            //#10 System.Console.WriteLine(GetBooksByAuthor(db, "R"));
            //#11 System.Console.WriteLine(CountBooks(db, 12));
            //#12 System.Console.WriteLine(CountCopiesByAuthor(db));
            //#13 System.Console.WriteLine(GetTotalProfitByCategory(db));
             System.Console.WriteLine(RemoveBooks(db));
   
             
        }
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)//#2
        {
            var books = context.Books
            .ToList()
                .Where(ag => ag.AgeRestriction.ToString().Equals(command, StringComparison.OrdinalIgnoreCase))
                .Select(x => new
                {
                    Title = x.Title,
                })
            .OrderBy(t => t.Title)
            .ToList();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }
            return sb.ToString().TrimEnd();
        }
        public static string GetGoldenBooks(BookShopContext context) //#3

        {
            var books = context.Books
           .ToList()
               .Where(x => x.EditionType.ToString() == "Gold")
               .Select(x => new
               {
                   Id = x.BookId,
                   Sales = x.Copies,
                   Title = x.Title,
               })
               .Where(s => s.Sales < 5000)
           .OrderBy(t => t.Id)
           .ToList();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }
            return sb.ToString().TrimEnd();
        }
        public static string GetBooksNotReleasedIn(BookShopContext context, int year) //#5
        {

            if (year == null)
            {
                year = int.Parse(Console.ReadLine());
            }

            return string.Join(Environment.NewLine, context.Books
                .Where(b => b.ReleaseDate != null && b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title));
        }
        public static string GetBooksByPrice(BookShopContext context) //#4
        {
            var books = context.Books
                .Where(x => x.Price > 40)
                .Select(p => new
                {
                    Price = p.Price,
                    Title = p.Title,
                })
                .OrderByDescending(pr => pr.Price).ToList();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }
        public static string GetBooksByCategory(BookShopContext context, string input) //#6
        {
            if (input == null)
            {
                input = Console.ReadLine();
            }

            var categories = input
                .ToLower()
                .Split(new[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            return string.Join(Environment.NewLine, context.Books
                .Where(b => b.BookCategories
                    .Select(bc => bc.Category.Name.ToLower())
                    .Intersect(categories)
                    .Any())
                .Select(b => b.Title)
                .OrderBy(t => t));
        }
        public static string GetBooksReleasedBefore(BookShopContext context, string date) //#7
        {
            var parsedDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(x => x.ReleaseDate < parsedDate)
                .Select(a => new
                {
                    Title = a.Title,
                    EditionType = a.EditionType,
                    Price = a.Price,
                    ReleaseDate = a.ReleaseDate
                })
                .OrderByDescending(rd => rd.ReleaseDate).ToArray();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }
            return sb.ToString().TrimEnd();
        }
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input) //#8
        {
            var authors = context.Authors.Where(n => n.FirstName.EndsWith(input)).Select(a => new
            {
                Name = a.FirstName + " " + a.LastName,

            })
                .OrderBy(a => a.Name).ToArray();

            var sb = new StringBuilder();

            foreach (var author in authors)
            {
                sb.AppendLine(author.Name);
            }
            return sb.ToString().TrimEnd();

        }
        public static string GetBookTitlesContaining(BookShopContext context, string input) //#9
        {
            var books = context.Books
                .ToArray()
                .Select(s => new
                {
                    Title = s.Title,
                })
                .OrderBy(x => x.Title)
                .Where(t => t.Title.ToUpper().Contains(input.ToUpper()));



            var sb = new StringBuilder();
            foreach (var item in books)
            {
                sb.AppendLine(item.Title);
            }

            return sb.ToString().TrimEnd();
        }
        public static string GetBooksByAuthor(BookShopContext context, string input) //#10
        {
            var books = context.Books.Select(x => new
            {
                Author = x.Author.FirstName + " " + x.Author.LastName,
                LastName = x.Author.LastName,
                Title = x.Title,
                Id = x.BookId
            }).ToArray().Where(a => a.LastName.StartsWith(input, StringComparison.OrdinalIgnoreCase))
                 .OrderBy(i => i.Id).ToArray();

            var sb = new StringBuilder();

            foreach (var book in books)
            {

                sb.AppendLine($"{book.Title} ({book.Author})");

            }
            return sb.ToString().TrimEnd();
        }
        public static int CountBooks(BookShopContext context, int lengthCheck)//#11
        {
            var books = context.Books.Where(a => a.Title.Length > lengthCheck);


            return books.Count();
        }
        public static string CountCopiesByAuthor(BookShopContext context)//#12
        {
            var books = context.Authors.Select(a => new
            {
                Name = $"{a.FirstName} {a.LastName}",
                Copies = a.Books
                      .Select(b => b.Copies)
                      .Sum()
            })
                .OrderByDescending(a => a.Copies).ToArray();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Name} - {book.Copies}");
            }
            return sb.ToString();
        }
        public static string GetTotalProfitByCategory(BookShopContext context)//#13
        {

            var books = context.Categories.Select(a => new
            {
                Category = a.Name
                ,
                Profit = a.CategoryBooks
                        .Select(cb => cb.Book.Price * cb.Book.Copies)
                        .Sum()
            }).OrderByDescending(pr => pr.Profit).ThenBy(c => c.Category).ToArray();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Category} ${book.Profit}");
            }
            return sb.ToString();
        }
        public static void IncreasePrices(BookShopContext context)//#15
        {
            var books = context.Books.Where(x => x.ReleaseDate.Value.Year > 2010)
            .ToArray();


            foreach (var book in books)
            {

                book.Price += 5;
            }
            context.SaveChanges();
        }
        public static int RemoveBooks(BookShopContext context) //#16
        {
            var books = context.Books.Where(c => c.Copies < 4200).ToArray();

            var removedBooks = books.Length;
            foreach (var book in books)
            {
                context.Books.Remove(book);
            }
            context.SaveChanges();
            return removedBooks;
        }
    }
}
////   var sb = new stringbuilder();

//foreach (var book in books)
//{
//    sb.appendline($"{book.name} - {book.copies}");
//}
//return sb.tostring();