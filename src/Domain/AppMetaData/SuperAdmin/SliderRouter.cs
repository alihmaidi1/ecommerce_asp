using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Domain.AppMetaData.SuperAdmin
{
    public static class SliderRouter
    {


        private const string prefix = Router.Rule + "slider";
        public const string Store = prefix + "/store";
        public const string GetAll = prefix + "/getAll";
        public const string Get = prefix + "/{id:guid}/get";
        public const string Update = prefix + "/update";
        public const string Delete = prefix + "/{id:guid}/delete";





    }
}
