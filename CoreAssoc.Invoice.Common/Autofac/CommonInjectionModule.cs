using Autofac;

namespace CoreAssoc.Invoice.Common.Autofac
{
    public class CommonInjectionModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AutofacDependencyScope>().As<IDependencyScope>();
        }
    }
}