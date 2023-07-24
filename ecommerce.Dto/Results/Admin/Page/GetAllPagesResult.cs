using ecommerce.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.admin.Pages.Queries.Result
{
    public class GetAllPagesResult
    {


        public PageName Name { get; set; }

        public string Content { get; set; }

        public Guid Id { get; set; }


    }
}
