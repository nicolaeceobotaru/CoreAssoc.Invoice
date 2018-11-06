using AutoMapper;
using CoreAssoc.Invoice.Common.Business;
using CoreAssoc.Invoice.Data.Database;

namespace CoreAssoc.Invoice.Business.Commands
{
    public class CreateInvoiceCommandHandler : ICommandHandler<CreateInvoiceCommand>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public CreateInvoiceCommandHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public void Execute(CreateInvoiceCommand command)
        {
            var entity = _mapper.Map<Data.Entities.Invoice>(command.InvoiceModel);
            _repository.Insert(entity);
            _repository.Save();
        }
    }
}