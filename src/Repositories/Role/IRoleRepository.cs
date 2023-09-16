
using ecommerce.Dto.Results.Admin.Role;
using ecommerce.models.SuperAdmin.Role.Query;
using Microsoft.EntityFrameworkCore.SqlServer.Internal;
using RoleEntity=ecommerce.Domain.Entities.Identity.Role;
namespace Repositories.Role
{
    public interface IRoleRepository
    {

        public  List<RoleEntity> GetAllRole();
        public bool IsExists(string Id);
        public bool IsUniqueWithId(string Id,string Name);



        public bool IsPermissionsExists(List<string> Permission);


        public bool IsIdExists(Guid id);
        public bool Delete(Guid id);

        public bool IsUnique(string Name);

        public Task<GetRoleResponse> GetRoleAsync(string Id);

        public List<string> GetAllPermission();


        public Task<GetRoleResponse> StoreRole(StoreRolecommand request);
        public Task<GetRoleResponse> UpdateRole(Guid Id,string Name,List<string> Permissions);

    }


}
