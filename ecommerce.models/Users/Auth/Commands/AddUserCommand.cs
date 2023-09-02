using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace ecommerce.models.Users.Auth.Commands
{
    public class AddUserCommand : IRequest<JsonResult>
    {

        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public Guid CityId { get; set; }


    }
}
