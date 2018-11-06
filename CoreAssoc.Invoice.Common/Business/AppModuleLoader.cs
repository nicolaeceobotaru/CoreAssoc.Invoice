using System;
using System.Collections.Generic;
using System.Linq;


namespace CoreAssoc.Invoice.Common.Business
{
    public class AppModuleLoader
    {
        private readonly IList<IAppModule> _modules;

        public AppModuleLoader()
        {
            _modules = new List<IAppModule>();
        }

        public void Register<T>() where T : IAppModule
        {
            var module = Activator.CreateInstance<T>();

            module.Register();

            _modules.Add(module);
        }

        public T GetModule<T>() where T : class, IAppModule
        {
            return _modules.FirstOrDefault(m => m.GetType() == typeof(T)) as T;
        }
    }
}