using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using SpeedModeTransportApi.Helpers;

namespace SpeedModeTransportApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ApiControllerBase : ControllerBase
    {
        protected ApiControllerBase()
        {
        }

        [NonAction]
        public new OkObjectResult Ok()
        {
            return base.Ok(HttpResultFactory.Ok());
        }

        [NonAction]
        public override OkObjectResult Ok(object value)
        {
            return base.Ok(HttpResultFactory.Ok(value));
        }

        [NonAction]
        public override ObjectResult Problem(
            string detail = null,
            string instance = null,
            int? statusCode = null,
            string title = null,
            string type = null)
        {
            return base.Ok(HttpResultFactory.Error(detail));
        }

        [NonAction]
        public override ActionResult ValidationProblem(
            string detail = null,
            string instance = null,
            int? statusCode = null,
            string title = null,
            string type = null,
            ModelStateDictionary modelStateDictionary = null)
        {
            return base.Ok(HttpResultFactory.Error(modelStateDictionary ?? ModelState));
        }
    }
}
