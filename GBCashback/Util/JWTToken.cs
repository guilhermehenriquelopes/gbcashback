using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GBCashback.Models;
using Microsoft.IdentityModel.Tokens;

namespace GBCashback.Util
{
    public class JWTToken
    {
        public static string Secret = "e5b3c21e1abe4d00a6a0eb8e2cf2ffe117b9a857b8e84037bc751c7bd55503be";

        public static string GerarToken(Revendedor revendedor)
        {            
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, revendedor.CPF.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}