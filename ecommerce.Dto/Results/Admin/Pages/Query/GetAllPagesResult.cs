using ecommerce.Domain.Entities;
using ecommerce.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Dto.Results.Admin.Pages.Query
{
    public class GetAllPagesResult
    {


        public PageName Name { get; set; }

        public string Content { get; set; }

        public Guid Id { get; set; }

        public GetAllPagesResult(Guid id,PageName Name,string Content)
        {
            this.Id = id;
            this.Name = Name;
            this.Content = Content;

        }

        public static Expression<Func<Page, GetAllPagesResult>> GetAllPage => page => new GetAllPagesResult(page.Id,page.Name,page.Content);

    }
}
