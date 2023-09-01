using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_shared.Exceptions
{
    public class CannotSendEmailException:Exception
    {

        public CannotSendEmailException(string message):base(message) {
        
        }   
    }
}
