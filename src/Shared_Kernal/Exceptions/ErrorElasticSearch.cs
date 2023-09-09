using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_shared.Exceptions
{
    public class ErrorElasticSearch: Exception
    {

        public ErrorElasticSearch(string message) : base(message)
        {

        }

    }
}
