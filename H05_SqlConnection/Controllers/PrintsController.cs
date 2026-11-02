using H05_SqlConnection.Data;
using H05_SqlConnection.DTOs;
using H05_SqlConnection.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace H05_SqlConnection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrintsController : ControllerBase
    {
        AppDataContext db;
        public PrintsController(AppDataContext _db)
        {
            db = _db;
        }

        [HttpPost]
        public async Task<IActionResult> Insert(PrintInsertDto dto)
        {
            var book = await db.Books.FindAsync(dto.BookId);
            if (book == null)
                return BadRequest();

            Print print = new Print();
            print.Name = dto.Name;
            print.TranslatorName = dto.TranslatorName;
            print.Book = book;

            db.Prints.Add(print);
            await db.SaveChangesAsync();

            return Ok();
        }


        [HttpGet("GetByBookId/{bookId:int}")]
        public async Task<IActionResult> GetByBookID(int bookId)
        {
            var list = await db.Prints.Where(p => p.Book.Id == bookId)
                .ToListAsync();
            
            List<PrintsGetByBookIdDto> results = 
                new List<PrintsGetByBookIdDto>();
            foreach (var item in list)
            {
                PrintsGetByBookIdDto dto = new PrintsGetByBookIdDto();
                dto.TranslatorName = item.TranslatorName;
                dto.Id = item.Id;
                dto.Name = item.Name;
                results.Add(dto);
            }

            return Ok(results);
        }
    }
}
