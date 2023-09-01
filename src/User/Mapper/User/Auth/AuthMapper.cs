using ecommerce.Dto.Results.Admin.Pages.Query;
using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecommerce.Dto.Results.User.Auth.Command;
using ecommerce.user.Features.Auth.Commands.Models;
<<<<<<< HEAD
using ecommerce.Domain.Entities.Identity;
=======

using ecommerce.Domain.Entities;
using Microsoft.AspNetCore.Identity;
>>>>>>> 90bac4133691690d5adc946ac38d3faf668d9f45

namespace ecommerce.user.Mapper.User.Auth
{
    public class AuthMapper:Profile
    {


        public AuthMapper() {


<<<<<<< HEAD
            CreateMap<AddUserCommand, Account>();
            CreateMap<AddUserCommand, Domain.Entities.Identity.User>();
=======
            CreateMap<AddUserCommand, IdentityUser<Guid>>();
            CreateMap<AddUserCommand, ecommerce.Domain.Entities.User>();
>>>>>>> 90bac4133691690d5adc946ac38d3faf668d9f45

        }

        
    }
}
