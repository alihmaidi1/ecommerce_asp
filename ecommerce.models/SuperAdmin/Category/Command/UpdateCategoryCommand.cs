using ecommerce.Domain.Entities.Category;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.models.SuperAdmin.Category.Command
{
    public class UpdateCategoryCommand:IRequest<JsonResult>
    {

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Rank { get; set; }

        public string? Meta_Title { get; set; }

        public string? Meta_Description { get; set; }

        public List<string> Images { get; set; }
        public List<string> DeletedImages { get; set; }


        public Guid? ParentId { get; set; }

    }
}
