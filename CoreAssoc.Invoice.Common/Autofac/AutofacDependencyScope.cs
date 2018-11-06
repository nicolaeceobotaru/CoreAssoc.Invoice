using System;
using Autofac;

namespace CoreAssoc.Invoice.Common.Autofac
{
    public class AutofacDependencyScope : IDependencyScope
    {
        private readonly ILifetimeScope _scope;
        
        public AutofacDependencyScope(ILifetimeScope scope)
        {
            _scope = scope;
        }
        
        public T Resolve<T>()
        {
            return _scope.Resolve<T>();
        }
        
        public object Resolve(Type serviceType)
        {
            return _scope.Resolve(serviceType);
        }
    }
}