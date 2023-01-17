using BasicCrud.Business.Abstract;
using BasicCrud.Business.Constants;
using BasicCrud.Core.Entities.Concrete;
using BasicCrud.Core.Utilities.Results;
using BasicCrud.Core.Utilities.Security.Jwt;
using BasicCrud.Entities.Dtos;

namespace BasicCrud.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly ITokenHelper _tokenHelper;

        public AuthManager(ITokenHelper tokenHelper)
        {
            _tokenHelper = tokenHelper;
        }

        private List<User> _users = new()
        {
            new User { Id = 1, UserName = "ali", Password = "1234" }
        };

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _users.SingleOrDefault(x => x.UserName == userForLoginDto.UserName && x.Password == userForLoginDto.Password);

            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.User.UserNotFound());
            }

            return new SuccessDataResult<User>(userToCheck, Messages.User.SuccessfulLogin());
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var accessToken = _tokenHelper.CreateToken(user);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.User.SuccessfulLogin());
        }
    }
}