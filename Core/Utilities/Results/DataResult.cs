using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data, bool succeess, string message) : base(true, message)
        {
            Data = data;
        }
        public DataResult(T data, bool succeess) : base(true)
        {
            Data = data;
        }

        public T Data { get; }

    }
}
