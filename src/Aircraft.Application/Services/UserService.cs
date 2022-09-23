 using Microsoft.IdentityModel.Tokens;
 using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Aircraft.Application.Services
{

    public class UserService 
    {

        public void CreateToken(string login, string password)
        {
            var claims = new Claim[1]
            {
                new Claim(login, password)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("teste"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        }

    }
}