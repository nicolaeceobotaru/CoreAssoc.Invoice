using AutoMapper;
using CoreAssoc.Invoice.Business.Models;
using CoreAssoc.Invoice.Common.Business;
using CoreAssoc.Invoice.Data.Database;

namespace CoreAssoc.Invoice.Business.Queries
{
    public class GetInvoiceQueryHandler : IQueryHandler<GetInvoiceQuery, GetInvoiceQueryResult>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetInvoiceQueryHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public GetInvoiceQueryResult Retrieve(GetInvoiceQuery query)
        {
            var entity = _repository.GetById<Data.Entities.Invoice>(query.Id);
            var model = _mapper.Map<InvoiceModel>(entity);
            return new GetInvoiceQueryResult(model);
        }
    }
}