using EdynamicsLog.DTOs.Product;

namespace EdynamicsLog.UseCasesPorts.OutputPort.Product
{
    public interface IGetAllProductsOutputPort
    {
        Task Handle(IEnumerable<ProductDTO> products);
    }
}
