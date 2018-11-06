using CoreAssoc.Invoice.Business.Models;
using CoreAssoc.Invoice.Common.Business;

namespace CoreAssoc.Invoice.Business.Commands
{
    public class CreateInvoiceCommand : ICommand
    {
        public InvoiceModel InvoiceModel;

        public CreateInvoiceCommand(InvoiceModel invoiceModel)
        {
            InvoiceModel = invoiceModel;
        }
    }
}