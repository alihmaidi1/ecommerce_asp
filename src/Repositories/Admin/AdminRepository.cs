using AdminEntity=ecommerce.Domain.Entities.Identity.Admin;
using RoleEntity = ecommerce.Domain.Entities.Identity.Role;

using Repositories.Base.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecommerce.infrutructure;
using ecommerce.Domain.Enum;
using Microsoft.AspNetCore.Identity;
using AccountEntity=ecommerce.Domain.Entities.Identity.Account;
using ecommerce.Domain.Entities.Identity;

namespace Repositories.Admin
{
    public class AdminRepository :  GenericRepository<AdminEntity>, IAdminRepository
    {

        public UserManager<AccountEntity> UserManager;
        public RoleManager<RoleEntity> RoleManager;

        public AdminRepository(RoleManager<RoleEntity> RoleManager,ApplicationDbContext DbContext, UserManager<AccountEntity> UserManager) : base(DbContext)
        {

            this.RoleManager=RoleManager;
            this.UserManager=UserManager;
        }

        public bool CheckEmailExists(string email)
        {

            return DbContext.Accounts.OfType<AdminEntity>().Any(a => a.Email.Equals(email));

        }

        public bool IsUniqueUserName(string userName)
        {

            return !DbContext.Accounts.Any(x => x.UserName.Equals(userName));

        }

        public List<AdminEntity> GetAllForSuperAdmin()
        {
            return DbContext.Admins.
                Where(a =>
                !a.UserName.Equals(RoleEnum.SuperAdmin.ToString())&&
                a.UserName.Equals(RoleEnum.DeliveryMan.ToString()) 
                )
                .ToList();



        }


        public async Task<AdminEntity> Store(string Email, string UserName, string Password,Guid RoleId)
        {


            AdminEntity Admin=new AdminEntity();
            Admin.Email = Email;
            Admin.PasswordHash = UserManager.PasswordHasher.HashPassword(Admin, Password);
            Admin.UserName=UserName;
            Admin.SecurityStamp = "sdfsdfsfdahfshjfkakfsdhfs";
            DbContext.Admins.Add(Admin);
            DbContext.SaveChanges();
            var Role = await RoleManager.FindByIdAsync(RoleId.ToString());

            var result=await UserManager.AddToRoleAsync(Admin, "Base Admin");
            if (result.Succeeded)
            {

                return Admin;

            }
            throw new Exception(result.Errors.ToString());

        }


    }
}
