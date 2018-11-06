using System;

namespace CoreAssoc.Invoice.Common.Autofac
{
    public interface IDependencyScope
    {
        T Resolve<T>();

        object Resolve(Type serviceType);
    }
}
