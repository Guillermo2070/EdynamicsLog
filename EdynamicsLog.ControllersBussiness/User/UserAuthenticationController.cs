using EdynamicsLog.DTOs.User;
using EdynamicsLog.Presenters;
using EdynamicsLog.UseCasesPorts.InputPort.User;
using EdynamicsLog.UseCasesPorts.OutputPort.User;
using Microsoft.AspNetCore.Mvc;

namespace EdynamicsLog.ControllersBussiness.User
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserAuthenticationController : ControllerBase
    {
        readonly IUserAuthenticationInputPort InputPort;
        readonly IUserAuthenticationOutputPort OutputPort;

        public UserAuthenticationController(IUserAuthenticationInputPort inputPort, IUserAuthenticationOutputPort outputPort)
        {
            InputPort = inputPort;
            OutputPort = outputPort;
        }
        [HttpPost]
        public async Task<IActionResult> GetSlugTenant(AuthenticationDTO authentication)
        {
            await InputPort.Handle(authentication);

            var content = ((IPresenter<SlugTenantDTO>)OutputPort).Content;

            if (content != null)
            {
                var result = new
                {
                    status = 200,
                    statusText = "POST Request successful",
                    data = new
                    {
                        accessToken = content.AccessToken,
                        tenants = new[]
                        {
                            new
                            {
                                slugTenant = content.SlugTenat
                            }
                        }
                    }
                };

                return Ok(result);
            }
            else
            {
                return BadRequest(new { message = "Credenciales incorrectas. Por favor, verifica tu usuario y contraseña." });
            }
        }
    }
}
