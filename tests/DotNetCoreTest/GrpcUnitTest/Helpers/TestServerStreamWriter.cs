using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Grpc.Core;

namespace GrpcUnitTest.Helpers
{
    public class TestServerStreamWriter<T> : IServerStreamWriter<T> where T : class
    {
        private readonly ServerCallContext _serverCallContext;
        private readonly Channel<T> _channel;

        public WriteOptions WriteOptions { get; set; }

        public TestServerStreamWriter(ServerCallContext serverCallContext)
        {
            _channel = Channel.CreateUnbounded<T>();
            _serverCallContext = serverCallContext;
        }

        public void Complete()
        {
            _channel.Writer.Complete();
        }

        public IAsyncEnumerable<T> ReadAllAsync()
        {
            return _channel.Reader.ReadAllAsync();
        }

        public Task WriteAsync(T message)
        {
            throw new NotImplementedException();
        }
    }
}
