using System;
using System.Data.Entity;
using System.Linq;
using CoreAssoc.Invoice.Data.Configuration;
using CoreAssoc.Invoice.Data.Entities;

namespace CoreAssoc.Invoice.Data.Database
{
    public class Repository : IRepository, IDisposable
    {
        protected readonly DatabaseContext Context;

        public IUserData UserData { get; }

        public Repository(DatabaseContext context, IUserData userData)
        {
            Context = context;
            UserData = userData;
        }
        
        public void Dispose()
        {
            Context.Dispose();
        }

        public virtual IQueryable<TEntity> Query<TEntity>() where TEntity : BaseIdEntity
        {
            return Context.Set<TEntity>();
        }
        
        public virtual TEntity GetById<TEntity>(int id) where TEntity : BaseDomainEntity
        {
            return Context.Set<TEntity>().Find(id);
        }
        
        public virtual void Insert<TEntity>(TEntity entity) where TEntity : BaseDomainEntity
        {
            Context.Set<TEntity>().Add(entity);
        }
        
        public virtual void Update<TEntity>(TEntity entity) where TEntity : BaseDomainEntity
        {
            var isAuthorized = Context.Set<TEntity>().Any(ent => ent.Id == entity.Id && ent.User.ApiKey == UserData.ApiKey);

            if (!isAuthorized)
            {
                throw new UnauthorizedAccessException();
            }
            
            Context.Set<TEntity>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            var entities = Context.ChangeTracker.Entries()
                .Where(x => x.Entity is BaseDomainEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
            var user = Query<User>().FirstOrDefault(usr => usr.ApiKey == UserData.ApiKey);
            foreach (var e in entities)
            {
                var entity = e.Entity as BaseDomainEntity;
                if (entity != null)
                {
                    entity.UserId = user.Id;
                }
            }
            Context.SaveChanges();
        }
    }
}