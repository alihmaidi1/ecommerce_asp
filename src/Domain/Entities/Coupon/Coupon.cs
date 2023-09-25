using ProductEntity=ecommerce.Domain.Entities.Product.Product;
using ecommerce.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tables.Base.Entity;

namespace ecommerce.Domain.Entities.Coupon;

public class Coupon :BaseEntity<CouponId>
    {

        public Coupon()
        {

            Products=new HashSet<ProductEntity>();
            Id = new CouponId(Guid.NewGuid());

        }
        public string Name { get; set; }
        public CoponType Type{ get; set; } 

        public float Value { get; set; }


        public DateTime EndAt { get; set; }

        public virtual ICollection<ProductEntity> Products{ get; set; }

    }

