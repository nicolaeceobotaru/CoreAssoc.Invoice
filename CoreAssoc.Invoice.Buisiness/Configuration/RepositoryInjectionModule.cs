using System;
using Autofac;
using CoreAssoc.Invoice.Data.Configuration;
using CoreAssoc.Invoice.Data.Database;

namespace CoreAssoc.Invoice.Business.Configuration
{
    public class RepositoryInjectionModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof (DataAccessLayer).Assembly)
                .Where(x => x.Name.EndsWith("Repository", StringComparison.Ordinal))
                .AsImplementedInterfaces()
                .InstancePerRequest();

            builder.RegisterType<Repository>().AsImplementedInterfaces().InstancePerRequest();
        }
    }
}