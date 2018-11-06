namespace CoreAssoc.Invoice.Common.Business
{
    public interface ICqrsQuery<in TIn, out TOut> : IQuery
    {
        TOut Handle(TIn query);
    }
}