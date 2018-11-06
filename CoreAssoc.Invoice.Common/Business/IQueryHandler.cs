namespace CoreAssoc.Invoice.Common.Business
{
    public interface IQueryHandler<in TQuery, out TResult> where TQuery : IQuery where TResult : IQueryResult
    {
        TResult Retrieve(TQuery query);
    }
}