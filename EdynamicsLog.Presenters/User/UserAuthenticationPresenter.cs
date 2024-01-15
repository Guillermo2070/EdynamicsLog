using EdynamicsLog.DTOs.User;
using EdynamicsLog.UseCasesPorts.OutputPort.User;

namespace EdynamicsLog.Presenters.User
{
    internal class UserAuthenticationPresenter : IUserAuthenticationOutputPort, IPresenter<SlugTenantDTO>
    {
        public SlugTenantDTO Content { get; set; }

        public Task Handle(SlugTenantDTO slugTenant)
        {
            Content = slugTenant;

            return Task.CompletedTask;
        }

        public Task HandleCredencialesIncorrectas(string mensaje)
        {
            Content = null; 
                          
            return Task.CompletedTask;
        }
    }
}
