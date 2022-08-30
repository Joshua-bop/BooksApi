using BooksApi.Models;

namespace BooksApi.Repository.Contracts
{
    public interface IBooksRepository
    {
        public Task<Book?> GetBookById(long id);
        public Task<long> AddBook(Book book);
        public Task UpdateBook(Book book);
        public Task DeleteBookById (long id);
        public Task<List<Book>> GetBooksSortedByTitle(bool isDescending);
        public Task<List<Book>> GetBooksSortedByAuthor(bool isDescending);
        public Task<List<Book>> GetBooksSortedByPrice(bool isDescending);
        public Task<bool> ValidateItemExists(long id);
    }
}
