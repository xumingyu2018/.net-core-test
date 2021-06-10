using FileDemo.Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FileDemo.Models
{
    public class UploadModel
    {

        public int TypeId { get; set; }//分类Id

        public string TypeName { get; set; }//分类名称

        public string DocDesc { get; set; }//文件描述

        public List<DocumentType> TypeList { get; set; }////分类信息

        [Required(ErrorMessage = "未选择任何文件")]
        public IFormFile FormFile { get; set; }//上传的文件
    }
}
