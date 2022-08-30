using BooksApi.Repository.Contracts;
using BooksApi.Services.Contracts;
using BooksApi.Models;
using BooksApi.Models.RequestDtos;
using AutoMapper;

namespace BooksApi.Services
{
    public class BooksService : IBooksService
    {
        private readonly IBooksRepository _BooksRepository;
        private readonly IMapper _mapper;
        public BooksService(IBooksRepository BooksRepository, IMapper mapper)
        {
            _BooksRepository = BooksRepository;
            _mapper = mapper;

        }

        public Task<long> AddBook(CreateBookRequestDto book)
        {
            // sanitization input
            // sanitize price of book
            Book mappedBook = _mapper.Map<Book>(book);
            return _BooksRepository.AddBook(mappedBook);
        }

        public Task DeleteBookById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Book?> GetBookById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Book>> GetBooksBySearchTerm(string searchTerm)
        {
            return _BooksRepository.GetBooksBySearchTerm(searchTerm);
        }

        public Task UpdateBook(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
