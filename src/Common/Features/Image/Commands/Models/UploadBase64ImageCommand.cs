using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Features.Image.Commands.Models
{
    public class UploadBase64ImageCommand:IRequest<JsonResult>
    {


        public string Image { get; set; }

    }
}
