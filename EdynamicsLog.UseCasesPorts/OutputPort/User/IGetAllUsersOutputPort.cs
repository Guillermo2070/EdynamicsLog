using EdynamicsLog.DTOs.User;

namespace EdynamicsLog.UseCasesPorts.OutputPort.User
{
    public interface IGetAllUsersOutputPort
    {
        Task Handle(IEnumerable<UserDTO> users);
    }
}
