using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_shared.Exceptions
{
    public class UnAuthenticationException: Exception
    {


        public UnAuthenticationException():base("You Are Not Authentication Please Login To Your Account") {
        
        
            
        }
    }
}
