using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")] 
    [ApiController] 
    public class TodoItemsController : ControllerBase
    {
        private readonly TodoContext _context;

        public TodoItemsController(TodoContext context)     
        {
            _context = context;
        }

      //GET
        [HttpGet]
              
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetGames()
        {
            return await _context.Games.ToListAsync();  
        }

        
        [HttpGet("{id}")]
                
        public async Task<ActionResult<TodoItem>> GetTodoItem(
            [SwaggerParameter("Podaj nr zadnia które chcesz odczytać", Required = true)]
            long id)
        {
            var todoItem = await _context.Games.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound(); //http 404
            }

            return todoItem;    //http 200
        }

        // PUT: api/TodoItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        
        public async Task<IActionResult> PutTodoItem(long id, TodoItem todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(todoItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoItemExists(id))
                {
                    return NotFound();  //http 404
                }
                else
                {
                    throw;
                }
            }

            return NoContent(); //http 204
        }

        // POST: api/TodoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
        {
            _context.Games.Add(todoItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);  //http 201, add Location header
        }

        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
       
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            var todoItem = await _context.Games.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();  //http 404
            }

            _context.Games.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent(); //http 204
        }

        private bool TodoItemExists(long id)
        {
            return _context.Games.Any(e => e.Id == id);
        }
    }
}
