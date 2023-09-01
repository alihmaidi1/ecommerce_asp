using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_shared.Helper
{
    public static class ExceptionHelper
    {

        public static void ThrowIfTrue(this bool condition,string message)
        {

            if (condition)
            {

                throw new Exception(message);
            }

        }

    }
}
