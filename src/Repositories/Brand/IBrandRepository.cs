using BrandEntity=ecommerce.Domain.Entities.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.Base;

namespace Repositories.Brand
{
    public interface IBrandRepository:IgenericRepository<BrandEntity>
    {


        public bool IsNameExists(string Name);

    }
}
