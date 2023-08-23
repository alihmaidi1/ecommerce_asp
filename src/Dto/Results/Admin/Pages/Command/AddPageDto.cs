using ecommerce.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Dto.Results.Admin.Pages.Command
{
    public class AddPageDto
    {
        public PageName Name { get; set; }

        public string Content { get; set; }



    }
}
