using AdminEntity=ecommerce.Domain.Entities.Identity.Admin;
using Repositories.Base.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecommerce.infrutructure;

namespace Repositories.Admin
{
    public class AdminRepository :  GenericRepository<AdminEntity>, IAdminRepository
    {
        public AdminRepository(ApplicationDbContext DbContext) : base(DbContext)
        {
        }

        public bool CheckEmailExists(string email)
        {

            return DbContext.Accounts.OfType<AdminEntity>().Any(a => a.Email.Equals(email));

        }


    }
}
