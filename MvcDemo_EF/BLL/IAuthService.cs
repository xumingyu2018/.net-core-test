using MvcDemo_EF.Models;

namespace MvcDemo_EF.BLL
{
    public interface IAuthService
    {
        bool CheckLoginIsSuccess(LoginAccount account, MvcUserContext db);

        bool RegistUser(LoginAccount account, MvcUserContext db);
    } 
}