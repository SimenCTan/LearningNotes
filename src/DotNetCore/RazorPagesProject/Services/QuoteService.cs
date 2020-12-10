using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesProject.Services
{
    public class QuoteService : IQuoteService
    {
        public Task<string> GenerateQuote()
        {
            return Task.FromResult<string>(
                "Come on, Sarah. We've an appointment in London, " +
                "and we're already 30,000 years late.");
        }
    }
}
