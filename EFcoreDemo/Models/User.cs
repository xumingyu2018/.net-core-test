using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EFcoreDemo.Models
{
    public class User
    {
        [Key]
        [DisplayName("用户ID")]
        public int UserID { get; set; }//用户编号

        [DisplayName("用户名")]                 
        public string UserName { get; set; }            //用户名

        [DisplayName("密码")] 
        public string Password { get; set; }            //密码

        [DisplayName("性别")] 
        public int Sex { get; set; }                    //性别，0男，1女

        [DisplayName("年龄")] 
        public int Age { get; set; }                    //年龄

        [DisplayName("政治面貌")] 
        public int Political { get; set; }              //政治面貌

        [DisplayName("身高")] 
        public int Height { get; set; }                 //身高

        [DisplayName("体重")] 
        public int Weight { get; set; }                 //体重

        [DisplayName("毕业院校")] 
        public string Graduated { get; set; }           //毕业院校

        [DisplayName("专业")] 
        public string Professional { get; set; }        //专业

        [DisplayName("毕业日期")] 
        public DateTime GraduatedDate { get; set; }     //毕业日期

        [DisplayName("现住地址")] 
        public string Address { get; set; }             //现住地址

        [DisplayName("联系电话")] 
        public string Phone { get; set; }               //联系电话

        [DisplayName("头相地址")] 
        public string ImagePath { get; set; }           //头相地址

        [DisplayName("其他描述")] 
        public string Other { get; set; }               //其他描述

    }
}