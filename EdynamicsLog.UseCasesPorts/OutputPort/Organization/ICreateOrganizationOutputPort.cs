using EdynamicsLog.DTOs.Organization;

namespace EdynamicsLog.UseCasesPorts.OutputPort.Organization
{
    public interface ICreateOrganizationOutputPort
    {
        Task Handle(OrganizationDTO organization);
    }
}
