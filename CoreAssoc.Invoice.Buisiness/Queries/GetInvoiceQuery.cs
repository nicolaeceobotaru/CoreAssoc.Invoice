using CoreAssoc.Invoice.Common.Business;

namespace CoreAssoc.Invoice.Business.Queries
{
    public class GetInvoiceQuery : IQuery
    {
        public GetInvoiceQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}