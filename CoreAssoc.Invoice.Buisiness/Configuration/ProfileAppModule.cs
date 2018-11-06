using System;
using System.Linq;
using AutoMapper;
using CoreAssoc.Invoice.Common.Business;

namespace CoreAssoc.Invoice.Business.Configuration
{
    public class ProfileAppModule : IAppModule
    {
        public static ProfileAppModule AutomapperModule { get; set; }

        public MapperConfiguration Configuration { get; private set; }

        public void Register()
        {
            Configuration = new MapperConfiguration(cfg =>
            {
                var profiles = typeof (BusinessLayer).Assembly.GetTypes().Where(x => typeof (Profile).IsAssignableFrom(x));

                foreach (var profile in profiles)
                {
                    cfg.AddProfile(Activator.CreateInstance(profile) as Profile);
                }
            }); 
        }

        public static IMapper CreateMapper()
        {
            return AutomapperModule.Configuration.CreateMapper();
        }
    }
}