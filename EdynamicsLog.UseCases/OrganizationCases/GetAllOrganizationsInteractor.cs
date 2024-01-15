using EdynamicsLog.DTOs.Organization;
using EdynamicsLog.Entities.Interfaces;
using EdynamicsLog.UseCasesPorts.InputPort.Organization;
using EdynamicsLog.UseCasesPorts.OutputPort.Organization;

namespace EdynamicsLog.UseCases.OrganizationCases
{
    public class GetAllOrganizationsInteractor : IGetAllOrganizationsInputPort
    {
        readonly IOrganizationRepository Repository;
        readonly IGetAllOrganizationsOutputPort OutputPort;

        public GetAllOrganizationsInteractor(IOrganizationRepository repository,
                                       IGetAllOrganizationsOutputPort outputPort) =>
                                       (Repository, OutputPort) =
                                       (repository, outputPort);
        public Task Handle()
        {
           var Organizations = Repository.GetAllOrganizations().Select(o =>
           new OrganizationDTO
           {
               Id = o.Id,
               Name = o.Name,
               SlugTenat = o.SlugTenat
           });

            OutputPort.Handle(Organizations);

            return Task.CompletedTask;
        }
    }
}
