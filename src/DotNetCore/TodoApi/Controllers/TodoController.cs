using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;
using System.Collections.Generic;
using TodoApi.DIServices;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;
using System;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using Microsoft.AspNetCore.Http;
using TodoApi.Filters;
using TodoApi.Extensions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AddHeader("Author","Simen")]
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
        private readonly IHttpClientFactory _clientFactory;
        private readonly IMemoryCache _cache;
        private readonly IDistributedCache _distributedCache;
        public TodoController(TodoContext todoContext,
            ILogger<TodoController> logger,
            IOperationTransien operationTransien,
            IOperationScope operationScope,
            IOperationSingleton operationSingleton,
            IOptionsMonitor<PositionOptions> optionsMonitor,
            IOptionsSnapshot<TopItemSettings> namedOptionsAccessor,
            IOptions<MyConfigOptions> options,
            IHttpClientFactory httpClientFactory,
            IMemoryCache cache,
            IDistributedCache distributedCache)
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
            _clientFactory = httpClientFactory;
            _cache = cache;
            _distributedCache = distributedCache;
        }

        // GET api/<TodoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> Get(int id)
        {
            throw new Exception($"test exception");
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
            await _distributedCache.SetStringAsync("testdistributed", "ddd");
            DateTime cacheEntry;
            if (!_cache.TryGetValue(CacheKeys.Entry, out cacheEntry))
            {
                cacheEntry = DateTime.Now;
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(3));
                _cache.Set(CacheKeys.Entry, cacheEntry, cacheEntryOptions);
            }
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

        [HttpPost("ClientPost")]
        public async Task OnPost([FromBody] TodoItem todoItem)
        {
            var todoItemJson = new StringContent(
        JsonSerializer.Serialize(todoItem),Encoding.UTF8,
        "application/json");

            using var httpResponse =
                await _clientFactory.CreateClient().PostAsync("/api/TodoItems", todoItemJson);

            httpResponse.EnsureSuccessStatusCode();
        }

        [HttpPut("ClientPut")]
        public async Task SaveItemAsync(TodoItem todoItem)
        {
            var todoItemJson = new StringContent(
                JsonSerializer.Serialize(todoItem),
                Encoding.UTF8,
                "application/json");

            using var httpResponse =
                await _clientFactory.CreateClient().PutAsync($"/api/TodoItems/{todoItem.Id}", todoItemJson);

            httpResponse.EnsureSuccessStatusCode();
        }

        [HttpDelete("ClientDelete")]
        public async Task DeleteItemAsync(long itemId)
        {
            using var httpResponse =
                await _clientFactory.CreateClient().DeleteAsync($"/api/TodoItems/{itemId}");

            httpResponse.EnsureSuccessStatusCode();
        }

        //[Authorize]
        //public IActionResult BannerImage()
        //{
        //    var filePath = Path.Combine(
        //        AppContext.BaseDirectory, "MyStaticFiles", "images", "red-rose.jpg");

        //    return PhysicalFile(filePath, "image/jpeg");
        //}

        [HttpGet("syncget")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IEnumerable<TodoItem> GetTodoItems()
        {
            var todoItems = _todoContext.TodoItems.ToList();
            foreach (var item in todoItems)
            {
                if (item.IsComplete)
                {
                    yield return item;
                }
            }
        }

        [HttpGet("asyncget")]
        public async IAsyncEnumerable<TodoItem> GetTodoItemsAsync()
        {
            var todoItems =  _todoContext.TodoItems.AsAsyncEnumerable();
            await foreach (var item in todoItems)
            {
                if (item.IsComplete)
                {
                    yield return item;
                }
            }
        }
    }
}
