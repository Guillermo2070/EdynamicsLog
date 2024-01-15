namespace EdynamicsLog.UseCasesPorts.InputPort.Product
{
    public interface IGetAllProductsInputPort
    {
        Task Handle(string SlugTenatOrganization);
    }
}
