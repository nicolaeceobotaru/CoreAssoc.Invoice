using System;
using CoreAssoc.Invoice.Common.Autofac;

namespace CoreAssoc.Invoice.Common.Business
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IDependencyScope _scope;
        
        public QueryDispatcher(IDependencyScope scope)
        {
            _scope = scope;
        }
        
        public TResult Handle<TResult, TQuery>(TQuery query) where TResult : IQueryResult where TQuery : class, IQuery
        {
            var queryHandler = _scope.Resolve<IQueryHandler<TQuery, TResult>>();
            return queryHandler.Retrieve(query);
        }
        
        public TResult Handle<TResult>(IQuery query) where TResult : IQueryResult
        {
            var type1 = query.GetType();
            var type2 = typeof (TResult);
            var serviceType = typeof (IQueryHandler<,>).MakeGenericType(type1, type2);
            var obj = _scope.Resolve(serviceType);
            var method = serviceType.GetMethod("Retrieve", new Type[1]
            {
                type1
            });
            return (TResult) method.Invoke(obj, new object[1]
            {
                query
            });
        }
    }
}