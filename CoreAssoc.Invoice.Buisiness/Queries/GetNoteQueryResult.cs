using CoreAssoc.Invoice.Business.Models;
using CoreAssoc.Invoice.Common.Business;

namespace CoreAssoc.Invoice.Business.Queries
{
    public class GetNoteQueryResult : IQueryResult
    {
        public NoteModel NoteModel { get; }

        public GetNoteQueryResult(NoteModel noteModel)
        {
            NoteModel = noteModel;
        }
    }
}