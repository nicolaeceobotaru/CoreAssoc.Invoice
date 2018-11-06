using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using CoreAssoc.Invoice.Api.Controllers;
using CoreAssoc.Invoice.Api.Filters;
using CoreAssoc.Invoice.Business.Authorization;
using CoreAssoc.Invoice.Business.Configuration;
using CoreAssoc.Invoice.Common.Autofac;
using CoreAssoc.Invoice.Common.Business;
using CoreAssoc.Invoice.Data.Configuration;
using CoreAssoc.Invoice.Data.Database;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CoreAssoc.Invoice.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            FilterConfig.RegisterApiGlobalFilters(config.Filters);
            
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            var serializerSettings = GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings;
            serializerSettings.Formatting = Formatting.Indented;
            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            

            // App modules
            var moduleLoader = RegisterAppModules();

            moduleLoader.GetModule<ProfileAppModule>();
            // Autofac
            RegisterAutofac(config, moduleLoader);
        }

        private static void RegisterAutofac(HttpConfiguration config, AppModuleLoader moduleLoader)
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<CommonInjectionModule>();
            builder.RegisterModule<RepositoryInjectionModule>();
            builder.RegisterModule<CqrsInjectionModule>(); builder.RegisterModule(new SuffixAssemblyInjectionModule<BusinessLayer>("Logic"));
            builder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);
            builder.Register(c => new AuthorizationFilterAttribute(c.Resolve<IAuthorizationLogic>()))
                .AsWebApiAuthorizationFilterFor<InvoicesController>()
                .InstancePerRequest();

            builder.RegisterType<DatabaseContext>().AsSelf().InstancePerRequest();
            builder.Register(cfg => ProfileAppModule.CreateMapper()).As<IMapper>().SingleInstance();
            builder.RegisterApiControllers(typeof(ServiceLayer).Assembly).PropertiesAutowired();
            builder.RegisterWebApiFilterProvider(config);

            builder.Register(cfg =>
            {
                var header = HttpContext.Current.Request.Headers["API-key"];
                if (null != header)
                {
                    return new UserData(header);
                }
                return new UserData(null);
            }).As<IUserData>().InstancePerRequest();

            var container = builder.Build();

            AutofacConfig.Initialize(container);

            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }

        private static AppModuleLoader RegisterAppModules()
        {
            var moduleLoader = new AppModuleLoader();
            moduleLoader.Register<ProfileAppModule>();
            ProfileAppModule.AutomapperModule = moduleLoader.GetModule<ProfileAppModule>();
            return moduleLoader;
        }
    }
}
