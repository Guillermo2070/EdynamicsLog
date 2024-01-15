using EdynamicsLog.Entities.POCOs;

namespace EdynamicsLog.Entities.Interfaces
{
    public interface IOrganizationRepository
    {
        void CreateOrganization(Organization organization);

        IEnumerable<Organization> GetAllOrganizations(); 
    }
}
