using EdynamicsLog.DTOs.User;

namespace EdynamicsLog.UseCasesPorts.OutputPort.User
{
    public interface IUserAuthenticationOutputPort
    {
        Task Handle(SlugTenantDTO slugTenant);

        Task HandleCredencialesIncorrectas(string mensaje);
    }
}
