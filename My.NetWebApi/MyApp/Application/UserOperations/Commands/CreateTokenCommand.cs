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
    public class CreateTokenCommand
    {
        public CreateTokenModel model { get; set; } = null!;
        private readonly IBookStoreDBContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public CreateTokenCommand(IBookStoreDBContext context,IMapper mapper, IConfiguration configuration)
        {
            _dbContext = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        public Token Handle()
        {
            var user = _dbContext.Users.FirstOrDefault(x=> x.email == model.email && x.password == model.password);
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
                throw new InvalidOperationException("A valid refreshToken is not found!");
        }

    }

    public class CreateTokenModel
    {
        public string email { get; set; } = null!;
        public string password { get; set; } = null!;
    }

    
}