using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.DIServices
{
    public interface IOperation
    {
        string OperationId { get; }
    }

    public interface IOperationTransien : IOperation
    {
    }

    public interface IOperationScope : IOperation
    {
    }

    public interface IOperationSingleton : IOperation
    {
    }
}
