using System.Reflection.Metadata;
using MvcDemo_EF.DAL;
using MvcDemo_EF.Models;
using System.Collections.Generic;
using System.Linq;

namespace MvcDemo_EF.BLL.Impl
{
    public class AuthService : IAuthService
    {
        private readonly IUserDAL _userDAL;

        public AuthService(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }


        /// <summary>
        /// 判断用户是否成功登录
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public bool CheckLoginIsSuccess(LoginAccount account, MvcUserContext db)
        {
            IEnumerable<UserInfo> UserData = _userDAL.GetUserByUserNameAndPwd(account,db);

            //如果UserData有数据这登录成功
            return UserData.Any();
        }


        /// <summary>
        /// user regist
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public bool RegistUser(LoginAccount account, MvcUserContext db)
        {
            bool IsExist = CheckUserIsExist(account, db);

            UserInfo userInfo = new UserInfo()
            {
                UserName = account.Account,
                Pwd = account.Password
            };

            return IsExist ? InsertUser(userInfo, db) : IsExist;
        } 
        
        /// <summary>
        /// add user to Db
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        private bool InsertUser(UserInfo userInfo, MvcUserContext db)
        {
            return _userDAL.InsertUser(userInfo, db) == 1;
        }

        private bool CheckUserIsExist(LoginAccount account, MvcUserContext db)
        {
            IEnumerable<UserInfo> UserData = _userDAL.GetUserByUserName(account, db);

            //如果UserData有数据，证明用户已存在，则返回false
            return !UserData.Any();
        }
    } 
}