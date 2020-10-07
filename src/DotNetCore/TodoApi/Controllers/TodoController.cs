using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;
using System.Collections.Generic;
using TodoApi.DIServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoContext _todoContext;
        private readonly ILogger<TodoController> _logger;
        private readonly IOperationTransien _operationTransien;
        private readonly IOperationScope _operationScope;
        private readonly IOperationSingleton _operationSingleton;
        public TodoController(TodoContext todoContext,
            ILogger<TodoController> logger,
            IOperationTransien operationTransien,
            IOperationScope operationScope,
            IOperationSingleton operationSingleton)
        {
            _todoContext = todoContext;
            _logger = logger;
            _operationTransien = operationTransien;
            _operationScope = operationScope;
            _operationSingleton = operationSingleton;
        }

        // GET api/<TodoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> Get(int id)
        {
            var todoItem = await _todoContext.TodoItems.Where(m => m.Id == id).FirstOrDefaultAsync();
            _logger.LogInformation($"transient id is {_operationTransien.OperationId}");
            _logger.LogInformation($"scope id is {_operationScope.OperationId}");
            _logger.LogInformation($"singleton id is {_operationSingleton.OperationId}");
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
