using AutoMapper;
using ecommerce.Domain.Entities.Identity;
using ecommerce.models.Users.Auth.Commands;
namespace ecommerce.Dto.Mapper.User.Auth
{
    public class AuthMapper:Profile
    {

        public AuthMapper() {

            CreateMap<AddUserCommand, Domain.Entities.Identity.User>();

        }
    }
}
