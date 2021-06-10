using System;
using System.Data;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using demomvc.Models;
using MySql.Data.MySqlClient;

namespace demomvc.Controllers
{

    public class LoginController:Controller
    {
            
        [HttpPost]
        public string Login(string name,string pwd)
        {
            System.Data.MySqlConnection conn=new System.Data.MySqlConnection("server=127.0.0.1;database=user;uid=root;pwd=123456");//实例化对象
            conn.Open();//打开数据库
            MySqlCommand cmd=new MySqlCommand("SELECT * FROM login where name='"+name+ "' and pwd="+pwd,conn);
            MySqlDataAdapter sda=new MySqlDataAdapter(cmd);
           System.Data.DataSet ds=new System.Data.DataSet();
            sda.Fill(ds);
            System.Data.DataTable res=ds.Tables[0];
            System.Data.DataRow dr=res.Rows[0];
            //System.Console.WriteLine("+++++++++++++++++");测试
            var resUsername=dr["name"].ToString();
            var resPassword=dr["pwd"].ToString();
            // System.Console.WriteLine(resUsername);//测试
            // System.Console.WriteLine(name);
            // System.Console.WriteLine(resPassword);
            // System.Console.WriteLine(pwd);
            if (resUsername==name&&resPassword== pwd)

            {
                // ViewData["msg"]="登录成功";
                return "登录成功";
            }else
            {
                 return "登录失败";
            }
       }
    
    }
}