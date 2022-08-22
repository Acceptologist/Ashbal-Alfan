using freelanceProject.DTO;
using freelanceProject.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace freelanceProject.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private IConfiguration config;
        public AuthRepository(IConfiguration config)
        {
            this.config = config;
        }

        public AuthModel GetToken(User user, string role)
        {
            var authModel = new AuthModel();


            var jwtSecurityToken = CreateJwtToken(user,role);

            authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authModel.Username = user.UserName;
            authModel.ExpiresOn = jwtSecurityToken.ValidTo;
            authModel.IsAuthenticated = true;
            authModel.Role=role;
            return authModel;

        }

        public JwtSecurityToken CreateJwtToken(User user,string role)
        {

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("uid", user.Id),
                new Claim("role", role)
            };

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Key"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: config["JWT:Issuer"],
                audience: config["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(double.Parse(config["JWT:DurationInDays"])),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
    }
}
