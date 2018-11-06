using System.Linq;
using CoreAssoc.Invoice.Data.Configuration;
using CoreAssoc.Invoice.Data.Entities;

namespace CoreAssoc.Invoice.Data.Database
{
    public interface IRepository
    {
        IUserData UserData { get; }

        IQueryable<TEntity> Query<TEntity>() where TEntity : BaseIdEntity;
        
        TEntity GetById<TEntity>(int id) where TEntity : BaseDomainEntity;
        
        void Insert<TEntity>(TEntity entity) where TEntity : BaseDomainEntity;

        void Update<TEntity>(TEntity entity) where TEntity : BaseDomainEntity;
        
        void Save();
    }
}