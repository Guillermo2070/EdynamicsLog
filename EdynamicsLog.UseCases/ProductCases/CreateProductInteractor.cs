using EdynamicsLog.DTOs.Product;
using EdynamicsLog.Entities.Interfaces;
using EdynamicsLog.Entities.POCOs;
using EdynamicsLog.UseCasesPorts.InputPort.Product;
using EdynamicsLog.UseCasesPorts.OutputPort.Product;

namespace EdynamicsLog.UseCases.ProductCases
{
    public class CreateProductInteractor : ICreateProductInputPort
    {
        readonly IProductRepository Repository;
        readonly IUnitOfWorkProducts UnitOfWork;
        readonly ICreateProductOutputPort OutputPort;

        public CreateProductInteractor(IProductRepository repository,
                                       IUnitOfWorkProducts unitOfWork,
                                       ICreateProductOutputPort outputPort) =>
                                       (Repository, UnitOfWork, OutputPort) =
                                       (repository, unitOfWork, outputPort);

        public async Task Handle(string SlugTenatOrganization, CreateProductDTO product)
        {
            Product newProduct = new Product
            {
                SlugTenatOrganization = SlugTenatOrganization,
                Name = product.Name,
                Description = product.Description,
                Duration = product.Duration
            };

            Repository.CreateProduct(newProduct);

            await UnitOfWork.SaveChanges();

            await OutputPort.Handle(
                new ProductDTO
                {
                    Id = newProduct.Id,
                    Name = newProduct.Name,
                    Description = newProduct.Description,
                    Duration = newProduct.Duration
                });
        }
    }
}
