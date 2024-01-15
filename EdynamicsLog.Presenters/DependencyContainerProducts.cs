using EdynamicsLog.Presenters.Product;
using EdynamicsLog.UseCasesPorts.OutputPort.Product;
using Microsoft.Extensions.DependencyInjection;

namespace EdynamicsLog.Presenters
{
    public static class DependencyContainerProducts
    {
        public static IServiceCollection AddPresentersProducts(this IServiceCollection services)
        {
            services.AddScoped<ICreateProductOutputPort, CreateProductPresenter>();

            services.AddScoped<IDeleteProductOutputPort, DeleteProductPresenter>();

            services.AddScoped<IUpdateProductOutputPort, UpdateProductPresenter>();

            services.AddScoped<IGetAllProductsOutputPort, GetAllProductsPresenter>();

            return services;
        }
    }
}
