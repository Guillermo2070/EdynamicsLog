using EdynamicsLog.DTOs.User;
using EdynamicsLog.Entities.Interfaces;
using EdynamicsLog.UseCasesPorts.InputPort.User;
using EdynamicsLog.UseCasesPorts.OutputPort.User;

namespace EdynamicsLog.UseCases.UserCases
{
    public class GetAllUsersInteractor : IGetAllUsersInputPort
    {
        readonly IUserRepository Repository;
        readonly IGetAllUsersOutputPort OutputPort;

        public GetAllUsersInteractor(IUserRepository repository, IGetAllUsersOutputPort outputPort) =>
            (Repository, OutputPort) = (repository, outputPort);

        public Task Handle(string slugTenatOrganization)
        {
            var Users = Repository.GetUsers(slugTenatOrganization).Select(u =>
                new UserDTO
                {
                    Id = u.Id,
                    Email = u.Email,
                    Password = u.Password
                });

            OutputPort.Handle(Users);

            return Task.CompletedTask;
        }
    }
}
