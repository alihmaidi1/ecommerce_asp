using CityEntity=ecommerce.Domain.Entities.City;
using Repositories.Base.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecommerce.infrutructure;
using ecommerce.infrutructure.ExtensionMethod;

namespace Repositories.City
{
    public class CityRepository : GenericRepository<CityEntity>, ICityRepository
    {
        public CityRepository(ApplicationDbContext DbContext) : base(DbContext)
        {
        }


        public bool IsCityIdExists(Guid id)
        {

            return DbContext.Cities.Any(c => c.Id == id);

        }


        public bool Toggle(Guid id)
        {

            DbContext.Toggle("Cities", "Status", id);
            return true;


        }



    }
}
