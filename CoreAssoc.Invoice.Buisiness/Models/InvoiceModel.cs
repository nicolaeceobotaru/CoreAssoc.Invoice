namespace CoreAssoc.Invoice.Business.Models
{
    public class InvoiceModel
    {
        public int InvoiceId { get; set; }
        public string Identifier { get; set; }
        public decimal Amount { get; set; }
    }
}