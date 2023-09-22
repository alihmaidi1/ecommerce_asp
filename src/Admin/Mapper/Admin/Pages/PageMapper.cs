//using AutoMapper;
//using ecommerce.admin.Pages.Commands.Models;
//using ecommerce.Domain.Entities.Page;
//using ecommerce.Dto.Results.Admin.Pages;
//using ecommerce.Dto.Results.Admin.Pages.Command;
//using ecommerce.Dto.Results.Admin.Pages.Query;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ecommerce.Dto.Mapper.Admin.Pages
//{
//    public class PageMapper:Profile
//    {

//        public PageMapper() {

//            GetAllPageResult();

//            GetPageByIdResult();
//            AddPageDto();
//        }


//        public void GetAllPageResult()
//        {

//            CreateMap<Page, GetAllPagesResult>();



//        }

//        public void GetPageByIdResult()
//        {
//            CreateMap<Page, GetPageByIdResult>();

//        }

//        public void AddPageDto()
//        {
//            CreateMap<AddPageCommand, Page>();

//        }
//    }
//}
