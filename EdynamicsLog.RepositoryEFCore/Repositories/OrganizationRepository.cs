using EdynamicsLog.Entities.Interfaces;
using EdynamicsLog.Entities.POCOs;
using EdynamicsLog.RepositoryEFCore.DataContext;

namespace EdynamicsLog.RepositoryEFCore.Repositories
{
    public class OrganizationRepository : IOrganizationRepository
    {
        readonly EdynamicsLogBussinessContext Context;

        public OrganizationRepository(EdynamicsLogBussinessContext context) =>  Context = context;

        public void CreateOrganization(Organization organization)
        {
            Context.Add(organization);
        }

        public IEnumerable<Organization> GetAllOrganizations()
        {
            return Context.Organizations.ToList();
        }
    }
}
