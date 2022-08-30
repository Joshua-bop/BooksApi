using BooksApi.Models;
using BooksApi.Models.RequestDtos;
using BooksApi.Models.ResponseDtos;

namespace BooksApi.Services.Contracts
{
    public interface IBooksService
    {
        public Task<BookResponseDto?> GetBookById(long id);
        public Task<long> AddBook(CreateBookRequestDto book);
        public Task UpdateBook(CreateBookRequestDto book, long id);
        public Task DeleteBookById(long id);
        public Task<List<BookResponseDto>> GetBooksBySearchTerm(String searchTerm);
        public Task<bool> ValidateBookExists(long id);
    }
}
