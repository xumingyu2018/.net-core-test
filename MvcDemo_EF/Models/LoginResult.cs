using System;

namespace MvcDemo_EF.Models
{
    public class LoginResult
    {
        public bool IsLogin { get; set; } //0--登录 ；1--注册

        public bool IsSuccess { get; set; }//0--失败 ；1--成功

        public string Msg { get; set; }//登录状态信息
    }
}
