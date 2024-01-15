using EdynamicsLog.Presenters.Organization;
using EdynamicsLog.Presenters.User;
using EdynamicsLog.UseCasesPorts.OutputPort.Organization;
using EdynamicsLog.UseCasesPorts.OutputPort.User;
using Microsoft.Extensions.DependencyInjection;

namespace EdynamicsLog.Presenters
{
    public static class DependencyContainerBussiness
    {
        public static IServiceCollection AddPresentersBussiness(this IServiceCollection services)
        {
            services.AddScoped<ICreateOrganizationOutputPort, CreateOrganizationPresenter>();

            services.AddScoped<ICreateUserOutputPort, CreateUserPresenter>();

            services.AddScoped<IGetAllOrganizationsOutputPort, GetAllOrganizationsPresenter>();

            services.AddScoped<IGetAllUsersOutputPort, GetAllUsersPresenter>();

            services.AddScoped<IUserAuthenticationOutputPort, UserAuthenticationPresenter>();

            return services;
        }
    }
}
