using ecommerce.Domain.Base.Interfaces;
using PropertyEntity=ecommerce.Domain.Entities.Property.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tables.Base.Entity;
using ReviewEntity=ecommerce.Domain.Entities.Review.Review;
using BrandEntity=ecommerce.Domain.Entities.Brand.Brand;
using CouponEntity=ecommerce.Domain.Entities.Coupon.Coupon;
using CategoryEntity=ecommerce.Domain.Entities.Category.Category;
using ecommerce.Domain.Entities.Category;
using ecommerce.Domain.Entities.Brand;
using ecommerce.Domain.Entities.Coupon;

namespace ecommerce.Domain.Entities.Product;

public class Product : BaseEntity<ProductId>
{

    public Product()
    {

        Properties = new HashSet<PropertyEntity>();
        Images = new HashSet<ImageProduct>();
        Reviews = new HashSet<ReviewEntity>();
        Id=new ProductId(Guid.NewGuid());


    }


    public string Name { get; set; }
    public string Title { get; set; }

    public virtual ICollection<ImageProduct> Images { get; set; }


    public string Description { get; set; }

    public string MetaTitle { get; set; }

    public string MetaDescription { get; set; }

    public string MetaLogoUrl { get; set; }
    public string MetaLogoHash { get; set; }

    public string MetaLogoResized { get; set; }


    public CategoryId categoryId { get; set; }
    public virtual CategoryEntity Category { get; set; }

    public float Price { get; set; }


    public int Quantity { get; set; }

    public int MinQuantity { get; set; }

    public int SellingNumber { get; set; }

    public BrandId brandId { get; set; }

    public virtual BrandEntity? Brand { get; set; }


    public CouponId? couponId { get; set; }

    public virtual CouponEntity? Copon { get; set; }


    public virtual ICollection<PropertyEntity> Properties { get; set; }


    public virtual ICollection<ReviewEntity> Reviews { get; set; }








}

