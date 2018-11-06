using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using Autofac.Integration.WebApi;
using CoreAssoc.Invoice.Api.Controllers;
using CoreAssoc.Invoice.Business.Authorization;

namespace CoreAssoc.Invoice.Api.Filters
{
    public class AuthorizationFilterAttribute : IAutofacAuthorizationFilter
    {
        private readonly IAuthorizationLogic _authorizationLogic;

        public AuthorizationFilterAttribute(IAuthorizationLogic authorizationLogic)
        {
            _authorizationLogic = authorizationLogic;
        }

        public void OnAuthorization(HttpActionContext actionContext)
        {
            var isAuthorized = _authorizationLogic.IsAuthorized(actionContext, typeof(InvoicesController));
            if (!isAuthorized)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        public Task OnAuthorizationAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            OnAuthorization(actionContext);
            return Task.FromResult<object>(null);
        }
    }
}