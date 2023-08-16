using ecommerce.Dto.Results.Admin.Pages.Query;
using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecommerce.Dto.Results.User.Auth.Command;
using ecommerce.user.Features.Auth.Commands.Models;
using ecommerce.Domain.Abstract;
using ecommerce.Domain.Entities;

namespace ecommerce.user.Mapper.User.Auth
{
    public class AuthMapper:Profile
    {


        public AuthMapper() {


            CreateMap<AddUserCommand, Account>();
            CreateMap<AddUserCommand, ecommerce.Domain.Entities.User>();

        }
    }
}
