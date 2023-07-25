using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_shared.Exceptions
{
    public  class NotFoundException:Exception
    {
        public NotFoundException(string entiy):base($"the {entiy} entity is not exists in our data") {
        
        }

    }
}
