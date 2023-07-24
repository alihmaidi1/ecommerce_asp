using ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.service.Abstract
{
    public interface IPageService
    {

        public Task<List<Page>> GetPagesListAsync();

    }
}
