using AutoMapper;
using CoreAssoc.Invoice.Common.Business;
using CoreAssoc.Invoice.Data.Database;
using CoreAssoc.Invoice.Data.Entities;

namespace CoreAssoc.Invoice.Business.Commands
{
    public class UpdateNoteCommandHandler : ICommandHandler<UpdateNoteCommand>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public UpdateNoteCommandHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public void Execute(UpdateNoteCommand command)
        {
            var entity = _mapper.Map<Note>(command.NoteModel);
            _repository.Update(entity);
            _repository.Save();
        }
    }
}