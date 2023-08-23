using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_shared.Exceptions
{
     public class CanotCreateAccountException: Exception
    {

        public CanotCreateAccountException(IEnumerable<IdentityError> ErrorList) :base(CustomMessage(ErrorList)) 
        {


            
        }


        public static string CustomMessage(IEnumerable<IdentityError> ErrorList)
        {

            string error = String.Join(",\n", ErrorList.Select(error => error.Description));
            return error;

        }
    }
}
