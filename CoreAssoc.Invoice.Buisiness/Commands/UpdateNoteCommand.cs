using CoreAssoc.Invoice.Business.Models;
using CoreAssoc.Invoice.Common.Business;

namespace CoreAssoc.Invoice.Business.Commands
{
    public class UpdateNoteCommand : ICommand
    {
        public NoteModel NoteModel;

        public UpdateNoteCommand(NoteModel noteModel)
        {
            NoteModel = noteModel;
        }
    }
}