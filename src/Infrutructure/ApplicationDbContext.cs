using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ecommerce.Domain.Entities.BrandEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ecommerce.Domain.Entities.Identity;
using EntityFrameworkCore.EncryptColumn.Interfaces;
using EntityFrameworkCore.EncryptColumn.Util;
using EntityFrameworkCore.EncryptColumn.Extension;
using ecommerce.Domain.Entities.Brand;
using ecommerce.Domain.Entities.Category;
using ecommerce.Domain.Entities.City;
using ecommerce.Domain.Entities.Country;
using ecommerce.Domain.Entities.Coupon;
using ecommerce.Domain.Entities.Currency;
using ecommerce.Domain.Entities.Slider;
using ecommerce.Domain.Entities.Product;
using ecommerce.Domain.Entities.Page;
using ecommerce.Domain.Entities.Cart;
using ecommerce.Domain.Entities.Wishlist;
using ecommerce.Domain.Entities.Review;
using ecommerce.Domain.Entities.Property;

namespace ecommerce.infrutructure
{
    public class ApplicationDbContext : IdentityDbContext<Account, Role, Guid,IdentityUserClaim<Guid>, UserRole, IdentityUserLogin<Guid>, RoleClaim, IdentityUserToken<Guid>>
    {

        public IEncryptionProvider EncryptionProvider { get; set; }

        public ApplicationDbContext(DbContextOptions option):base(option)
        {

            EncryptionProvider = new GenerateEncryptionProvider("45sdfow342joir53");
            

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.UseEncryption(EncryptionProvider);

            
            base.OnModelCreating(builder);

        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }


        public DbSet<Brand> Brands { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Coupon> Copons { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Currency> Currencies { get; set; }

        public DbSet<Page> Pages { get; set; }

        public DbSet<Product> Products { get; set; }


        public DbSet<ProductProperty> ProductProperties { get; set; }

        public DbSet<Property> Properties { get; set; }


        public DbSet<Review> Reviews { get; set; }

        public DbSet<Slider> Sliders { get; set; }


        public DbSet<Wishlist> Wishlists { get; set; }









    }
}
