using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SpeedModeTransportApi.Dto;

namespace SpeedModeTransportApi.Helpers
{
    public class HttpResultFactory
    {
        public static HttpResponseDto Error(ModelStateDictionary modelState)
        {
            var sb = new StringBuilder();
            foreach (var value in modelState.Values)
                foreach (var error in value.Errors)
                {
                    if (!String.IsNullOrEmpty(error.ErrorMessage))
                        sb.AppendLine(error.ErrorMessage);
                    else if (error.Exception != null)
                        sb.AppendLine(error.Exception.Message);
                }
            return new HttpResponseDto()
            {
                Status = "error",
                Message = sb.ToString().Trim(new char[] { '\n', '\r' })
            };
        }

        public static HttpResponseDto Error()
        {
            return new HttpResponseDto()
            {
                Status = "error",
                Message = "Error"
            };
        }


        public static HttpResponseDto Error(string message)
        {
            return new HttpResponseDto()
            {
                Status = "error",
                Message = message
            };
        }

        public static HttpResponseDto Error(IdentityResult result)
        {
            var sb = new StringBuilder();
            if (result.Errors != null)
                foreach (var error in result.Errors)
                    sb.AppendLine($"{error.Code} - {error.Description}");
            return new HttpResponseDto()
            {
                Status = "error",
                Message = sb.ToString().Trim(new char[] { '\n', '\r' })
            };
        }

        public static HttpResponseDto Error(Exception e)
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine(e.Message);
            if (e.InnerException != null && !String.IsNullOrWhiteSpace(e.InnerException.Message))
                sb.AppendLine(e.InnerException.Message);
            return new HttpResponseDto()
            {
                Status = "error",
                Message = sb.ToString().Trim(new char[] { '\n', '\r' })
            };
        }

        public static HttpResponseDto Ok<T>(T value)
        {
            return new HttpResponseDto()
            {
                Status = "ok",
                Result = value
            };
        }

        public static HttpResponseDto Ok()
        {
            return new HttpResponseDto()
            {
                Status = "ok",
                Result = ""
            };
        }
    }
}
