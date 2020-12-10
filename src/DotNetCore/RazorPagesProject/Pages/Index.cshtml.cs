using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RazorPagesProject.Data;
using RazorPagesProject.Services;
using RazorPagesProject.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace RazorPagesProject.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly AppDbContext _appDbContext;
        private readonly IQuoteService _quoteService;

        public IndexModel(ILogger<IndexModel> logger, AppDbContext appDbContext,IQuoteService quoteService)
        {
            _appDbContext = appDbContext;
            _quoteService = quoteService;
            _logger = logger;
        }

        [BindProperty]
        public Message Message { get; set; }

        public IList<Message> Messages { get; private set; }

        [TempData]
        public string MessageAnalysisResult { get; set; }

        public string Quote { get; private set; }

        public async Task OnGetAsync()
        {
            Messages = await _appDbContext.Messages.ToListAsync();

            Quote = await _quoteService.GenerateQuote();
        }

        public async Task<IActionResult> OnPostAddMessageAsync()
        {
            if (!ModelState.IsValid)
            {
                Messages = await _appDbContext.Messages.ToListAsync();

                return Page();
            }

            _appDbContext.Messages.Add(Message);
            await _appDbContext.SaveChangesAsync();
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAllMessagesAsync()
        {
            await _appDbContext.Messages.ToListAsync();

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteMessageAsync(int id)
        {
            var message = await _appDbContext.Messages.FirstOrDefaultAsync(m => m.Id == id);
            if (message != null)
            {
                _appDbContext.Messages.Remove(Message);
                await _appDbContext.SaveChangesAsync();
            }
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostAnalyzeMessagesAsync()
        {
            Messages = await _appDbContext.Messages.ToListAsync();

            if (Messages.Count == 0)
            {
                MessageAnalysisResult = "There are no messages to analyze.";
            }
            else
            {
                var wordCount = 0;

                foreach (var message in Messages)
                {
                    wordCount += message.Text.Split(' ').Length;
                }

                var avgWordCount = Decimal.Divide(wordCount, Messages.Count);
                MessageAnalysisResult = $"The average message length is {avgWordCount:0.##} words.";
            }

            return RedirectToPage();
        }
    }
}
