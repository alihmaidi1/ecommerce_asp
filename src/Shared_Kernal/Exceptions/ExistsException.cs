using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_shared.Exceptions
{
    public class ExistsException:Exception
    {

        public ExistsException(string entity):base($"the {entity} entity is exists in our data") { 
        
        }

    }
}
