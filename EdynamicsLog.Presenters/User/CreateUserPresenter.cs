using EdynamicsLog.DTOs.User;
using EdynamicsLog.UseCasesPorts.OutputPort.User;

namespace EdynamicsLog.Presenters.User
{
    public class CreateUserPresenter : ICreateUserOutputPort, IPresenter<UserDTO>
    {
        public UserDTO Content { get; set; }

        public Task Handle(UserDTO user)
        {
            Content = user;

            return Task.CompletedTask;
        }
    }
}
