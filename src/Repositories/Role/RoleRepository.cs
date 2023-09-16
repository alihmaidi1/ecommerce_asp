using ecommerce.Domain.Entities.Identity;
using ecommerce.Domain.Enum;
using ecommerce.Dto.Results.Admin.Role;
using ecommerce.infrutructure;
using ecommerce.infrutructure.ExtensionMethod;
using ecommerce.models.SuperAdmin.Role.Query;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories.Role.Store;
using RoleEntity =ecommerce.Domain.Entities.Identity.Role;
namespace Repositories.Role
{
    public class RoleRepository:IRoleRepository
    {
        public RoleManager<RoleEntity> RoleManager;
        public ApplicationDbContext Context;
        public RoleRepository(RoleManager<RoleEntity> RoleManager, ApplicationDbContext Context) { 
        

            this.Context = Context;
            this.RoleManager = RoleManager;

        }



        public List<RoleEntity> GetAllRole()
        {
            
            var Roles=RoleManager.RoleWithoutSuperAdmin().ToList();
            return Roles;
        }


        public async Task<GetRoleResponse> GetRoleAsync(string Id)
        {

            //var Role= from r in Context.Roles
            //          where r.Id.Equals(Id)
            //          join rc in Context.RoleClaims on r.Id equals rc.RoleId
            //          select r;
            
            //var Role = RoleManager.FindByIdAsync(Id).Result;
            //var Claims=RoleManager.GetClaimsAsync(Role).Result.Select(c=>c.Value).ToList();
            //var RoleClaims = new GetRoleResponse { 
            //    Id = Role.Id,
            //    Name=Role.Name,
            //    Permissions=Claims
            //};
             

            return null;
        }


        public bool IsExists(string Id)
        {
            var isexsits= Context.Roles.Count(r=>r.Id==Guid.Parse(Id))!=0;
            return isexsits;
        }


        public List<string> GetAllPermission()
        {

            return Enum.GetNames(typeof(PermissionEnum)).ToList();

            

        }

        public bool IsUnique(string Name)
        {


            return Context.Roles.Count(r=>r.Name.Equals(Name))==0;


        }


        public bool IsPermissionsExists(List<string> Permission)
        {

            List<string> myRole=Enum.GetNames(typeof(PermissionEnum)).ToList();
            return Permission.All(x => myRole.Any(m => m.Equals(x)));
            


        }

        public async Task<GetRoleResponse> StoreRole(StoreRolecommand request)
        {

            var Role = new RoleEntity { Name = request.Name };
            Context.Roles.Add(Role);
            Context.SaveChanges();
            
            var permissions = request.Permissions.Select(x => new RoleClaim { ClaimValue = x,RoleId=Role.Id }).ToList();

            Context.RoleClaims.AddRange(permissions);
            Context.SaveChanges();
            return new GetRoleResponse
            {
                Id=Role.Id,
                Name=Role.Name,
                Permissions=request.Permissions

            };
        }


        public bool IsUniqueWithId(string Id, string Name)
        {



            return Context.
                Roles.
                Count(r => 
                r.Name.Equals(Name)&&
                r.Id!=Guid.Parse(Id)
                ) == 0;


        }



        public async Task<GetRoleResponse> UpdateRole(Guid Id, string Name, List<string> Permissions)
        {

            var Role=new RoleEntity { Id=Id,Name=Name};
            Context.Roles.Update(Role);
            Context.SaveChanges();
            Context.RoleClaims.Where(rc=>rc.RoleId==Role.Id).ExecuteDelete();
            List<RoleClaim>RoleCalim=Permissions.Select(p => new RoleClaim { ClaimValue = p, RoleId = Role.Id }).ToList();
            Context.RoleClaims.AddRange(RoleCalim);
            Context.SaveChanges();
            return new GetRoleResponse
            {

                Id=Role.Id,
                Name=Role.Name,
                Permissions=Permissions

            };


        }


        public bool IsIdExists(Guid id)
        {

            return Context.RoleWithoutBaseAdmins().Count(r => r.Id == id)!=0;
            

        }

        public bool Delete(Guid id)
        {

            Context.Remove(new RoleEntity { Id = id });
            Context.SaveChanges();
            return true;

        }




    }
}
