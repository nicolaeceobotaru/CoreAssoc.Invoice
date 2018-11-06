using AutoMapper;
using CoreAssoc.Invoice.Common.Business;
using CoreAssoc.Invoice.Data.Database;

namespace CoreAssoc.Invoice.Business.Commands
{
    public class UpdateInvoiceCommandHandler : ICommandHandler<UpdateInvoiceCommand>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public UpdateInvoiceCommandHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public void Execute(UpdateInvoiceCommand command)
        {
            var entity = _mapper.Map<Data.Entities.Invoice>(command.InvoiceModel);
            _repository.Update(entity);
            _repository.Save();
        }
    }
}