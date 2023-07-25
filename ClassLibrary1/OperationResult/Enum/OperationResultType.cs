using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_shared.OperationResult.Enum
{
    public enum OperationResultTypes
    {
        Success,
        Exist,
        NotExist=429,
        Failed,
        Forbidden,
        Exception,
        Unauthorized
    }
}
