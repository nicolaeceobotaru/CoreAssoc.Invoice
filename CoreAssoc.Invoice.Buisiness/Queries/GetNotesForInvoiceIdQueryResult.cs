using System.Collections.Generic;
using CoreAssoc.Invoice.Business.Models;
using CoreAssoc.Invoice.Common.Business;

namespace CoreAssoc.Invoice.Business.Queries
{
    public class GetNotesForInvoiceIdQueryResult : IQueryResult
    {
        public ICollection<NoteModel> NoteModels { get; }

        public GetNotesForInvoiceIdQueryResult(ICollection<NoteModel> noteModels)
        {
            NoteModels = noteModels;
        }
    }
}