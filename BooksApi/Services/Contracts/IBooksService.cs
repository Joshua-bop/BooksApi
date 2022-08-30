using BooksApi.Models;
using BooksApi.Models.RequestDtos;

namespace BooksApi.Services.Contracts
{
    public interface IBooksService
    {
        public Task<Book?> GetBookById(long id);
        public Task<long> AddBook(CreateBookRequestDto book);
        public Task UpdateBook(Book book);
        public Task DeleteBookById(long id);
        public Task<List<Book>> GetBooksBySearchTerm(String searchTerm);
    }
}
