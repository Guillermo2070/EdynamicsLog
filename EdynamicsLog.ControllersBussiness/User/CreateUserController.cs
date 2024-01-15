using EdynamicsLog.DTOs.User;
using EdynamicsLog.Presenters;
using EdynamicsLog.UseCasesPorts.InputPort.User;
using EdynamicsLog.UseCasesPorts.OutputPort.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EdynamicsLog.Controllers.User
{
    [Route("api/{slugTenat}/[controller]")]
    [ApiController]
    [Authorize]

    public class CreateUserController
    {
        readonly ICreateUserInputPort InputPort;
        readonly ICreateUserOutputPort OutputPort;

        public CreateUserController(ICreateUserInputPort inputPort, ICreateUserOutputPort outputPort)
        {
            InputPort = inputPort;
            OutputPort = outputPort;
        }


        [HttpPost]
        public async Task<UserDTO> CreateOrganization(string slugTenat, CreateUserDTO user)
        {
            await InputPort.Handle(slugTenat, user);

            return ((IPresenter<UserDTO>)OutputPort).Content;
        }
    }
}
