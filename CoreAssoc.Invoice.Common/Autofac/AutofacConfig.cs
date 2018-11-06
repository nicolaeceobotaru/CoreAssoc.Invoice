using Autofac;

namespace CoreAssoc.Invoice.Common.Autofac
{
    public class AutofacConfig
    {
        public static IContainer Container { get; private set; }

        public static void Initialize(IContainer container)
        {
            Container = container;
        }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }
    }
}