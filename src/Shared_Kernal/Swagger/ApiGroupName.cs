using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_shared.Swagger
{
    public enum ApiGroupName
    {

        [GroupInfoAttribute(Title = "All Title", Description = "All Description", Version ="v1")]
        All = 0,

        [GroupInfoAttribute(Title = "Dashboard Title", Description = "Dashboard Title", Version = "v1")]
        SuperAdmin = 1,

        [GroupInfoAttribute(Title = "DeliveryMan Title", Description = "DeliveryMan Description", Version = "v1")]
        DeliveryMan = 2,

        [GroupInfoAttribute(Title = "User Title", Description = "User Dexcription", Version = "v1")]
        User = 3,
    }
}
