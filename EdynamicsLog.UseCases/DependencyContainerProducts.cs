using EdynamicsLog.UseCases.ProductCases;
using EdynamicsLog.UseCasesPorts.InputPort.Product;
using Microsoft.Extensions.DependencyInjection;

namespace EdynamicsLog.UseCases
{
    public static class DependencyContainerProducts
    {
        public static IServiceCollection AddUseCasesServicesProducts(this IServiceCollection services)
        {
            //AddTransient devuelvo la instancia

            services.AddTransient<ICreateProductInputPort, CreateProductInteractor>();

            services.AddTransient<IDeleteProductInputPort, DeleteProductInteractor>();

            services.AddTransient<IUpdateProductInputPort, UpdateProductInteractor>();

            services.AddTransient<IGetAllProductsInputPort, GetAllProductsInteractor>();

            return services;
        }
    }
}
