using EdynamicsLog.DTOs.Product;

namespace EdynamicsLog.UseCasesPorts.OutputPort.Product
{
    public interface IUpdateProductOutputPort
    {
        Task Handle(ProductDTO updateProduct);

        Task HandleError(string errorMessage);
    }
}
