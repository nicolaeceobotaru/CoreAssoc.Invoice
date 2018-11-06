using System.Collections.Generic;

namespace CoreAssoc.Invoice.Data.Entities
{
    public class Invoice : BaseDomainEntity
    {
        public string Identifier { get; set; }
        public decimal Amount { get; set; }
        public ICollection<Note> Notes { get; set; }
    }
}