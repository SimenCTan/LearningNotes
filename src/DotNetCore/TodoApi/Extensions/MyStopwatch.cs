using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Extensions
{
    public class MyStopwatch : IDisposable
    {
        ILogger<Startup> _logger;
        string _message;
        Stopwatch _sw;

        public MyStopwatch(ILogger<Startup> logger, string message)
        {
            _logger = logger;
            _message = message;
            _sw = Stopwatch.StartNew();
        }

        private bool disposed = false;
        public void Dispose()
        {
            if (!disposed)
            {
                _logger.LogInformation("{Message }: {ElapsedMilliseconds}ms",
                                        _message, _sw.ElapsedMilliseconds);

                disposed = true;
            }
        }
    }
}
