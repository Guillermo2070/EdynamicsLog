using EdynamicsLog.Entities.Interfaces;
using EdynamicsLog.RepositoryEFCore.DataContext;
using EdynamicsLog.RepositoryEFCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EdynamicsLog.RepositoryEFCore
{
    public static class DependencyContainerProducts
    {
        public static IServiceCollection AddRepositoriesProducts(this IServiceCollection services, IConfiguration configuration)
        {
            //AddScoped regresa el mismo contexto

            services.AddDbContext<EdynamicsLogProductsContext>(options => options.UseSqlServer(configuration.GetConnectionString("EdynamicsLogProducts")));

            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IUnitOfWorkProducts, UnitOfWorkProducts>();

            return services;
        }
    }
}
