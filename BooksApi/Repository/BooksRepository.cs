﻿using BooksApi.Models;
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

        public async Task<long> AddBook(Book book)
        {
            _dataContext.Books.Add(book);
            await _dataContext.SaveChangesAsync();
            return book.Id;
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

        public async Task<List<Book>> GetBooksBySearchTerm(string searchTerm)
        {
            //List<Book> books = from book in _dataContext.Books
            //                   where 

            
            throw new NotImplementedException();
        }

        public async Task UpdateBook(Book book)
        {

            throw new NotImplementedException();
        }
    }
}
