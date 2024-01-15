using EdynamicsLog.DTOs.Organization;
using EdynamicsLog.UseCasesPorts.OutputPort.Organization;

namespace EdynamicsLog.Presenters.Organization
{
    public class CreateOrganizationPresenter : ICreateOrganizationOutputPort, IPresenter<OrganizationDTO>
    {
        public OrganizationDTO Content { get; private set; }

        public Task Handle(OrganizationDTO organization)
        {
            Content = organization;

            return Task.CompletedTask;
        }
    }
}
