using EdynamicsLog.DTOs.Product;
using EdynamicsLog.Entities.Interfaces;
using EdynamicsLog.UseCasesPorts.InputPort.Product;
using EdynamicsLog.UseCasesPorts.OutputPort.Product;

namespace EdynamicsLog.UseCases.ProductCases
{
    public class GetAllProductsInteractor : IGetAllProductsInputPort
    {
        readonly IProductRepository Repository;
        readonly IGetAllProductsOutputPort OutputPort;

        public GetAllProductsInteractor(IProductRepository repository,
                                       IGetAllProductsOutputPort outputPort) =>
                                       (Repository, OutputPort) =
                                       (repository, outputPort);
        public Task Handle(string slugTenatOrganization)
        {
            var Products = Repository.GetAllProducts(slugTenatOrganization).Select(p =>
            new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Duration = p.Duration   
            });

            OutputPort.Handle(Products);

            return Task.CompletedTask;
        }
    }
}
