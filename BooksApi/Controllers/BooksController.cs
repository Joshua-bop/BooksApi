using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using BooksApi.Attributes;
using BooksApi.Models;
using BooksApi.Models.Responses;
using BooksApi.Repository.Contracts;
using BooksApi.Models.RequestDtos;
using BooksApi.Services.Contracts;
using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;
using AutoMapper;
using BooksApi.Models.ResponseDtos;

namespace BooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksService, IMapper mapper)
        {
            _booksService = booksService;
        }
        /// <summary>
        /// Creates a new book
        /// </summary>
        /// <param name="body">A JSON object that represents a book.</param>
        /// <response code="201">Created</response>
        /// <response code="400">Bad Request</response>
        [HttpPost]
        [Route("//books")]
        [ValidateModelState]
        [SwaggerOperation("CreateBook")]
        [SwaggerResponse(statusCode: 201, type: typeof(BookApiResponse201), description: "Created")]
        [SwaggerResponse(statusCode: 400, type: typeof(BookApiResponse400), description: "Bad Request")]
        public async Task<IActionResult> CreateBook([FromBody] CreateBookRequestDto body)
        {
            var response = new BookApiResponse201();
            response.Id = await _booksService.AddBook(body);
            return StatusCode(201, response);
        }

        /// <summary>
        /// Deletes a book by id
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Success</response>
        /// <response code="404">Book not found</response>
        [HttpDelete]
        [Route("//books/{id}")]
        [ValidateModelState]
        [SwaggerOperation("DeleteBookById")]
        public async Task<IActionResult> DeleteBookById([FromRoute][Required] long id)
        {
            if(!await _booksService.ValidateBookExists(id))
            {
                return StatusCode(404);
            }
            await _booksService.DeleteBookById(id);
            return Ok();
        }

        /// <summary>
        /// Returns a list of books. Sorted by title by default.
        /// </summary>
        /// <param name="sortby"></param>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("//books")]
        [ValidateModelState]
        [SwaggerOperation("GetBook")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<BookResponseDto>), description: "Success")]
        public async Task<IActionResult> GetBooks([FromQuery] string? sortby)
        {
            if (sortby == null) sortby = "title";
            var result = await _booksService.GetBooksBySearchTerm(sortby);
            return StatusCode(200, result);
        }

        /// <summary>
        /// Gets a book by id
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Success</response>
        /// <response code="404">Book not found</response>
        [HttpGet]
        [Route("//books/{id}")]
        [ValidateModelState]
        [SwaggerOperation("GetBookById")]
        [SwaggerResponse(statusCode: 200, type: typeof(BookResponseDto), description: "Success")]
        public async Task<IActionResult> GetBookById([FromRoute][Required] long id)
        {
            var result = await _booksService.GetBookById(id);

            if (result == null)
                return new NotFoundResult();

            return Ok(result);
        }

        /// <summary>
        /// Update an existing book
        /// </summary>
        /// <param name="body">A JSON object that represents a book.</param>
        /// <param name="id"></param>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Book not found</response>
        [HttpPut]
        [Route("//books/{id}")]
        [ValidateModelState]
        [SwaggerOperation("UpdateBookById")]
        [SwaggerResponse(statusCode: 400, type: typeof(BookApiResponse400), description: "Bad Request")]
        public async Task<IActionResult> UpdateBookById([FromBody] CreateBookRequestDto body, [FromRoute][Required] long id)
        {
            if (!await _booksService.ValidateBookExists(id))
            {
                return StatusCode(404);
            }

            await _booksService.UpdateBook(body, id);
            return StatusCode(200);
        }
    }
}
