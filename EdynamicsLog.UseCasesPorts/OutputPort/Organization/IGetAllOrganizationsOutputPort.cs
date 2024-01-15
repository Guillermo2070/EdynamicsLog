using EdynamicsLog.DTOs.Organization;

namespace EdynamicsLog.UseCasesPorts.OutputPort.Organization
{
    public interface IGetAllOrganizationsOutputPort
    {
        Task Handle(IEnumerable<OrganizationDTO> organizations);
    }
}
