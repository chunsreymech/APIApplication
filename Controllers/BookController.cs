using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using APIApplication.Models;

namespace APIApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private static List<Book> _books() => new List<Book>
        {
            new Book().BindBook(1, "The Great Gatsby", "F. Scott Fitzgerald", new DateTime(1925, 4, 10)),
            new Book().BindBook(2, "To Kill a Mockingbird", "Harper Lee", new DateTime(1960, 7, 11)),
            new Book().BindBook(3, "1984", "George Orwell", new DateTime(1949, 6, 8)),
            new Book().BindBook(4, "Pride and Prejudice", "Jane Austen", new DateTime(1813, 1, 28)),
        };

        [HttpGet]
        public IActionResult GetBooks()
        {
            return Ok(_books());
        }
        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            var book = _books().FirstOrDefault(b => b.BookId == id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public IActionResult CreateBook([FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }
            var books = _books();
            book.BookId = books.Max(b => b.BookId) + 1;
            books.Add(book);
            return CreatedAtAction(nameof(GetBook), new { id = book.BookId }, book);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }
            var books = _books();
            var existingBook = books.FirstOrDefault(b => b.BookId == id);
            if (existingBook == null)
            {
                return NotFound();
            }
            books.Remove(existingBook);
            book.BookId = id;
            books.Add(book);
            return Ok(book);
        }



        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var books = _books();
            var book = books.FirstOrDefault(b => b.BookId == id);
            if (book == null)
            {
                return NotFound();
            }
            books.Remove(book);
            return Ok(book);
        }
    }
}
