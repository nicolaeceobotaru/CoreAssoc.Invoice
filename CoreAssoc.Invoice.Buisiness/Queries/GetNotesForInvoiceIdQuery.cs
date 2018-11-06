using CoreAssoc.Invoice.Common.Business;

namespace CoreAssoc.Invoice.Business.Queries
{
    public class GetNotesForInvoiceIdQuery : IQuery
    {
        public GetNotesForInvoiceIdQuery(int invoiceId)
        {
            InvoiceId = invoiceId;
        }

        public int InvoiceId { get; }
    }
}