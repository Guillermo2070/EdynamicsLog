using EdynamicsLog.DTOs.Product;

namespace EdynamicsLog.UseCasesPorts.InputPort.Product
{
    public interface IUpdateProductInputPort
    {
        Task Handle(string SlugTenatOrganization, UpdateProductDTO updateProduct);
    }
}
