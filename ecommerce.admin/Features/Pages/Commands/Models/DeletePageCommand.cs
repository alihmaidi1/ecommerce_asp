using ecommerce_shared.OperationResult.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.admin.Features.Pages.Commands.Models
{
    public class DeletePageCommand: IRequest<OperationResultBase<bool>>
    {
 
        public Guid Id { get; set; }
    
    }
}
