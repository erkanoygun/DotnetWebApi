using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MyApp.DBOperations;
using MyApp.TokenOperations;
using MyApp.TokenOperations.Models;

namespace MyApp.Application.UserOperations.Commands
{
    public class RefreshTokenCommand
    {
        public string refreshToken { get; set; } = null!;
        private readonly IBookStoreDBContext _dbContext;

        private readonly IConfiguration _configuration;

        public RefreshTokenCommand(IBookStoreDBContext context, IConfiguration configuration)
        {
            _dbContext = context;
            _configuration = configuration;
        }


        public Token Handle()
        {
            var user = _dbContext.Users.FirstOrDefault(x=> x.refreshToken == refreshToken && x.refreshTokenExpireDate > DateTime.Now);
            if(user is not null)
            {
                TokenHandler handler = new TokenHandler(_configuration);
                Token token = handler.CreateAccesToken(user);

                user.refreshToken = token.refreshToken;
                user.refreshTokenExpireDate = token.expiration.AddMinutes(5);

                _dbContext.SaveChanges();

                return token;
            }
            else
                throw new InvalidOperationException("e mail or user name error");
        }
    }
}