using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using BooksApi.Attributes;
using BooksApi.Models;
using BooksApi.Models.Responses;
using BooksApi.Repository.Contracts;
using BooksApi.Models.RequestDtos;
using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;
using AutoMapper;

namespace BooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksRepository _BooksRepository;
        private readonly IMapper _mapper;

        public BooksController(IBooksRepository booksRepository, IMapper mapper)
        {
            _BooksRepository = booksRepository;
            _mapper = mapper;
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
            //TODO: Uncomment the next line to return response 201 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(201, default(InlineResponse201));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400, default(InlineResponse400));
            Book mappedBook = _mapper.Map<Book>(body);
            
            var response = new BookApiResponse201();
            response.Id = await _BooksRepository.AddBook(mappedBook);
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
        public async Task<IActionResult> DeleteBookById([FromRoute][Required] long? id)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200);

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404);

            throw new NotImplementedException();
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
        [SwaggerResponse(statusCode: 200, type: typeof(List<Book>), description: "Success")]
        public async Task<IActionResult> GetBook([FromQuery] string sortby)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(List<Book>));
            string exampleJson = null;
            exampleJson = "[ {\n  \"id\" : 4,\n  \"title\" : \"Journey to the Center of the Earth\",\n  \"author\" : \"Jules Verne\",\n  \"price\" : 10.99\n}, {\n  \"id\" : 4,\n  \"title\" : \"Journey to the Center of the Earth\",\n  \"author\" : \"Jules Verne\",\n  \"price\" : 10.99\n} ]";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<Book>>(exampleJson)
            : default(List<Book>);            //TODO: Change the data returned
            return new ObjectResult(example);
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
        [SwaggerResponse(statusCode: 200, type: typeof(Book), description: "Success")]
        public async Task<IActionResult> GetBookById([FromRoute][Required] long id)
        {
            var result = await _BooksRepository.GetBookById(id);

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
        public async Task<IActionResult> UpdateBookById([FromBody] Book body, [FromRoute][Required] long? id)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200);

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400, default(InlineResponse400));

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404);

            throw new NotImplementedException();
        }
    }
}
