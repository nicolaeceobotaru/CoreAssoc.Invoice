using CoreAssoc.Invoice.Data.Entities;

namespace CoreAssoc.Invoice.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CoreAssoc.Invoice.Data.Database.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Data.Database.DatabaseContext context)
        {
            context.Users.AddOrUpdate(
                new User { Id = 1, ApiKey = "admin123", Role = UserRole.Admin },
                new User { Id = 2, ApiKey = "admin345", Role = UserRole.Admin },
                new User { Id = 3, ApiKey = "user123", Role = UserRole.User },
                new User { Id = 4, ApiKey = "user345", Role = UserRole.User });
        }
    }
}
