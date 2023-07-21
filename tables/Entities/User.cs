using ecommerce.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Domain.Entities
{
    public class User:Account<Guid>
    {

        public string Name { get; set; }
        [Range(0,1000)]
        public int age { get; set; }
        [Range(0,Double.MaxValue)]
        public int Point { get; set; }

    }
}
