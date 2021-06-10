using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;

namespace demo1.Controllers
{
    public class LoginController : Controller
    {
        // public IActionResult login(string username ,string password){
        //     // MySqlConnection数据库连接（类似JDBC）
        //     MySqlConnection conn=new MySqlConnection("data source=localhost;database=login;user id=root;password=123456;pooling=false;charset=utf8");
        //     conn.Open();
        //     // MySqlCommand执行SQL语句
        //     MySqlCommand cmd =new MySqlCommand($"Select * from user where username=@username and password =@password",conn);
        //     // 防止SQL注入
        //     MySqlParameter[] sqlParameters =new MySqlParameter[]{
        //         new MySqlParameter("@username",username),
        //         new MySqlParameter("@password",password)
        //     };
        //     cmd.Parameters.AddRange(sqlParameters);
        //     MySqlDataAdapter sda=new(cmd);

        //     DataSet ds=new();
        //     sda.Fill(ds);
        //     DataTable res=ds.Tables[0];
            
        //     System.Console.WriteLine(res.Rows.Count);
        //     if (res.Rows.Count==0)
        //     {
        //         ViewData["msg"]="用户名或密码错误";
        //         return Json("用户名或密码错误");
        //     }else{
        //        ViewData["msg"]=" 登录成功 ";
        //         return View();
        //     }
        // }

        // public IActionResult register(string username ,string password){
        //     // MySqlConnection数据库连接（类似JDBC）
        //     using MySqlConnection conn=new MySqlConnection("data source=localhost;database=login;user id=root;password=123456;pooling=false;charset=utf8");
        //     conn.Open();

        //     System.Console.WriteLine("username:"+username+"password:"+password);    
        //     MySqlCommand cmd=new MySqlCommand($"insert into user(username,password) values('{username}','{password}')",conn);
        //     cmd.ExecuteNonQuery();
            
        //     // ViewData("msg")="该用户已存在";
        //     //     return View();
        //     return View("Register");
        // }
    }
}