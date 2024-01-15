using EdynamicsLog.Entities.Interfaces;
using EdynamicsLog.UseCasesPorts.InputPort.Product;
using EdynamicsLog.UseCasesPorts.OutputPort.Product;

namespace EdynamicsLog.UseCases.ProductCases
{
    public class DeleteProductInteractor : IDeleteProductInputPort
    {
        private readonly IProductRepository Repository;
        private readonly IDeleteProductOutputPort OutputPort;

        public DeleteProductInteractor(IProductRepository repository, IDeleteProductOutputPort outputPort)
        {
            Repository = repository;
            OutputPort = outputPort;
        }

        public async Task Handle(string slugTenatOrganization, int idProduct)
        {
            string error;

            try
            {
                Repository.DeleteProduct(slugTenatOrganization, idProduct);

                error = "Producto eliminado correctamente.";
            }
            catch (Exception ex)
            {
                error = $"{ex.Message}";
            }

            await OutputPort.HandleError(error);
        }
    }
}
