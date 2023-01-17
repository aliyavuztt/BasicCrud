using BasicCrud.Core.Entities.Concrete;

namespace BasicCrud.Core.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user);
    }
}
