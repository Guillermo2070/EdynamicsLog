using EdynamicsLog.DTOs.Product;
using EdynamicsLog.UseCasesPorts.OutputPort.Product;

namespace EdynamicsLog.Presenters.Product
{
    public class GetAllProductsPresenter : IGetAllProductsOutputPort, IPresenter<IEnumerable<ProductDTO>>
    {
        public IEnumerable<ProductDTO> Content { get; private set; }

        public Task Handle(IEnumerable<ProductDTO> products)
        {
            Content = products;

            return Task.CompletedTask;
        }
    }
}
