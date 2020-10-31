using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.CustomLoggers
{
    public class ColorConsoleLoggerProvider : ILoggerProvider
    {
        private readonly ColorConsoleLoggerConfiguration _config;
        private readonly ConcurrentDictionary<string, ColorConsoleLogger> _logger = new ConcurrentDictionary<string, ColorConsoleLogger>();
        public ColorConsoleLoggerProvider(ColorConsoleLoggerConfiguration config)
        {
            _config = config;
        }
        public ILogger CreateLogger(string categoryName)
        {
            return _logger.GetOrAdd(categoryName, name => new ColorConsoleLogger(name, _config));
        }

        public void Dispose()
        {
            _logger.Clear();
        }
    }
}
