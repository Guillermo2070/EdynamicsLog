using EdynamicsLog.DTOs.Organization;
using EdynamicsLog.Entities.Interfaces;
using EdynamicsLog.Entities.POCOs;
using EdynamicsLog.UseCasesPorts.InputPort.Organization;
using EdynamicsLog.UseCasesPorts.OutputPort.Organization;

namespace EdynamicsLog.UseCases.OrganizationCases
{
    public class CreateOrganizationInteractor : ICreateOrganizationInputPort
    {
        readonly IOrganizationRepository Repository;
        readonly IUnitOfWorkBussiness UnitOfWork;
        readonly ICreateOrganizationOutputPort OutputPort;

        public CreateOrganizationInteractor(IOrganizationRepository repository,
                                       IUnitOfWorkBussiness unitOfWork,
                                       ICreateOrganizationOutputPort outputPort) =>
                                       (Repository, UnitOfWork, OutputPort) =
                                       (repository, unitOfWork, outputPort);
        public async Task Handle(CreateOrganizationDTO organization)
        {
            Organization newOrganization = new Organization
            {
                Name = organization.Name,
                SlugTenat = organization.SlugTenat
            };

            Repository.CreateOrganization(newOrganization);

            await UnitOfWork.SaveChanges();

            await OutputPort.Handle(
              new OrganizationDTO
              {
                  Id = newOrganization.Id,
                  Name = newOrganization.Name,
                  SlugTenat = newOrganization.SlugTenat
              });
        }
    }
}
