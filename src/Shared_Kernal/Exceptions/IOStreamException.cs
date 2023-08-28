using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_shared.Exceptions
{
    public class IOStreamException:Exception
    {

        public IOStreamException(string message): base("IOStream Error :( : "+message)
        {
        
        }

    }
}
