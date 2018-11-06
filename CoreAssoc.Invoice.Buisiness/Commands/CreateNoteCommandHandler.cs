using AutoMapper;
using CoreAssoc.Invoice.Common.Business;
using CoreAssoc.Invoice.Data.Database;
using CoreAssoc.Invoice.Data.Entities;

namespace CoreAssoc.Invoice.Business.Commands
{
    public class CreateNoteCommandHandler : ICommandHandler<CreateNoteCommand>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public CreateNoteCommandHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public void Execute(CreateNoteCommand command)
        {
            var entity = _mapper.Map<Note>(command.NoteModel);
            _repository.Insert(entity);
            _repository.Save();
        }
    }
}