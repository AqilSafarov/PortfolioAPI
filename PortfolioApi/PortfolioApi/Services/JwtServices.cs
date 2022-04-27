using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PortfolioApi.Data.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioApi.Services
{
    public class JwtServices: IJwtServices
    {

        private readonly IConfiguration _configuration;

        public JwtServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Generate(AppUser user, IList<string> roles)
        {


            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(JwtRegisteredClaimNames.Sub,user.Id),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            if (user.Email != null)
                claims.Add(new Claim(ClaimTypes.Email, user.Email));

            var roleClaim = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();
            claims.AddRange(roleClaim);

            string key = _configuration.GetSection("JWT:Key").Value;
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));


            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


            JwtSecurityToken token = new JwtSecurityToken
                (
                   issuer: _configuration.GetSection("JWT:Issuer").Value,
                   audience: _configuration.GetSection("JWT:Issuer").Value,
                   claims: claims,
                   //expires: DateTime.UtcNow.AddDays(3),
                   expires: DateTime.UtcNow.AddDays(Convert.ToDouble(_configuration.GetSection("JWT:ExpirationInDays").Value)),
                   signingCredentials: credentials
                );

            var tokenStr = new JwtSecurityTokenHandler().WriteToken(token); //string olaraq oxunmasi ucun handlernen yaziriq
            return tokenStr;
        }
    }
}
