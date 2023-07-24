using AutoMapper;
using ecommerce.admin.Pages.Queries.Result;
using ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Dto.Mapper.Admin.Pages
{
    public class GetAllPagesProfile:Profile
    {

        public GetAllPagesProfile() {

            CreateMap<Page, GetAllPagesResult>();

        }
    }
}
