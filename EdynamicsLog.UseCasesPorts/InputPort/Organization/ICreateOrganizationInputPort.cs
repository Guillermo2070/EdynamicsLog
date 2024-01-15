using EdynamicsLog.DTOs.Organization;

namespace EdynamicsLog.UseCasesPorts.InputPort.Organization
{
    public interface ICreateOrganizationInputPort
    {
        Task Handle(CreateOrganizationDTO organization);
    }
}
