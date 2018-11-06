namespace CoreAssoc.Invoice.Common.Business
{
    public interface ICqrsCommand<in TIn> : ICommand
    {
        void Handle(TIn model);
    }
}