using ecommerce.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tables.Base.Entity;

namespace ecommerce.Domain.Entities;

    public class Coupon :BaseEntity
    {

        public Coupon()
        {

            Products=new HashSet<Product>();

        }
        public string Name { get; set; }
        public CoponType Type{ get; set; } 

        public float Value { get; set; }


        public DateTime EndAt { get; set; }

        public virtual ICollection<Product> Products{ get; set; }

    }

