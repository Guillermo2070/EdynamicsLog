namespace EdynamicsLog.UseCasesPorts.InputPort.User
{
    public interface IGetAllUsersInputPort
    {
        Task Handle(string slugTenatOrganization);
    }
}
