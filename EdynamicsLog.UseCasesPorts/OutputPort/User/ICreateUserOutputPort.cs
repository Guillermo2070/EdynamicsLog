using EdynamicsLog.DTOs.User;

namespace EdynamicsLog.UseCasesPorts.OutputPort.User
{
    public interface ICreateUserOutputPort
    {
        Task Handle(UserDTO user);
    }
}
