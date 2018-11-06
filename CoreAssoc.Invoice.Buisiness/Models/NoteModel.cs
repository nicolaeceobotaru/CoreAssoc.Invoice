namespace CoreAssoc.Invoice.Business.Models
{
    public class NoteModel
    {
        public int NoteId { get; set; }
        public string Text { get; set; }
        public int InvoiceId { get; set; }
    }
}