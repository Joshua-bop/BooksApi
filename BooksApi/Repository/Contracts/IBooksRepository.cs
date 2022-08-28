using BooksApi.Models;

namespace BooksApi.Repository.Contracts
{
    public interface IBooksRepository
    {
        public Task<List<Book>> GetBooks();
        public Task<Book?> GetBookById(long id);

        public Task<long> AddBook(Book book);
        public Task UpdateBook(Book book);
        public Task DeleteBookById (long id);
        public Task<List<Book>> GetBooksBySearchTerm(String searchTerm);

    }
}
