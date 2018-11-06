namespace CoreAssoc.Invoice.Data.Entities
{
    public class Note : BaseDomainEntity
    {
        public string Text { get; set; }
        public int InvoiceId { get; set; }

        public Invoice Invoice { get; set; }
    }
}