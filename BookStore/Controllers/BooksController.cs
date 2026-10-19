using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var books = AppDataContext.books;

            return Ok(books);
        }

        // Verilen Id ye göre kitap getir
        [HttpGet("{id:int}")]
        public IActionResult GetBook(int id)
        {
            var books = AppDataContext.books;

            var requestedBook = books.SingleOrDefault(p => p.Id == id);

            if (requestedBook == null)
            {
                return NotFound("book404");
            }

            return Ok(requestedBook);
        }

        [HttpPost] // Kullanıcıdan gelen hiç bir içeriğe güvenilmemeli.
        public IActionResult Post(Book book)
        {
            var books = AppDataContext.books;

            var maxId = books.Max(p => p.Id);

            book.Id = maxId + 1;

            if (string.IsNullOrEmpty(book.Title.Trim()))
                return BadRequest("bookTitleNull");

            books.Add(book);

            return Ok(books);
        }

        [HttpPut]
        public IActionResult Update(int id, Book book)
        {
            var bookToUpdate = AppDataContext.books.SingleOrDefault(p => p.Id == id);

            if (bookToUpdate == null)
                return BadRequest("bookNotExist");

            bookToUpdate.Title = book.Title;
            bookToUpdate.Price = book.Price;

            return Ok(AppDataContext.books);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var books = AppDataContext.books;

            var bookToDelete = books.SingleOrDefault(p => p.Id == id);

            if (bookToDelete != null)
            {
                books.Remove(bookToDelete);
                //return NoContent();
                return Ok(books);
            }

            return BadRequest("BookNotExist");
        }
    }
}
