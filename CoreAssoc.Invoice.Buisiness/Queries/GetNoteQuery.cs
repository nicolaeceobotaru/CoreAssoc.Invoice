using CoreAssoc.Invoice.Common.Business;

namespace CoreAssoc.Invoice.Business.Queries
{
    public class GetNoteQuery : IQuery
    {
        public GetNoteQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}