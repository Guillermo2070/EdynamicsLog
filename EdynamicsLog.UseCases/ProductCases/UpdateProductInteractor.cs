using EdynamicsLog.DTOs.Product;
using EdynamicsLog.Entities.Interfaces;
using EdynamicsLog.Entities.POCOs;
using EdynamicsLog.UseCasesPorts.InputPort.Product;
using EdynamicsLog.UseCasesPorts.OutputPort.Product;

namespace EdynamicsLog.UseCases.ProductCases
{
    public class UpdateProductInteractor : IUpdateProductInputPort
    {
        readonly IProductRepository Repository;
        readonly IUnitOfWorkProducts UnitOfWork;
        readonly IUpdateProductOutputPort OutputPort;

        public UpdateProductInteractor(IProductRepository repository, IUnitOfWorkProducts unitOfWork, IUpdateProductOutputPort outputPort)
        {
            Repository = repository;
            UnitOfWork = unitOfWork;
            OutputPort = outputPort;
        }

        public async Task Handle(string SlugTenatOrganization, UpdateProductDTO updateProduct)
        {
            try
            {
                Product existingProduct = Repository.GetProductById(updateProduct.Id, SlugTenatOrganization);

                if (existingProduct == null)
                {
                    await OutputPort.HandleError("El producto no se encontró.");
                    return;
                }

                existingProduct.Name = updateProduct.Name;
                existingProduct.Description = updateProduct.Description;
                existingProduct.Duration = updateProduct.Duration;

                Repository.UpdateProduct(existingProduct);

                await UnitOfWork.SaveChanges();

                await OutputPort.Handle(
                    new ProductDTO
                    {
                        Id = existingProduct.Id,
                        Name = existingProduct.Name,
                        Description = existingProduct.Description,
                        Duration = existingProduct.Duration
                    });
            }
            catch 
            {
                await OutputPort.HandleError("Error al intentar actualizar el producto.");
            }
        }
    }
}
