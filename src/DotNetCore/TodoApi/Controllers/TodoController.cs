using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoContext _todoContext;
        private readonly ILogger<TodoController> _logger;
        public TodoController(TodoContext todoContext,
            ILogger<TodoController> logger)
        {
            _todoContext = todoContext;
            _logger = logger;
        }

        // GET api/<TodoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> Get(int id)
        {
            var todoItem = await _todoContext.TodoItems.Where(m => m.Id == id).FirstOrDefaultAsync();
            return Ok(todoItem);
        }

        // GET api/<TodoController>/5
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> Get()
        {
            var todoItems = await _todoContext.TodoItems.ToListAsync();
            return Ok(todoItems);
        }

        // POST api/<TodoController>
        [HttpPost]
        public async Task<ActionResult<TodoItem>> Post([FromBody] TodoItem todoItem)
        {
            await _todoContext.AddAsync(todoItem);
            await _todoContext.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = todoItem.Id }, todoItem);
        }

        // PUT api/<TodoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TodoItem todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }

            _todoContext.Entry(todoItem).State = EntityState.Modified;

            try
            {
                await _todoContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE api/<TodoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var todoItem = await _todoContext.TodoItems.FirstOrDefaultAsync(m => m.Id == id);
            _todoContext.Remove(todoItem);
            await _todoContext.SaveChangesAsync();
            return Ok(todoItem);
        }
    }
}
