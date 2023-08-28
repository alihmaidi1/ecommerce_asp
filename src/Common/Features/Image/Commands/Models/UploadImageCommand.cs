using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Features.Image.Commands.Models
{
    public class UploadImageCommand:IRequest<JsonResult>
    {

        [DataType(DataType.Upload)]
        public IFormFile Image { get; set; }

    }
}
