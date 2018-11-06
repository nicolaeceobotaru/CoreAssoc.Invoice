using System;
using System.Data.Entity.Core;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace CoreAssoc.Invoice.Api.Filters
{
    public class ApiErrorFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception.InnerException is ObjectNotFoundException)
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.NotFound);
                return;
            }

            if (context.Exception is UnauthorizedAccessException)
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                return;
            }

            context.Response = new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
    }
}