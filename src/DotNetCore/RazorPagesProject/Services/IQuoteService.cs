using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesProject.Services
{
    public interface IQuoteService
    {
        Task<string> GenerateQuote();
    }
}
