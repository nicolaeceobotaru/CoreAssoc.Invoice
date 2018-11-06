using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using CoreAssoc.Invoice.Data.Database;
using CoreAssoc.Invoice.Data.Entities;

namespace CoreAssoc.Invoice.Business.Authorization
{
    public class AuthorizationLogic : IAuthorizationLogic
    {
        private readonly IRepository _repository;

        public AuthorizationLogic(IRepository repository)
        {
            _repository = repository;
        }

        public bool IsAuthorized(HttpActionContext actionContext, Type currentControllerType)
        {
            var token = GetApiKeyFromHeader(actionContext);
            if (String.IsNullOrEmpty(token))
                return false;
            var user = _repository.Query<User>().FirstOrDefault(usr => usr.ApiKey == token);

            if (user == null)
                return false;

            if ((actionContext.Request.Method == HttpMethod.Post || actionContext.Request.Method == HttpMethod.Put)
                && actionContext.ControllerContext.Controller.GetType() == currentControllerType
                && user.Role != UserRole.Admin)
                return false;

            return true;
        }

        protected virtual string GetApiKeyFromHeader(HttpActionContext actionContext)
        {
            try
            {
                return actionContext.Request.Headers.GetValues("API-key").FirstOrDefault();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
