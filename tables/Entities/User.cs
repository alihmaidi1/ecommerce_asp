using ecommerce.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Domain.Entities
{
    [Table("Users")]
    public class User:Account
    {

        public string Name { get; set; }
         
        [Range(0,Double.MaxValue)]
        public int Point { get; set; }
        public City City { get; set; }
        public Guid AccountId { get; set; }

    }
}
