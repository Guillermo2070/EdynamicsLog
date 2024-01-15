using EdynamicsLog.DTOs.Product;

namespace EdynamicsLog.UseCasesPorts.OutputPort.Product
{
    public interface ICreateProductOutputPort
    {
        Task Handle(ProductDTO product);
    }
}
