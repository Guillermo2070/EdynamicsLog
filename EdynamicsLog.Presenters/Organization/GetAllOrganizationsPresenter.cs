using EdynamicsLog.DTOs.Organization;
using EdynamicsLog.UseCasesPorts.OutputPort.Organization;

namespace EdynamicsLog.Presenters.Organization
{
    public class GetAllOrganizationsPresenter : IGetAllOrganizationsOutputPort, IPresenter<IEnumerable<OrganizationDTO>>
    {
        public IEnumerable<OrganizationDTO> Content { get; private set; }

        public Task Handle(IEnumerable<OrganizationDTO> organizations)
        {
            Content = organizations;

            return Task.CompletedTask;
        }
    }
}
