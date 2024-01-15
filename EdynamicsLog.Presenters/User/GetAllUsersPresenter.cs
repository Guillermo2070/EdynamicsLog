using EdynamicsLog.DTOs.User;
using EdynamicsLog.UseCasesPorts.OutputPort.User;

namespace EdynamicsLog.Presenters.User
{
    public class GetAllUsersPresenter : IGetAllUsersOutputPort, IPresenter<IEnumerable<UserDTO>>
    {
        public IEnumerable<UserDTO> Content { get; private set; }

        public Task Handle(IEnumerable<UserDTO> users)
        {
            Content = users;

            return Task.CompletedTask;
        }
    }
}
