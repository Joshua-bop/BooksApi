using BooksApi.Models;
using BooksApi.Repository.Contracts;

namespace BooksApi.Repository
{
    public class BooksRepository : IBooksRepository
    {
        private readonly DataContext _dataContext;

        public BooksRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<long> AddBook(Book book)
        {
            _dataContext.Books.Add(book);
            await _dataContext.SaveChangesAsync();
            return book.Id;
        }

        public async Task DeleteBookById(long id)
        {
            Book book = new Book(id, "", "", 0);
            _dataContext.Books.Remove(book);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Book?> GetBookById(long id)
        {
            var book = await _dataContext.Books.FindAsync(id);
            if (book == null) return null;
            return book;
        }

        public async Task<List<Book>> GetBooksSortedByAuthor(bool isDescending = true)
        {
            if (isDescending)
            {
                return await _dataContext.Books.OrderByDescending(x => x.Author).ToListAsync();
            }
            else
            {
                return await _dataContext.Books.OrderBy(x => x.Author).ToListAsync();
            }
        }

        public async Task<List<Book>> GetBooksSortedByPrice(bool isDescending = true)
        {
            if (isDescending)
            {
                return await _dataContext.Books.OrderByDescending(x => x.Price).ToListAsync();
            }
            else
            {
                return await _dataContext.Books.OrderBy(x => x.Price).ToListAsync();
            }
        }

        public async Task<List<Book>> GetBooksSortedByTitle(bool isDescending = true)
        {
            if (isDescending)
            {
                return await _dataContext.Books.OrderByDescending(x => x.Title).ToListAsync();
            }
            else
            {
                return await _dataContext.Books.OrderBy(x => x.Title).ToListAsync();
            }
        }

        public async Task UpdateBook(Book newBook)
        {
            var book = await GetBookById(newBook.Id);

            if (book == null) throw new Exception("Failed to find book during Update");

            book.Title = newBook.Title;
            book.Author = newBook.Author;
            book.Price = newBook.Price;
            await _dataContext.SaveChangesAsync();
        }
        public async Task<bool> ValidateItemExists(long id)
        {
            var book = await GetBookById(id);
            if (book == null) return false;
            _dataContext.Entry(book).State = EntityState.Detached;
            return true;
        }
    }
}
