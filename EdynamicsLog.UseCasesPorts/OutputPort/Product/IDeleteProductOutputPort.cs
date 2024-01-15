namespace EdynamicsLog.UseCasesPorts.OutputPort.Product
{
    public interface IDeleteProductOutputPort
    {
        Task Handle(string error);

        Task HandleError(string error);
    }
}
