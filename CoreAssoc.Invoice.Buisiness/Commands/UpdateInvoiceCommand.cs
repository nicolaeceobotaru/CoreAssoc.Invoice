using CoreAssoc.Invoice.Business.Models;
using CoreAssoc.Invoice.Common.Business;

namespace CoreAssoc.Invoice.Business.Commands
{
    public class UpdateInvoiceCommand : ICommand
    {
        public InvoiceModel InvoiceModel;

        public UpdateInvoiceCommand(InvoiceModel invoiceModel)
        {
            InvoiceModel = invoiceModel;
        }
    }
}