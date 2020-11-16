using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcMovies.Data;
using MvcMovies.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovies.ViewComponents
{
    public class PriorityListViewComponent : ViewComponent
    {
        private readonly MovieDbContext db;

        public PriorityListViewComponent(MovieDbContext context)
        {
            db = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(
        int maxPriority, int maxId)
        {
            var items = await GetItemsAsync(maxPriority, maxId);
            return View(items);
        }
        private Task<List<Movie>> GetItemsAsync(int maxPriority, int maxId)
        {
            return db.Movie.Where(x => x.ID <maxId &&
                                 x.Price <= maxPriority).ToListAsync();
        }
    }

}
