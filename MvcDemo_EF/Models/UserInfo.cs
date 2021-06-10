using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MvcDemo_EF.Models
{
    public class UserInfo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(7)]
        [DisplayName("用户名")]
        public string UserName { get; set; }

        [Required]
        [StringLength(10)]
        [DisplayName("密码")]
        public string Pwd { get; set; }
    }
}
