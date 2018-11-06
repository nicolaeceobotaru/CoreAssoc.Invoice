namespace CoreAssoc.Invoice.Common.Business
{
    public interface IQueryDispatcher
    {
        TResult Handle<TResult, TQuery>(TQuery query) where TResult : IQueryResult where TQuery : class, IQuery;
        
        TResult Handle<TResult>(IQuery query) where TResult : IQueryResult;
    }
}