using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.DIServices
{
    public class Operation : IOperationTransien, IOperationScope, IOperationSingleton
    {
        public Operation()
        {
            OperationId = Guid.NewGuid().ToString()[^4..];
        }
        public string OperationId { get; }
    }

}
