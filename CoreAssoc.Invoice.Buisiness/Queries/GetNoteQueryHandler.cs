using AutoMapper;
using CoreAssoc.Invoice.Business.Models;
using CoreAssoc.Invoice.Common.Business;
using CoreAssoc.Invoice.Data.Database;
using CoreAssoc.Invoice.Data.Entities;

namespace CoreAssoc.Invoice.Business.Queries
{
    public class GetNoteQueryHandler : IQueryHandler<GetNoteQuery, GetNoteQueryResult>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetNoteQueryHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public GetNoteQueryResult Retrieve(GetNoteQuery query)
        {
            var entity = _repository.GetById<Note>(query.Id);
            var model = _mapper.Map<NoteModel>(entity);
            return new GetNoteQueryResult(model);
        }
    }
}