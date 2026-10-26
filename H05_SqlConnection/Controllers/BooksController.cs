using H05_SqlConnection.Data;
using H05_SqlConnection.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace H05_SqlConnection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private AppDataContext db;
        public BooksController(AppDataContext contex)
        {
            db = contex;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await db.Books.Where(p => p.Ok).ToListAsync();
            return Ok(list);
        }

        [HttpGet ("GetAllAdmin")]
        public async Task<IActionResult> GetAllAdmin()
        {
            var list = await db.Books.ToListAsync();
            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(Book book) 
        {
            if (book == null) 
                return BadRequest();

            if (book.Id > 0) 
                return BadRequest();

            if (string.IsNullOrEmpty(book.Title.Trim()) )
                return BadRequest();

            db.Books.Add(book);
            await db.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, Book book)
        {
            // KUllanıcıdan gelen veriye hiç bir zaman güvenmiyoruz
            if (book == null)
                return BadRequest();
            if (book.Id <= 0)
                return BadRequest();
            if (string.IsNullOrEmpty(book.Title.Trim()))
                return BadRequest();

            var bookToUpdate = await db.Books.FirstAsync(p => p.Id == id);
            if (bookToUpdate == null)
                return BadRequest();

            bookToUpdate.Title = book.Title;
            bookToUpdate.Price = book.Price;
            bookToUpdate.Description= book.Description;
            bookToUpdate.Ok = book.Ok;

            db.Entry(bookToUpdate).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest();

            var book = await db.Books.FirstOrDefaultAsync(p => p.Id == id);
            if(book == null)
                return BadRequest();

            book.Ok = false;
            db.Entry(book).State = EntityState.Modified;
            await db.SaveChangesAsync();

            return NoContent();
        }
    }
}
