using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace GrpcUnitTest.Helpers
{
    public class TestAsyncStreamReader<T> : IAsyncStreamReader<T> where T : class
    {
        private readonly Channel<T> _channel;
        private readonly ServerCallContext _serverCallContext;

        public T Current { get; private set; } = null!;

        public TestAsyncStreamReader(ServerCallContext serverCallContext)
        {
            _serverCallContext = serverCallContext;
            _channel = Channel.CreateUnbounded<T>();
        }

        public void AddMessage(T message)
        {
            if (!_channel.Writer.TryWrite(message))
            {
                throw new InvalidOperationException("Unable to write message.");
            }
        }

        public void Complete()
        {
            _channel.Writer.Complete();
        }

        public async Task<bool> MoveNext(CancellationToken cancellationToken)
        {
            _serverCallContext.CancellationToken.ThrowIfCancellationRequested();
            if (await _channel.Reader.WaitToReadAsync() && _channel.Reader.TryRead(out T message))
            {
                Current = message;
                return true;
            }
            else
            {
                Current = null!;
                return false;
            }
        }
    }
}
