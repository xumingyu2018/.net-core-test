using demo1.Models;
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
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // 登录功能
        public IActionResult Login(string username ,string password){
            // MySqlConnection数据库连接（类似JDBC）
            MySqlConnection conn=new MySqlConnection("data source=localhost;database=login;user id=root;password=123456;pooling=false;charset=utf8");
            conn.Open();
            // MySqlCommand执行SQL语句
            MySqlCommand cmd =new MySqlCommand($"Select * from user where username=@username and password =@password",conn);
            // 防止SQL注入
            MySqlParameter[] sqlParameters =new MySqlParameter[]{
                new MySqlParameter("@username",username),
                new MySqlParameter("@password",password)
            };
            cmd.Parameters.AddRange(sqlParameters);
            MySqlDataAdapter sda=new(cmd);

            DataSet ds=new();
            sda.Fill(ds);
            DataTable res=ds.Tables[0];
            
            System.Console.WriteLine("查询到的记录数："+res.Rows.Count);
            if (res.Rows.Count==0)
            {
                ViewData["msg"]="用户名或密码错误";
                // return Json("用户名或密码错误");
                return View("Index");
            }else{
                ViewData["msg"]=" 登录成功 ";
                return View("Login");
            }
        }

      //  注册功能
        public IActionResult Register(string username ,string password){
            // MySqlConnection数据库连接（类似JDBC）
            using MySqlConnection conn=new MySqlConnection("data source=localhost;database=login;userid=root;password=123456;pooling=false;charset=utf8");
            conn.Open();

            MySqlCommand query =new MySqlCommand($"Select * from user where username=@username and password =@password",conn);
            MySqlParameter[] sqlParameters =new MySqlParameter[]{
                new MySqlParameter("@username",username),
                new MySqlParameter("@password",password)
            };
            query.Parameters.AddRange(sqlParameters);
            MySqlDataAdapter sda=new(query);
            DataSet ds=new();
            sda.Fill(ds);
            DataTable res=ds.Tables[0];   
            
            if (res.Rows.Count==0)
            {
                MySqlCommand sc=new MySqlCommand($"insert into user(username,password) values('{username}','{password}')",conn);
                sc.ExecuteNonQuery();
                ViewData["msg_success"]="注册成功";
                return View("Register");
            }else{
                ViewData["msg_error"]="注册失败，该用户已存在";
                return View("Register");
            }
        }
  
  
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
