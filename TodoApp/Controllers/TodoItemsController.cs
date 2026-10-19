using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApp.Data;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {

        private readonly AppDataContext _context;

        public TodoItemsController(AppDataContext appDataContext)
        {
            _context = appDataContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post(TodoItem todoItem)
        {
            if (todoItem.Id != 0)
                return BadRequest();

            _context.TodoItems.Add(todoItem); // Local de
            await _context.SaveChangesAsync();

            return Ok(todoItem);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var items = _context.TodoItems.Where(p => p.Ok).ToList();
            return Ok(items);
        }

        [HttpGet("GetAllAdmin")]
        public IActionResult GetAllAdmin()
        {
            var items = _context.TodoItems.ToList();
            return Ok(items);
        }

        [HttpGet("getById/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var todoItem = await _context.TodoItems
                  .SingleOrDefaultAsync(p => p.Id == id);

            if (todoItem == null)
            {
                return BadRequest("NoItemFound");
            }

            return Ok(todoItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TodoItem todoItem)
        {
            if (id <= 0)
                return BadRequest("IdError");

            var item = await _context.TodoItems
                .SingleOrDefaultAsync(p => p.Id == id);

            if (item == null)
                return BadRequest("TodoItemCantFound");

            item.Title = todoItem.Title;
            item.IsCompleted = todoItem.IsCompleted; // Localde değişiyor.

            _context.Entry(item).State = EntityState.Modified;

            try  // Hataları yakalama
            {
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex) {
                return BadRequest();
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           var item = await _context.TodoItems.FindAsync(id);
            
            if (item == null)
                return BadRequest();

            item.Ok = false;
            _context.Entry(item).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
