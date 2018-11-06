using System.Web.Http.Filters;
using System.Web.Mvc;
using CoreAssoc.Invoice.Api.Filters;

namespace CoreAssoc.Invoice.Api
{
    public class FilterConfig
    {

        public static void RegisterApiGlobalFilters(HttpFilterCollection filters)
        { 
            filters.Add(new ApiErrorFilterAttribute());
        }
    }
}
