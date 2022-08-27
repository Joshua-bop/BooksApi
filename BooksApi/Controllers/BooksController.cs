﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using BooksApi.Attributes;
using BooksApi.Models;
using BooksApi.Models.Responses;
using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace BooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
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
        [SwaggerResponse(statusCode: 201, type: typeof(InlineResponse201), description: "Created")]
        [SwaggerResponse(statusCode: 400, type: typeof(InlineResponse400), description: "Bad Request")]
        public virtual IActionResult CreateBook([FromBody] Book body)
        {
            //TODO: Uncomment the next line to return response 201 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(201, default(InlineResponse201));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400, default(InlineResponse400));
            string exampleJson = null;
            exampleJson = "{\n  \"id\" : 0\n}";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<InlineResponse201>(exampleJson)
            : default(InlineResponse201);            //TODO: Change the data returned
            return new ObjectResult(example);
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
        public virtual IActionResult DeleteBookById([FromRoute][Required] long? id)
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
        public virtual IActionResult GetBook([FromQuery] string sortby)
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
        public virtual IActionResult GetBookById([FromRoute][Required] long? id)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(Book));

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404);
            string exampleJson = null;
            exampleJson = "{\n  \"id\" : 4,\n  \"title\" : \"Journey to the Center of the Earth\",\n  \"author\" : \"Jules Verne\",\n  \"price\" : 10.99\n}";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<Book>(exampleJson)
            : default(Book);            //TODO: Change the data returned
            return new ObjectResult(example);
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
        [SwaggerResponse(statusCode: 400, type: typeof(InlineResponse400), description: "Bad Request")]
        public virtual IActionResult UpdateBookById([FromBody] Book body, [FromRoute][Required] long? id)
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
