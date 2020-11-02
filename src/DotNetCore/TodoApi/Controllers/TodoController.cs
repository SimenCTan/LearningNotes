using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;
using System.Collections.Generic;
using TodoApi.DIServices;
using Microsoft.Extensions.Options;
using System;
using Microsoft.AspNetCore.Authorization;
using System.IO;

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
        private readonly PositionOptions _positionOptions;
        private readonly TopItemSettings _monthTopItem;
        private readonly TopItemSettings _yearTopItem;
        private readonly MyConfigOptions _myConfigOptions;
        public TodoController(TodoContext todoContext,
            ILogger<TodoController> logger,
            IOperationTransien operationTransien,
            IOperationScope operationScope,
            IOperationSingleton operationSingleton,
            IOptionsMonitor<PositionOptions> optionsMonitor,
            IOptionsSnapshot<TopItemSettings> namedOptionsAccessor,
            IOptions<MyConfigOptions> options)
        {
            _todoContext = todoContext;
            _logger = logger;
            _operationTransien = operationTransien;
            _operationScope = operationScope;
            _operationSingleton = operationSingleton;
            _positionOptions = optionsMonitor.CurrentValue;
            _monthTopItem = namedOptionsAccessor.Get(TopItemSettings.Month);
            _yearTopItem = namedOptionsAccessor.Get(TopItemSettings.Year);
            _myConfigOptions = options.Value;
        }

        // GET api/<TodoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> Get(int id)
        {
            _logger.LogInformation($"{_positionOptions.Name}");
            Console.WriteLine("ggg");
            var todoItem = await _todoContext.TodoItems.Where(m => m.Id == id).FirstOrDefaultAsync();
            _logger.LogInformation($"transient id is {_operationTransien.OperationId}");
            _logger.LogInformation($"scope id is {_operationScope.OperationId}");
            _logger.LogInformation($"singleton id is {_operationSingleton.OperationId}");
            _logger.LogWarning($"test");
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

        //[Authorize]
        //public IActionResult BannerImage()
        //{
        //    var filePath = Path.Combine(
        //        AppContext.BaseDirectory, "MyStaticFiles", "images", "red-rose.jpg");

        //    return PhysicalFile(filePath, "image/jpeg");
        //}
    }
}
