using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CoreAssoc.Invoice.Business.Models;
using CoreAssoc.Invoice.Common.Business;
using CoreAssoc.Invoice.Data.Database;
using CoreAssoc.Invoice.Data.Entities;

namespace CoreAssoc.Invoice.Business.Queries
{
    public class GetNotesForInvoiceIdQueryHandler : IQueryHandler<GetNotesForInvoiceIdQuery, GetNotesForInvoiceIdQueryResult>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetNotesForInvoiceIdQueryHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public GetNotesForInvoiceIdQueryResult Retrieve(GetNotesForInvoiceIdQuery query)
        {
            var entities = _repository.Query<Data.Entities.Invoice>().Where(invoice => invoice.Id == query.InvoiceId)
                .SelectMany(invoice => invoice.Notes);
            var models = _mapper.Map<ICollection<NoteModel>>(entities);
            return new GetNotesForInvoiceIdQueryResult(models);
        }
    }
}