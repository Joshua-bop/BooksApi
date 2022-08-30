using BooksApi.Repository.Contracts;
using BooksApi.Services.Contracts;
using BooksApi.Models;
using BooksApi.Models.RequestDtos;
using AutoMapper;
using BooksApi.Models.ResponseDtos;

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

        public async Task<long> AddBook(CreateBookRequestDto book)
        {
            Book mappedBook = _mapper.Map<Book>(book);
            return await _BooksRepository.AddBook(mappedBook);
        }

        public async Task DeleteBookById(long id)
        {
            await _BooksRepository.DeleteBookById(id);
            return;
        }

        public async Task<BookResponseDto?> GetBookById(long id)
        {
            var book = await _BooksRepository.GetBookById(id);
            return _mapper.Map<BookResponseDto>(book);
        }

        public async Task<List<BookResponseDto>> GetBooksBySearchTerm(string searchTerm)
        {
            searchTerm = searchTerm.Trim();
            searchTerm = searchTerm.ToLower();

            List<Book> books;

            switch (searchTerm)
            {
                case "title":
                    books = await _BooksRepository.GetBooksSortedByTitle(false);
                    return _mapper.Map<List<BookResponseDto>>(books);
                case "author":
                    books = await _BooksRepository.GetBooksSortedByTitle(false);
                    return _mapper.Map<List<BookResponseDto>>(books);
                case "price":
                    books = await _BooksRepository.GetBooksSortedByTitle(false);
                    return _mapper.Map<List<BookResponseDto>>(books);
                default:
                    books = await _BooksRepository.GetBooksSortedByTitle(false);
                    return _mapper.Map<List<BookResponseDto>>(books);
            }
        }

        public async Task UpdateBook(CreateBookRequestDto book, long id)
        {
            Book mappedBook = _mapper.Map<Book>(book);
            mappedBook.Id = id;
            await _BooksRepository.UpdateBook(mappedBook);
            return;
        }

        public async Task<bool> ValidateBookExists(long id)
        {
            return await _BooksRepository.ValidateItemExists(id);
        }
    }
}
