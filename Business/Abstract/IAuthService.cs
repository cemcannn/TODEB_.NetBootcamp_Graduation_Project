using Business.Configuration.Auth;

namespace Business.Abstract
{
    public interface IAuthService
    {
        AccessToken Login(string email, string password);
    }
}
