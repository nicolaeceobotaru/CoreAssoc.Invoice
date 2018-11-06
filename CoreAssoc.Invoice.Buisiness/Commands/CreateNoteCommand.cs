using CoreAssoc.Invoice.Business.Models;
using CoreAssoc.Invoice.Common.Business;

namespace CoreAssoc.Invoice.Business.Commands
{
    public class CreateNoteCommand : ICommand
    {
        public NoteModel NoteModel;

        public CreateNoteCommand(NoteModel noteModel)
        {
            NoteModel = noteModel;
        }
    }
}