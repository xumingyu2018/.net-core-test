using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FileDemo.Data
{
    public class DocumentDetail
    {
        [Key]
        public int Id { get; set; }

        //文档类型
        public int Type { get; set; }

        //文件类型
        public string FileType { get; set; }

        //文件名称
        public string DocName { get; set; }

        //文件描述
        public string DocDesc { get; set; }

        //内容
        public byte[] DocContent { get; set; }
    }
}
