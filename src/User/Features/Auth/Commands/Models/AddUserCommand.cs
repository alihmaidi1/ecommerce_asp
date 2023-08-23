using ecommerce.Domain.Entities;
using ecommerce.Dto.Results.User.Auth.Command;
using ecommerce_shared.OperationResult.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.user.Features.Auth.Commands.Models
{
    public class AddUserCommand:IRequest<JsonResult>
    {

        public string Username { get; set; }
        public string Password { get; set; }    
        public string Email { get; set; }
        public string Name { get; set; }

        public Guid CityId { get; set; }

    }
}
