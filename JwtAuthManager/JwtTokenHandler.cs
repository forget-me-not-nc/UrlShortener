using JwtAuthManager.DTO;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JwtAuthManager
{
    public class JwtTokenHandler
    {
        public const string JWT_SECURITY_KEY = "eyJhbGciOiJIUzI1NiJ9.eyJSb2xlIjoiQWRtaW4iLCJJc3N1ZXIiOiJJc3N1ZXIiLCJVc2VybmFtZSI6IkphdmFJblVzZSIsImV4cCI6MTY5NDMwMzQ2OSwiaWF0IjoxNjk0MzAzNDY5fQ.5E6CaLTcG497zGXHbsmDdYhHby5j4Fd-00LwvGgp8hI";
        public const int JWT_TOKEN_VALIDITY_MINS = 20;

        public JwtTokenHandler() { }

        public TokenResponse GenerateJwtToken(TokenRequest tokenRequest)
        {
            try
            {
                var tokenExpiryTimeStamp = DateTime.Now.AddMinutes(JWT_TOKEN_VALIDITY_MINS);
                var tokenKey = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);
                var claimsIdentity = new ClaimsIdentity(new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Name, tokenRequest.Username),
                    new Claim(JwtRegisteredClaimNames.Sub, tokenRequest.UserId.ToString()),
                });

                foreach (var role in tokenRequest.Roles)
                {
                    claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, role));
                };

                var signInCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature
                    );

                var securityTokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = claimsIdentity,
                    Expires = tokenExpiryTimeStamp,
                    SigningCredentials = signInCredentials
                };

                var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
                var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
                var token = jwtSecurityTokenHandler.WriteToken(securityToken);

                return new TokenResponse
                {
                    JwtToken = token,
                    ExpiresAt = tokenExpiryTimeStamp,
                    Username = tokenRequest.Username
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }
    }
}
