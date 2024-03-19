using System.Security.Principal;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.UserOperations.Commands;
using MyApp.DBOperations;
using MyApp.TokenOperations.Models;
using static MyApp.Application.UserOperations.Commands.CreateUserCommand;

namespace MyApp.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class UserController : ControllerBase
    {
        private readonly IBookStoreDBContext _context;
        private readonly IMapper _mapper;
        readonly IConfiguration _configuration;

        public UserController(IBookStoreDBContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }



        [HttpPost]
        public IActionResult Create([FromBody] CreateUserModel newUserModel)
        {
            CreateUserCommand command = new CreateUserCommand(_context, _mapper)
            {
                model = newUserModel
            };
            command.Handle();
            return Ok();
        }

        [HttpPost("connect/token")]
        public ActionResult<Token> CreateToken([FromBody] CreateTokenModel login)
        {
            CreateTokenCommand command = new CreateTokenCommand(_context, _mapper, _configuration)
            {
                model = login

            };
            var token = command.Handle();
            return token;
        }

        [HttpGet("refreshToken")]
        public ActionResult<Token> RefreshToken([FromQuery] string token)
        {
            RefreshTokenCommand command = new RefreshTokenCommand(_context, _configuration)
            {
                refreshToken = token
            };

            var resultToken = command.Handle();
            return resultToken;
        }
    }
}