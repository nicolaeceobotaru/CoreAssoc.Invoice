using System;
using System.Web.Http.Controllers;

namespace CoreAssoc.Invoice.Business.Authorization
{
    public interface IAuthorizationLogic
    {
        bool IsAuthorized(HttpActionContext actionContext, Type currentControllerType);
    }
}