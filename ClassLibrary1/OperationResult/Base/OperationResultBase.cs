using Azure;
using ecommerce_shared.OperationResult.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_shared.OperationResult.Base
{
    public class OperationResultBase<T>
    {
        public T Result { get; set; }

        public string Message { get; set; }


        public Exception Exception { get; set; }

        public int? StatusCode { get; set; }



    }
}
