namespace CoreAssoc.Invoice.Common.Business
{
    public interface ICommandDispatcher
    {
        void Handle<TCommand>(TCommand command) where TCommand : class, ICommand;
    }
}