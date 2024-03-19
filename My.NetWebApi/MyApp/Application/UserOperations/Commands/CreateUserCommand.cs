using AutoMapper;
using MyApp.DBOperations;
using MyApp.Entities;

namespace MyApp.Application.UserOperations.Commands
{
    public class CreateUserCommand
    {
        public CreateUserModel model {get; set;} = null!;
        private readonly IBookStoreDBContext _dbContext;
        private readonly IMapper _mapper;

        public CreateUserCommand(IBookStoreDBContext context,IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var user = _dbContext.Users.SingleOrDefault(x=>x.email == model.email);
            if(user is not null)
                throw new InvalidOperationException("User is already exist");
            
            user = _mapper.Map<User>(model);
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public class CreateUserModel
        {
            public string name {get;set;} = null!;
            public string surName {get;set;} = null!;
            public string email {get;set;} = null!;
            public string password {get;set;} = null!;
        }
    }
}