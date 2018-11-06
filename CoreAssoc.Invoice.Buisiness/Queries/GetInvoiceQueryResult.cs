using CoreAssoc.Invoice.Business.Models;
using CoreAssoc.Invoice.Common.Business;

namespace CoreAssoc.Invoice.Business.Queries
{
    public class GetInvoiceQueryResult : IQueryResult
    {
        public InvoiceModel InvoiceModel { get; }

        public GetInvoiceQueryResult(InvoiceModel invoiceModel)
        {
            InvoiceModel = invoiceModel;
        }
    }
}