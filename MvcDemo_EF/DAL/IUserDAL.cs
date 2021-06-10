using MvcDemo_EF.Models;
using System.Collections.Generic;

namespace MvcDemo_EF.DAL
{
    public interface IUserDAL
    {

        IEnumerable<UserInfo> GetUserByUserNameAndPwd(LoginAccount account, MvcUserContext db);

        IEnumerable<UserInfo> GetUserByUserName(LoginAccount account, MvcUserContext db);

        int InsertUser(UserInfo userInfo, MvcUserContext db);
    }
}