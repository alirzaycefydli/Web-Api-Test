using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Api_Test.Data.Services;
using Web_Api_Test.Data.ViewModels;

namespace Web_Api_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BookService _booksService;

        public BooksController(BookService bookService)
        {
            _booksService = bookService;
        }

        [HttpPost("add-book")]
        public IActionResult AddBook([FromBody] BookViewModel bookViewModel)
        {
            _booksService.AddBook(bookViewModel);
            return Ok();
        }

        [HttpGet("get-all-book")]
        public IActionResult GetAllBooks()
        {
            var allBooks=_booksService.GetAllBooks();
            return Ok(allBooks);
        }

        [HttpGet("get-book-by-id/{id}")]
        public IActionResult GetBookByID(int id)
        {
            var book= _booksService.GetBookById(id);
            return Ok(book);
        }

        [HttpPut("update-book-by-id/{id}")]
        public IActionResult AddBook(int id, [FromBody] BookViewModel bookViewModel)
        {
            var updatedBook=_booksService.UpdateBookByID(id,bookViewModel);
            return Ok(updatedBook);
        }

        [HttpDelete("delete-book-by-id/{id}")]
        public IActionResult DeleteBookByID(int id)
        {
            _booksService.DeleteBookById(id);
            return Ok();
        }
    }
}
