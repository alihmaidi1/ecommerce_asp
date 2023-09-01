using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_shared.Extension
{
    public static class StringExtension
    {
        public static string GenerateCode(this string str)
        {

            Random random = new Random();   
            return random.Next(0,1000000).ToString("D6");

        }

    }
}
