using EdynamicsLog.DTOs.Product;

namespace EdynamicsLog.UseCasesPorts.InputPort.Product
{
    public interface ICreateProductInputPort
    {
        Task Handle(string SlugTenatOrganization, CreateProductDTO product);
    }
}
