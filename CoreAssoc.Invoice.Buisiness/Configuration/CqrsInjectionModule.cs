using System;
using Autofac;
using CoreAssoc.Invoice.Common.Business;

namespace CoreAssoc.Invoice.Business.Configuration
{
    public class CqrsInjectionModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof (BusinessLayer).Assembly)
                .Where(x => x.Name.EndsWith("CommandHandler", StringComparison.Ordinal))
                .AsImplementedInterfaces()
                .InstancePerRequest();
            
            builder.RegisterAssemblyTypes(typeof (BusinessLayer).Assembly)
                .Where(x => x.Name.EndsWith("QueryHandler", StringComparison.Ordinal))
                .AsImplementedInterfaces()
                .InstancePerRequest();
            
            builder.RegisterType<CommandDispatcher>()
                .AsImplementedInterfaces()
                .InstancePerRequest();
            
            builder.RegisterType<QueryDispatcher>()
                .AsImplementedInterfaces()
                .InstancePerRequest();
     

            builder.RegisterAssemblyTypes(typeof(BusinessLayer).Assembly)
                .Where(x => x.Name.EndsWith("Query", StringComparison.Ordinal))
                .AsSelf()
                .InstancePerRequest();
             
            builder.RegisterAssemblyTypes(typeof(BusinessLayer).Assembly)
                .Where(x => x.Name.EndsWith("Command", StringComparison.Ordinal))
                .AsSelf()
                .InstancePerRequest();
        }
    }
}