namespace EdynamicsLog.UseCasesPorts.InputPort.Product
{
    public interface IDeleteProductInputPort
    {
        Task Handle(string slugTenatOrganization, int idProduct);
    }
}
