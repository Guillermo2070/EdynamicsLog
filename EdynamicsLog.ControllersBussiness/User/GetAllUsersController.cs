using EdynamicsLog.DTOs.User;
using EdynamicsLog.Presenters;
using EdynamicsLog.UseCasesPorts.InputPort.User;
using EdynamicsLog.UseCasesPorts.OutputPort.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EdynamicsLog.Controllers.Organization
{
    [Route("api/{slugTenat}/[controller]")]
    [ApiController]
    [Authorize]

    public class GetAllUsersController
    {
        readonly IGetAllUsersInputPort InputPort;
        readonly IGetAllUsersOutputPort OutputPort;

        public GetAllUsersController(IGetAllUsersInputPort inputPort, IGetAllUsersOutputPort outputPort)
        {
            InputPort = inputPort;
            OutputPort = outputPort;
        }

        [HttpGet]
        public async Task<IEnumerable<UserDTO>> GetAllUsers(string slugTenat)
        {
            await InputPort.Handle(slugTenat);

            return ((IPresenter<IEnumerable<UserDTO>>)OutputPort).Content;
        }
    }
}
