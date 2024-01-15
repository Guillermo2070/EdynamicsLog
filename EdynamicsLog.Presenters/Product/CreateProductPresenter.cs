using EdynamicsLog.DTOs.Product;
using EdynamicsLog.UseCasesPorts.OutputPort.Product;

namespace EdynamicsLog.Presenters.Product
{
    public class CreateProductPresenter : ICreateProductOutputPort, IPresenter<ProductDTO>
    {
        public ProductDTO Content { get; set; }

        public Task Handle(ProductDTO product)
        {
            Content = product;

            return Task.CompletedTask;
        }
    }
}
