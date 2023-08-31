using ecommerce.Dto.Results.Admin.Pages.Query;
using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecommerce.Dto.Results.User.Auth.Command;
using ecommerce.user.Features.Auth.Commands.Models;

using ecommerce.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace ecommerce.user.Mapper.User.Auth
{
    public class AuthMapper:Profile
    {


        public AuthMapper() {


            CreateMap<AddUserCommand, IdentityUser<Guid>>();
            CreateMap<AddUserCommand, ecommerce.Domain.Entities.User>();

        }

        
    }
}
