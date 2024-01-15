using EdynamicsLog.DTOs.User;

namespace EdynamicsLog.UseCasesPorts.InputPort.User
{
    public interface IUserAuthenticationInputPort
    {
        Task Handle(AuthenticationDTO authentication);
    }
}
