using EdynamicsLog.DTOs.Organization;
using EdynamicsLog.Presenters;
using EdynamicsLog.UseCasesPorts.InputPort.Organization;
using EdynamicsLog.UseCasesPorts.OutputPort.Organization;
using Microsoft.AspNetCore.Mvc;

namespace EdynamicsLog.Controllers.Organization
{
    [Route("api/[controller]")]
    [ApiController]

    public class CreateOrganizationController
    {
        readonly ICreateOrganizationInputPort InputPort;
        readonly ICreateOrganizationOutputPort OutputPort;

        public CreateOrganizationController(ICreateOrganizationInputPort inputPort, ICreateOrganizationOutputPort outputPort)
        {
            InputPort = inputPort;
            OutputPort = outputPort;
        }

        [HttpPost]
        public async Task<OrganizationDTO> CreateOrganization(CreateOrganizationDTO organization)
        {
            await InputPort.Handle(organization);

            return ((IPresenter<OrganizationDTO>)OutputPort).Content;
        }
    }
}
