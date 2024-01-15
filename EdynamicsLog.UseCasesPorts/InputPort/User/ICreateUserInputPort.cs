using EdynamicsLog.DTOs.User;

namespace EdynamicsLog.UseCasesPorts.InputPort.User
{
    public interface ICreateUserInputPort
    {
        Task Handle(string SlugTenatOrganization, CreateUserDTO user);
    }
}
