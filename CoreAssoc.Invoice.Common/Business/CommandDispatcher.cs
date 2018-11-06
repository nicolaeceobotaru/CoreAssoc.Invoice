using CoreAssoc.Invoice.Common.Autofac;

namespace CoreAssoc.Invoice.Common.Business
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IDependencyScope _scope;
        
        public CommandDispatcher(IDependencyScope scope)
        {
            _scope = scope;
        }
        
        public void Handle<TCommand>(TCommand command) where TCommand : class, ICommand
        {
            var commandHandler = _scope.Resolve<ICommandHandler<TCommand>>();
            commandHandler.Execute(command);
        }
    }
}