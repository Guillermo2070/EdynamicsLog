using EdynamicsLog.DTOs.User;
using EdynamicsLog.Entities.Interfaces;
using EdynamicsLog.Entities.POCOs;
using EdynamicsLog.UseCasesPorts.InputPort.User;
using EdynamicsLog.UseCasesPorts.OutputPort.User;

namespace EdynamicsLog.UseCases.UserCases
{
    public class CreateUserInteractor : ICreateUserInputPort
    {
        readonly IUserRepository Repository;
        readonly IUnitOfWorkBussiness UnitOfWork;
        readonly ICreateUserOutputPort OutputPort;

        public CreateUserInteractor(IUserRepository repository,
                                       IUnitOfWorkBussiness unitOfWork,
                                       ICreateUserOutputPort outputPort) =>
                                       (Repository, UnitOfWork, OutputPort) =
                                       (repository, unitOfWork, outputPort);
        public async Task Handle(string SlugTenatOrganization, CreateUserDTO user)
        {
            User newUser = new User
            {
                SlugTenatOrganization = SlugTenatOrganization,
                Email = user.Email,
                Password = user.Password
            };

            Repository.CreateUserByOrganization(newUser);

            await UnitOfWork.SaveChanges();

            await OutputPort.Handle(
              new UserDTO
              {
                  Id = newUser.Id,
                  Email = newUser.Email,
                  Password = newUser.Password
              });
        }
    }
}
