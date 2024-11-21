using BookStore.Application.DTOS;
using BookStore.Application.Interfaces;
using BookStore.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers
{
    [Route("api/books")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookWithAuthorDto>>> GetAllBooks()
        {
            try
            {
                var books = await _bookService.GetAllBooksAsync();
                if (books == null)
                {
                    return NotFound("No books found.");
                }
                return Ok(books);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] BookWithAuthorDto bookDto)
        {
            if (bookDto == null)
            {
                return BadRequest("Invalid data.");
            }

            try
            {
                await _bookService.CreateBookAsync(bookDto);
                return CreatedAtAction(nameof(GetAllBooks), new { id = bookDto.BookId }, bookDto);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error.");
            }
        }


        [HttpPut]
        public async Task<IActionResult> UpdateBookAsync([FromBody] BookWithAuthorDto bookDto)
        {
            if (bookDto == null)
            {
                return BadRequest("Invalid book data.");
            }

            try
            {
                await _bookService.UpdateBookAsync(bookDto);
                return Ok(); 
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            try
            {
                var success = await _bookService.DeleteBookAsync(id);
                if (!success)
                {
                    return NotFound($"Book with ID {id} not found.");
                }

                return Ok(); 
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error.");
            }
        }


    }
}
