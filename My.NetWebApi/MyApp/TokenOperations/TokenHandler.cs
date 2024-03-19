using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using MyApp.Entities;
using MyApp.TokenOperations.Models;

namespace MyApp.TokenOperations
{
    public class TokenHandler
    {
        public IConfiguration configuration {get; set;}
        public TokenHandler(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public Token CreateAccesToken(User user)
        {
            Token tokenModel = new Token();
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:SecurityKey"]));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            tokenModel.expiration = DateTime.Now.AddMinutes(15);

            JwtSecurityToken securityToken = new JwtSecurityToken(
                issuer: configuration["Token:Issuer"],
                audience: configuration["Token:Audience"],
                expires: tokenModel.expiration,
                notBefore: DateTime.Now,
                signingCredentials: credentials
            );

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            tokenModel.accesToken = tokenHandler.WriteToken(securityToken);
            tokenModel.refreshToken = CreateRefreshToken();

            return tokenModel;
        }

        public string CreateRefreshToken()
        {
            return Guid.NewGuid().ToString();
        }

    }
}