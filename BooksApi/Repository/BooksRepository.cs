using BooksApi.Models;
using BooksApi.Repository.Contracts;

namespace BooksApi.Repository
{
    public class BooksRepository : IBooksRepository
    {
        private readonly DataContext _dataContext;

        public BooksRepository (DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddBook(Book book)
        {
            _dataContext.Books.Add(book);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteBookById(long id)
        {
            Book book = new Book(id, "", "", 0);
            _dataContext.Books.Attach(book);
            _dataContext.Books.Remove(book);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Book?> GetBookById(long id)
        {
            var book = await _dataContext.Books.FindAsync(id);
            if (book == null) return null;
            return book;
        }

        public async Task<List<Book>> GetBooks()
        {
            return await _dataContext.Books.ToListAsync();
        }

        public async Task<List<Book>> GetBooksBySearchTerm(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateBook(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
