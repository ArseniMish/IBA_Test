using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;

namespace SpeedModeTransport.WebApi.Filters
{
    public class WorkTimeAttribute : Attribute, IActionFilter
    {
        private readonly IConfiguration _configuration;

        public WorkTimeAttribute(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var startTime = Convert.ToDateTime(_configuration.GetValue<string>("StartTime"));
            var endTime = Convert.ToDateTime(_configuration.GetValue<string>("EndTime"));


            if (DateTime.Now < startTime || DateTime.Now > endTime)
            {
                context.Result = new BadRequestObjectResult($"Sorry, but service work from {startTime} to {endTime}. Try again later.");
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
