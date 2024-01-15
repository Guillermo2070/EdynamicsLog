using EdynamicsLog.UseCases.OrganizationCases;
using EdynamicsLog.UseCases.UserCases;
using EdynamicsLog.UseCasesPorts.InputPort.Organization;
using EdynamicsLog.UseCasesPorts.InputPort.User;
using Microsoft.Extensions.DependencyInjection;

namespace EdynamicsLog.UseCases
{
    public static class DependencyContainerBussiness
    {
        public static IServiceCollection AddUseCasesServicesBussiness(this IServiceCollection services)
        {
            //AddTransient devuelvo la instancia

            services.AddTransient<ICreateOrganizationInputPort, CreateOrganizationInteractor>();

            services.AddTransient<ICreateUserInputPort, CreateUserInteractor>();

            services.AddTransient<IGetAllOrganizationsInputPort, GetAllOrganizationsInteractor>();

            services.AddTransient<IGetAllUsersInputPort, GetAllUsersInteractor>();

            services.AddTransient<IUserAuthenticationInputPort,  UserAuthenticationInteractor>();

            return services;
        }
    }
}
