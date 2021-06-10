using MvcDemo_EF.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MvcDemo_EF.DAL.Impl
{
    public class UserDAL : IUserDAL
    {
        // private readonly MvcUserContext _db;

        // public UserDAL(MvcUserContext db)
        // {
        //     _db = db;
        // }

        public IEnumerable<UserInfo> GetUserByUserNameAndPwd(LoginAccount account, MvcUserContext db)
        {

            IEnumerable<UserInfo> userInfos = db.UserInfo;

            return from userInfo in userInfos
                   where userInfo.UserName == account.Account
                   where userInfo.Pwd == account.Password
                   select userInfo;
        }

        public IEnumerable<UserInfo> GetUserByUserName(LoginAccount account, MvcUserContext db)
        {

            return GetUserByUserNameAndPwd(account, db);
        }

        public int InsertUser(UserInfo userInfo, MvcUserContext db)
        {
            db.UserInfo.Add(userInfo);
            return db.SaveChanges();
        }
    }
}