using BasicCrud.Core.Entities.Concrete;
using BasicCrud.Core.Utilities.Results;
using BasicCrud.Core.Utilities.Security.Jwt;
using BasicCrud.Entities.Dtos;

namespace BasicCrud.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
