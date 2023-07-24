using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecommerce.Domain.Entities;
using tables.Entities;
using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Reflection.Emit;
using ecommerce.Domain.Base.Entity;
using ecommerce.Domain.Abstract;

namespace ecommerce.infrutructure
{
    public class ApplicationDbContext: IdentityDbContext<Account<Guid>, IdentityRole<Guid>,Guid> 
    {

        public ApplicationDbContext(DbContextOptions option):base(option)
        {
            

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.Ignore<IdentityUserLogin<Guid>>();
            builder.Ignore<IdentityUserRole<Guid>>();
            builder.Ignore<IdentityUserClaim<Guid>>();
            builder.Ignore<IdentityUserToken<Guid>>();
            builder.Ignore<IdentityUser<Guid>>();



        }

        public DbSet<Banner> Banners { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> User { get; set; }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Copon> Copons { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Currency> Currencies { get; set; }
//        public DbSet<Image> Images { get; set; }
        public DbSet<Page> Pages { get; set; }

        public DbSet<Product> Products { get; set; }


        public DbSet<ProductProperty> ProductProperties { get; set; }       

        public DbSet<Property> Properties { get; set; }


        public DbSet<Review> Reviews { get; set; }

        public DbSet<Slider> Sliders { get; set; }
//        public DbSet<TageablePivot> TageablePivots { get; set; }


        public DbSet<Wishlist> Wishlists { get; set; }









    }
}
