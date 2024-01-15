using EdynamicsLog.DTOs.Product;
using EdynamicsLog.UseCasesPorts.OutputPort.Product;

namespace EdynamicsLog.Presenters.Product
{
    public class UpdateProductPresenter : IUpdateProductOutputPort, IPresenter<ProductDTO>
    {
        public ProductDTO Content { get; set; }
        public string Error { get; set; }

        public Task Handle(ProductDTO updateProduct)
        {
            Content = updateProduct;
            return Task.CompletedTask;
        }

        public Task HandleError(string error)
        {
            Error = error;
            return Task.CompletedTask;
        }
    }
}
