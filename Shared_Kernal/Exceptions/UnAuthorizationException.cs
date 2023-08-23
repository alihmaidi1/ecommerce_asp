using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_shared.Exceptions
{
    public class UnAuthorizationException:Exception
    {


        public UnAuthorizationException():base("You Are Don't have permission to do this action") { 
        
        }
    }
}
