using EdynamicsLog.DTOs.Organization;
using EdynamicsLog.Presenters;
using EdynamicsLog.UseCasesPorts.InputPort.Organization;
using EdynamicsLog.UseCasesPorts.OutputPort.Organization;
using Microsoft.AspNetCore.Mvc;

namespace EdynamicsLog.Controllers.Organization
{
    [Route("api/[controller]")]
    [ApiController]

    public class GetAllOrganizationsController
    {
        readonly IGetAllOrganizationsInputPort InputPort;
        readonly IGetAllOrganizationsOutputPort OutputPort;

        public GetAllOrganizationsController(IGetAllOrganizationsInputPort inputPort, IGetAllOrganizationsOutputPort outputPort)
        {
            InputPort = inputPort;
            OutputPort = outputPort;
        }

        [HttpGet]
        public async Task<IEnumerable<OrganizationDTO>> GetAllOrganizations()
        {
            await InputPort.Handle();

            return ((IPresenter<IEnumerable<OrganizationDTO>>)OutputPort).Content;
        }
    }
}
