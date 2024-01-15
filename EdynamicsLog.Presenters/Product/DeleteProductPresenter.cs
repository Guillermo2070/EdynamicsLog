using EdynamicsLog.UseCasesPorts.OutputPort.Product;

namespace EdynamicsLog.Presenters.Product
{
    public class DeleteProductPresenter : IDeleteProductOutputPort, IPresenter<string>
    {
        public string Content { get; private set; }

        public string Message { get; private set; }

        public Task Handle(string content)
        {
            Content = content;

            return Task.CompletedTask;
        }

        public Task HandleError(string message)
        {
            Message = message;

            return Task.CompletedTask;
        }
    }
}
