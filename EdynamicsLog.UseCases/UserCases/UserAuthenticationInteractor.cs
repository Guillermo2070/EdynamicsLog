using EdynamicsLog.DTOs.User;
using EdynamicsLog.Entities.Interfaces;
using EdynamicsLog.Entities.POCOs;
using EdynamicsLog.UseCasesPorts.InputPort.User;
using EdynamicsLog.UseCasesPorts.OutputPort.User;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EdynamicsLog.UseCases.UserCases
{
    public class UserAuthenticationInteractor : IUserAuthenticationInputPort
    {
        private readonly IUserRepository Repository;
        private readonly IUserAuthenticationOutputPort OutputPort;
        private readonly IConfiguration Configuration;

        public UserAuthenticationInteractor(
            IUserRepository repository,
            IUserAuthenticationOutputPort outputPort,
            IConfiguration configuration)
        {
            Repository = repository;
            OutputPort = outputPort;
            Configuration = configuration;
        }

        public async Task Handle(AuthenticationDTO authentication)
        {
            User authenticatedUser = Repository.GetSlugTenant(authentication.Email, authentication.Password);

            if (authenticatedUser != null)
            {
                string slugTenatOrganization = authenticatedUser.SlugTenatOrganization;

                string accessToken = GenerateJwtToken(authenticatedUser.Email);

                await OutputPort.Handle(new SlugTenantDTO
                {
                    SlugTenat = slugTenatOrganization,
                    AccessToken = accessToken
                });
            }
            else
            {
                await OutputPort.HandleCredencialesIncorrectas("Credenciales incorrectas. Por favor, verifica tu usuario y contraseña.");
            }
        }

        private string GenerateJwtToken(string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(Configuration["JwtSettings:SecretKey"]!);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, email) }),
                Expires = DateTime.UtcNow.AddHours(1),
                Audience = Configuration["JwtSettings:Audience"],
                Issuer = Configuration["JwtSettings:Issuer"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
