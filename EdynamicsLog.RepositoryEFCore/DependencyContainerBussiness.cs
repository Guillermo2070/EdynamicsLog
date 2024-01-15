using EdynamicsLog.Entities.Interfaces;
using EdynamicsLog.RepositoryEFCore.DataContext;
using EdynamicsLog.RepositoryEFCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EdynamicsLog.RepositoryEFCore
{
    public static class DependencyContainerBussiness
    {
        public static IServiceCollection AddRepositoriesBussiness(this IServiceCollection services, IConfiguration configuration)
        {
            //AddScoped regresa el mismo contexto

            services.AddDbContext<EdynamicsLogBussinessContext>(options => options.UseSqlServer(configuration.GetConnectionString("EdynamicsLogBussiness")));

            services.AddScoped<IOrganizationRepository, OrganizationRepository>();

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IUnitOfWorkBussiness, UnitOfWorkBussiness>();

            return services;
        }
    }
}
