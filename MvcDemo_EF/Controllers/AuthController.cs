using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MvcDemo_EF.BLL;
using MvcDemo_EF.Models;
using System.Threading.Tasks;

namespace MvcDemo_EF.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authBLL;
        private readonly MvcUserContext _db;


        public AuthController(IAuthService authBLL,MvcUserContext db)
        {
            _authBLL = authBLL;
            _db = db; 
        }

        /// <summary>
        ///登录页
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 登录页表单提交
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        [HttpPost] 
        public /*async Task<IActionResult>*/ IActionResult Login(LoginAccount _account)
        {
            bool isSuccess = _authBLL.CheckLoginIsSuccess(_account, _db);
            LoginResult loginResult = new() { 
                IsLogin = true, IsSuccess = isSuccess
                };

            if (isSuccess)
            {
                /* 
                 var claimsIdentity = new ClaimsIdentity("login");
                 claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, _account.Account.ToString()));
                 var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                 await HttpContext.SignInAsync(claimsPrincipal);
                */
            }

            loginResult.Msg = isSuccess ? "登录成功" : "用户名或密码错误";

            return Json(loginResult);
        }


        /*[HttpGet]
        public IActionResult Logout()
        {
            Task.Run(async () =>
            {
                //注销登录的用户，相当于ASP.NET中的FormsAuthentication.SignOut  
                await HttpContext.SignOutAsync();
            }).Wait();
            return View("Index");
        }*/



        /// <summary>
        /// 注册页
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Regist()
        {
            return View();
        }

        /// <summary>
        /// 注册页表单提交
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Regist(LoginAccount _account)
        {
            bool IsSuccess = _authBLL.RegistUser(_account, _db);

            LoginResult loginResult = new() { IsLogin = false, IsSuccess = IsSuccess };

            loginResult.Msg = IsSuccess ? "注册成功" : "该用户名已存在";

            return Json(loginResult);
        }
    }
}
