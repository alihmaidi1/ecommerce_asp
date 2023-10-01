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
using ecommerce.Dto.Results.Admin.Admin;
using Repositories.Role.Store;
using Microsoft.EntityFrameworkCore;
using Nest;
using Repositories.Admin.Store;

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


        public bool IsUniqueUserName(string userName)
        {

            return !DbContext.Accounts.Any(x => x.UserName.Equals(userName));

        }


        public List<AdminEntity> GetAllForSuperAdmin()
        {
            return DbContext.Admins.
                Where(a =>
                !a.UserName.Equals(RoleEnum.SuperAdmin.ToString())&&
                !a.UserName.Equals(RoleEnum.DeliveryMan.ToString()) 
                )
                .ToList();



        }


        public async Task<GetAdminQueryResponse> Store(string Email, string UserName, string Password,Guid RoleId)
        {


            AdminEntity Admin=new AdminEntity();
            Admin.Email = Email;
            Admin.PasswordHash = UserManager.PasswordHasher.HashPassword(Admin, Password);
            Admin.UserName=UserName;
            Admin.SecurityStamp = "sdfsdfsfdahfshjfkakfsdhfs";
            DbContext.Admins.Add(Admin);
            DbContext.SaveChanges();
            var Role = await RoleManager.FindByIdAsync(RoleId.ToString());
            var result=await UserManager.AddToRoleAsync(Admin, Role.Name);
            if (result.Succeeded)
            {
                
                return AdminStoreQuery.ToAdminQueryResponse.Compile()(Admin);
            }
            throw new Exception(result.Errors.ToString());

        }

        public bool isExists(Guid Id)
        {


            return DbContext.Admins.Where(a =>
                !a.UserName.Equals(RoleEnum.SuperAdmin.ToString()) &&
                !a.UserName.Equals(RoleEnum.DeliveryMan.ToString())
                ).Any(x=>x.Id==Id);

        }


        public bool BlockAdmin(Guid Id)
        {


            DbContext.
            Admins.
            Where(x => x.Id == Id).
            ExecuteUpdate(setter=>
            setter.SetProperty(b=>b.IsBlocked,true)
            );

            return true;

        }


        public bool UnBlockAdmin(Guid Id)
        {


            DbContext.
            Admins.
            Where(x => x.Id == Id).
            ExecuteUpdate(setter =>
            setter.SetProperty(b => b.IsBlocked, false)
            );

            return true;

        }


        public AdminEntity Get(Guid Id)
        {


            return DbContext.Admins.FirstOrDefault(x => x.Id == Id);


        }

        public bool IsUniqueEmail(string email,Guid Id)
        {
            return !DbContext.Accounts.OfType<AdminEntity>().Any(a => a.Email.Equals(email) && a.Id != Id);

        }

        public bool CheckEmailExists(string email)
        {
            return DbContext.Accounts.OfType<AdminEntity>().Any(a => a.Email.Equals(email));

        }

        public bool IsUniqueUserName(string userName, Guid Id)
        {

            return !DbContext.Accounts.Any(x => x.UserName.Equals(userName)&& x.Id!=Id);

        }
 
        public async Task<AdminEntity> Update(Guid id,string Email, string UserName, string Password, Guid RoleId)
        {
            AdminEntity admin = DbContext.Admins.FirstOrDefault(x => x.Id == id);
            admin.Email = Email;
            admin.UserName= UserName;
            admin.PasswordHash = UserManager.PasswordHasher.HashPassword(admin, Password);
            DbContext.Admins.Update(admin);
            DbContext.SaveChanges();
            DbContext.UserRoles.Where(x => x.UserId == id).ExecuteDelete();
            DbContext.UserRoles.Add(new UserRole { RoleId = RoleId ,UserId=id});
            DbContext.SaveChanges();

            return admin;

        }

    }
}
