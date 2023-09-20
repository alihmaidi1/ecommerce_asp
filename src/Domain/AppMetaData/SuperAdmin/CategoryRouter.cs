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
        public const string GetAllAsTree = prefix + "/getAllAsTree";
        public const string Get = prefix + "/{id:guid}/get";

        public const string Update = prefix + "/update";
        public const string UnActive = prefix + "/{id:guid}/unactive";
        public const string ActiveCategory = prefix + "/{id:guid}/active";
        public const string Delete = prefix + "/{id:guid}/delete";




    }
}
