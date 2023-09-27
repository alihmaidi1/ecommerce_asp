<<<<<<< HEAD
﻿using BrandEntity = ecommerce.Domain.Entities.Brand.Brand;
using System;
=======
﻿using System;
>>>>>>> ed
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandTable=ecommerce.Domain.Entities.BrandEntities.Brand;
using Repositories.Base;
using ecommerce.Dto.Results.Admin.Brand;
using ecommerce.models.SuperAdmin.Brand.Commands;
using ecommerce_shared.File;
using ecommerce_shared.Pagination;
using ecommerce.Domain.Entities.Brand;

namespace Repositories.Brand
{
<<<<<<< HEAD
    public interface IBrandRepository : IgenericRepository<BrandEntity>
=======
    public interface IBrandRepository:IgenericRepository<BrandTable>
>>>>>>> ed
    {


        public bool IsNameExists(string Name);
        public bool IsExists(BrandId Id);
        public bool IsValidLogo(BrandId Id, string logo);


<<<<<<< HEAD
        public BrandEntity Get(BrandId Id);
=======
        public BrandTable Get(Guid Id);     
>>>>>>> ed

        public bool IsUniqueName(BrandId Id, string Name);

<<<<<<< HEAD
        public Task<BrandEntity> Update(UpdateBrandCommand brand);
        public Task<PageList<AddBrandResponse>> GetAll(string? OrderBy, int? pageNumber, int? pageSize);
=======
        public Task<BrandTable> Update(UpdateBrandCommand brand);
        public Task<PageList<AddBrandResponse>> GetAll(string? OrderBy,int? pageNumber, int? pageSize);
>>>>>>> ed


        public bool Delete(BrandId Id);

    }
}
