using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Domain.AppMetaData.SuperAdmin
{
    public static class CategoryRouter
    {

        private const string prefix = Router.Rule + "category";
        public const string Store= prefix + "/store";
        public const string GetAll = prefix + "/getAll";
        public const string Update = prefix + "/update";




    }
}
