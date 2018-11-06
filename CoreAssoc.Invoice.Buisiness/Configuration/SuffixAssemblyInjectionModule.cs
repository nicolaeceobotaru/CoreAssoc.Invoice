using System;
using Autofac;

namespace CoreAssoc.Invoice.Business.Configuration
{
    public class SuffixAssemblyInjectionModule<T> : Module
    {
        private readonly string _suffix;
        
        public SuffixAssemblyInjectionModule(string suffix)
        {
            _suffix = suffix;
        }
        
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(T).Assembly)
                .Where(x => x.Name.EndsWith(_suffix, StringComparison.Ordinal))
                .AsImplementedInterfaces();
        }
    }
}